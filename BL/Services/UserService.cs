using Core;
using Core.AdditionalTables;
using Core.Contracts;
using Core.Contracts.PL_BL;
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

        public UserService(// ctor
            IRepository<User> userRepo,
            ICryptor crypter,
            IRepository<Product> productRepo)
        {
            this.userRepo = userRepo;
            this.crypter = crypter;
            this.productRepo = productRepo;
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
            //var product = productRepo.FindFirst(p => p.Id == productId);
            var user = userRepo.FindFirst(u => u.Id == userId);
            user.UserShoppingCart.Add(new UserShoppingCart() { ProductId = productId, UserId = userId/*Product = product, User = user*/ });
            bool success = userRepo.Save() > 0;
            ResultContract result = new ResultContract() { IsSuccessful = success };
            if (success)
                result.Message = "Product was apped to cart successfully!";
            else
                result.Message = "An error occured during adding to cart process";

            return result;
        }
    }
}
