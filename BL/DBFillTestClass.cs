using Core.Entities;
using Core.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class DBFillTestClass
    {
        private readonly ISContext dbcontext;
        private readonly ICryptor cryptor;

        private const int insertRecords = 100;

        public DBFillTestClass(ISContext dbcontext, ICryptor cryptor)
        {
            this.dbcontext = dbcontext;
            this.cryptor = cryptor;
        }

        public void RefillDB()
        {
            dbcontext.Database.EnsureDeleted();
            dbcontext.Database.EnsureCreated();

            //dbcontext.Users.RemoveRange(dbcontext.Users);// remove all users ever created

            dbcontext.Users.Add(new User()// user with login and password seen below
            {
                Login = "TestUser123", // login
                PasswordHashed = cryptor.Encrypt("12345"),// 12345 is password
                Name = "TestUser",
                Surname = "Doe"
            });

            dbcontext.Users.Add(new User()// user with login and password seen below
            {
                Login = "Ayrum1158", // login
                PasswordHashed = cryptor.Encrypt("12345"),// 12345 is password
                Name = "TestUser",
                Surname = "Doe"
            });

            //dbcontext.ProductCategories.RemoveRange(dbcontext.ProductCategories);// remove all product categories ever created

            List<ProductCategory> pcl = new List<ProductCategory>()
            {
                new ProductCategory()
                {
                    CategoryName = "Smartphone"
                },
                new ProductCategory()
                {
                    CategoryName = "TV"
                },
                new ProductCategory()
                {
                    CategoryName = "Tool"
                },
                new ProductCategory()
                {
                    CategoryName = "Headphones"
                },
                new ProductCategory()
                {
                    CategoryName = "Food"
                }
            };
            dbcontext.ProductCategories.AddRange(pcl);// fill Categories table

            //dbcontext.Products.RemoveRange(dbcontext.Products);// remove all products ever created

            for(int i = 0; i < insertRecords; i++)// fill Products table
            {
                Random rand = new Random();
                int randNum = rand.Next(0, 5);
                dbcontext.Products.Add(new Product()
                {
                    Category = pcl[randNum],
                    Description = pcl[randNum].CategoryName,
                    Name = $"{pcl[randNum].CategoryName} - {i}",
                    Price = rand.Next(5, 5000)
                });
            }

            //dbcontext.UserShoppingCart.RemoveRange(dbcontext.UserShoppingCart);

            dbcontext.SaveChanges();
        }
    }
}
