using Core.AppConfig;
using Core.Contracts.PL_BL;
using Core.Entities;
using Core.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public static class Extensions
    {
        public static void AddDALServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(ISRepository<>));
            services.AddDbContext<ISContext>(x => x.UseSqlServer(AppConfig.ConnectionString));
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
