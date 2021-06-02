using Core.Contracts.PL_BL;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public static class Extentions
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
