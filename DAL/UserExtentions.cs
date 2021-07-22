using Core.Contracts.PL_BL;
using DAL.Entities;
using System;
using System.Text;

namespace DAL
{
    public static class UserExtentions
    {
        public static LoggedInContract ToLoggedInContract(this User user)
        {
            return new LoggedInContract()
            {
                Age = user.Age,
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
            };
        }
    }
}
