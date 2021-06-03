using Core.Contracts;
using Core.Contracts.PL_BL;
using Core.DBNotRelatedEntities;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IUserService
    {
        ResultContract<LoggedInContract> LogInUser(LoggingInContract lic);
        ResultContract RegisterUser(NewUserContract newUser);
        ResultContract DeleteUser(int userId);
        ResultContract<LoggedInContract> UpdateUserInfo(int userId, UserUpdateInfoContract uuic);
        ResultContract AddProductToShopptingCart(int productId, int userId);
        ResultContract<List<ShoppingCartItem>> GetUserShoppingCartItems(int userId);
        ResultContract ConfirmOrder(int userId);
    }
}
