using Core.Contracts.PL_BL;
using Core.Entities;
using Core.Interfaces;
using Core.Setup;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace BL
{
    public static class Extensions
    {
        public static void AddDALServices(this IServiceCollection services, DBOptions dbOptions)
        {
            services.AddTransient(typeof(IRepository<>), typeof(ISRepository<>));
            services.AddDbContext<ISContext>(x => x.UseSqlServer(dbOptions.ConnectionString));
        }

        public static User ToUser(this NewUserContract contract)
        {
            return new User()
            {
                Login = contract.Login,
                PasswordHashed = contract.Password,// this should be already encrypted
                Name = contract.Name,
                Surname = contract.Surname
            };
        }
    }
}
