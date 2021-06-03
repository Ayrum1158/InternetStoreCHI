using Core;
using Core.AdditionalTables;
using Core.Contracts;
using Core.Contracts.PL_BL;
using Core.DBNotRelatedEntities;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class UserService : IUserService
    {
        private readonly ICryptor crypter;
        private readonly IRepository<User> userRepo;
        private readonly IRepository<Product> productRepo;
        private readonly IRepository<UserShoppingCart> uscRepo;

        public UserService(// ctor
            IRepository<User> userRepo,
            ICryptor crypter,
            IRepository<Product> productRepo,
            IRepository<UserShoppingCart> uscRepo)
        {
            this.userRepo = userRepo;
            this.crypter = crypter;
            this.productRepo = productRepo;
            this.uscRepo = uscRepo;
        }

        public ResultContract DeleteUser(int userId)
        {
            userRepo.Remove(userId);
            bool success = userRepo.Save() > 0;
            return new ResultContract { IsSuccessful = success };
        }

        public ResultContract<LoggedInContract> LogInUser(LoggingInContract lic)
        {
            User user = userRepo.FindFirst((u) => u.Login == lic.Login);

            if (user == null)
                return new ResultContract<LoggedInContract> { Data = null, IsSuccessful = false, Message = $"No user {lic.Login} found" };

            if (crypter.DecryptAndCompare(user.PasswordHashed, lic.Password))
                return new ResultContract<LoggedInContract> { Data = user.ToLoggedInContract(), IsSuccessful = true, Message = "Logged in successfully!" };
            else
                return new ResultContract<LoggedInContract> { Data = null, IsSuccessful = false, Message = "Passwords do not match" };

        }

        public ResultContract RegisterUser(NewUserContract newUser)
        {
            if (newUser.Password != newUser.ConfirmPassword)
                return new ResultContract { IsSuccessful = false, Message = "\"Password\" and \"ConfirmPassword\" fields are not matching!" };

            Func<User, bool> predicate = (u) => u.Login == newUser.Login;
            if (userRepo.FindAll(predicate).ToList().Count > 0)
                return new ResultContract { IsSuccessful = false, Message = "User with this login already exists" };

            newUser.Password = crypter.Encrypt(newUser.Password);
            User user = newUser.ToUser();

            userRepo.Add(user);
            bool success = userRepo.Save() > 0;

            if (success)
                return new ResultContract { IsSuccessful = true, Message = "User registered successfully!" };
            else
                return new ResultContract { IsSuccessful = false, Message = "User registration failed by unknown reason" };

        }

        public ResultContract<LoggedInContract> UpdateUserInfo(int userId, UserUpdateInfoContract uuic)
        {
            User user = userRepo.FindFirst(u => u.Id == userId);

            user.Name = uuic.Name;
            user.Surname = uuic.Surname;
            user.Email = uuic.Email;
            user.Age = uuic.Age;

            //userRepo.Update(user);
            bool success = userRepo.Save() > 0;

            var result = new ResultContract<LoggedInContract>() { IsSuccessful = success };

            if (success)
            {
                result.Data = user.ToLoggedInContract();
                result.Message = "User information was updated successfully!";
            }
            else
            {
                result.Message = "No changes were made";
            }

            return result;
        }

        public ResultContract AddProductToShopptingCart(int productId, int userId)
        {
            var product = productRepo.FindFirst(p => p.Id == productId);
            var user = userRepo.FindFirst(u => u.Id == userId);

            var existingUSC = uscRepo.FindFirst(usc => usc.ProductId == product.Id && usc.UserId == userId);
            int quantityForMessage = 0;
            if (existingUSC != null)
            {
                existingUSC.Quantity++;
                quantityForMessage = existingUSC.Quantity;
            }
            else
            {
                var usc = new UserShoppingCart() { Product = product, Quantity = 1 };
                quantityForMessage = 1;
                user.UserShoppingCart.Add(usc);
            }

            bool success;
            try
            {
                success = userRepo.Save() > 0;
            }
            catch (Exception e)
            {
                success = false;
            }

            ResultContract result = new ResultContract() { IsSuccessful = success };
            if (success)
                result.Message = $"Product was added to cart successfully! ({quantityForMessage})";
            else
                result.Message = "An error occured during adding to cart process";

            return result;
        }

        public ResultContract<List<ShoppingCartItem>> GetUserShoppingCartItems(int userId)
        {
            var user = userRepo.FindFirst(u => u.Id == userId);
            var cart = user.UserShoppingCart.ToList();

            var items = new List<ShoppingCartItem>();
            foreach (var i in cart)
            {
                items.Add(new ShoppingCartItem()
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product.Name,
                    ProductPrice = i.Product.Price,
                    Quantity = i.Quantity
                });
            }

            var result = new ResultContract<List<ShoppingCartItem>>()
            {
                Data = items,
                IsSuccessful = true,
                Message = "Retrieval was successful!"
            };

            return result;
        }

        public ResultContract ConfirmOrder(int userId)
        {
            var user = userRepo.FindFirst(u => u.Id == userId);
            var cartItems = user.UserShoppingCart.ToList();

            UserOrder order = new UserOrder() { TimePurchased = DateTime.Now, User = user };

            foreach (var item in cartItems)// filling the order with items from shopping cart
            {
                order.ProductsBought.Add(new ProductWithQuantity()
                {
                    Product = item.Product,
                    Quantity = item.Quantity
                });
            }

            user.UserOrder.Add(order);
            user.UserShoppingCart.Clear();

            bool success = userRepo.Save() > 0;

            var result = new ResultContract() { IsSuccessful = success };

            if (success)
                result.Message = "Thank you for your purchase!";
            else
                result.Message = "An error occured";

            return result;
        }

        public ResultContract<List<UserOrdersContract>> GetUserOrders(int userId)
        {
            User user = userRepo.FindFirst(u => u.Id == userId);
            var orders = user.UserOrder.ToList();

            var uocList = new List<UserOrdersContract>();

            foreach (var order in orders)
            {
                var uoc = new UserOrdersContract()
                {
                    OrderId = order.Id,
                    TimePurchased = order.TimePurchased,
                    TotalOrderPrice = order.ProductsBought.Sum(pwq => pwq.Product.Price * pwq.Quantity),
                    ItemsPurchased = order.ProductsBought.Select(pwq => new ProductWithQuantityLocal()
                    {
                        ProductName = pwq.Product.Name,
                        Quantity = pwq.Quantity,
                        TotalPositionPrice = pwq.Product.Price * pwq.Quantity
                    }).ToList()
                };

                uocList.Add(uoc);
            }

            var result = new ResultContract<List<UserOrdersContract>>()
            {
                IsSuccessful = true,
                Data = uocList,
                Message = "Orders retrieval success!"
            };

            return result;
        }
    }
}
