using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder, ICryptor cryptor)// do data seeding
        {
            modelBuilder.Entity<User>().HasData(
                new User()// user with login and password seen below
                {
                    Id = 1,
                    Login = "TestUser123", // login
                    PasswordHashed = cryptor.Encrypt("12345"),// 12345 is password
                    Name = "TestUser",
                    Surname = "Doe"
                });

            List<ProductCategory> pcl = new List<ProductCategory>()
            {
                new ProductCategory()
                {
                    Id = 1,
                    CategoryName = "Smartphone"
                },
                new ProductCategory()
                {
                    Id = 2,
                    CategoryName = "TV"
                },
                new ProductCategory()
                {
                    Id = 3,
                    CategoryName = "Tool"
                },
                new ProductCategory()
                {
                    Id = 4,
                    CategoryName = "Headphones"
                },
                new ProductCategory()
                {
                    Id = 5,
                    CategoryName = "Food"
                }
            };
            modelBuilder.Entity<ProductCategory>().HasData(pcl);

            const int generateProducts = 100;
            List<Product> products = new List<Product>();
            for (int i = 0; i < generateProducts; i++)
            {
                Random rand = new Random();
                int curRandNum = rand.Next(0, pcl.Count);

                var newProduct = new Product()
                {
                    Id = i + 1,
                    CategoryId = pcl[curRandNum].Id,
                    Description = pcl[curRandNum].CategoryName,
                    Name = $"{pcl[curRandNum].CategoryName} - {i}",
                    Price = rand.Next(5, 5000),
                };
                products.Add(newProduct);
            }
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
