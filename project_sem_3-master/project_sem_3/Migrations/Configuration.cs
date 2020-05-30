namespace project_sem_3.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<project_sem_3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "project_sem_3.Models.ApplicationDbContext";
        }

        protected override void Seed(project_sem_3.Models.ApplicationDbContext context)
        {
            // role
            context.Roles.AddOrUpdate(x => x.Id,
                new ApplicationRole() { Id = "1", Name = "Super" },
                new ApplicationRole() { Id = "2", Name = "Admin" }
                //new ApplicationRole() { Id = "3", Name = "User" }
            );

            // user
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("@Ad123456");
            var mapUser = new Dictionary<string, ApplicationUser>(); // role + user
            List<SeedUserRole> userList = new List<SeedUserRole>();
            // admin
            var admin01 = new ApplicationUser()
            {
                Id = "1",
                UserName = "Super",
                PasswordHash = password,
                Email = "trungnqth1809019@fpt.edut.vn",
                EmailConfirmed = true,
                PhoneNumber = "+84941819959",
                PhoneNumberConfirmed = true,
                LockoutEnabled = true,
            };
            userList.Add(new SeedUserRole() { User = admin01, RoleId = "1" });

            var admin02 = new ApplicationUser()
            {
                Id = "2",
                UserName = "Thu",
                PasswordHash = password,
                Email = "thunqth1807052@fpt.edu.vn",
                EmailConfirmed = true,
                PhoneNumber = "+84979650208",
                PhoneNumberConfirmed = true,
                LockoutEnabled = true,
            };
            userList.Add(new SeedUserRole() { User = admin02, RoleId = "2" });

            var admin03 = new ApplicationUser()
            {
                Id = "3",
                UserName = "Nhat",
                PasswordHash = password,
                Email = "nhatntth1809023@fpt.edu.vn",
                EmailConfirmed = true,
                PhoneNumber = "+84376316448",
                PhoneNumberConfirmed = true,
                LockoutEnabled = true,
            };
            userList.Add(new SeedUserRole() { User = admin03, RoleId = "2" });

            var admin04 = new ApplicationUser()
            {
                Id = "4",
                UserName = "Linh",
                PasswordHash = password,
                Email = "linhnkth1809007@fpt.edu.vn",
                EmailConfirmed = true,
                PhoneNumber = "+84347561935",
                PhoneNumberConfirmed = true,
                LockoutEnabled = true,
            };
            userList.Add(new SeedUserRole() { User = admin04, RoleId = "2" });
            //// user
            //var user05 = new ApplicationUser()
            //{
            //    Id = "5",
            //    UserName = "Nga",
            //    PasswordHash = password,
            //    Email = "nganguyen@fpt.edu.vn",
            //    EmailConfirmed = true,
            //    PhoneNumber = "+8434657896",
            //    PhoneNumberConfirmed = true,
            //    LockoutEnabled = true,
            //};
            //userList.Add(new SeedUserRole() { User = user05, RoleId = "3" });

            //var user06 = new ApplicationUser()
            //{
            //    Id = "6",
            //    UserName = "Dung",
            //    PasswordHash = password,
            //    Email = "dungchi2000@fpt.edu.vn",
            //    EmailConfirmed = true,
            //    PhoneNumber = "+8434657652",
            //    PhoneNumberConfirmed = true,
            //    LockoutEnabled = true,
            //};
            //userList.Add(new SeedUserRole() { User = user06, RoleId = "3" });

            //var user07 = new ApplicationUser()
            //{
            //    Id = "7",
            //    UserName = "Tinh",
            //    PasswordHash = password,
            //    Email = "chutinh@fpt.edu.vn",
            //    EmailConfirmed = true,
            //    PhoneNumber = "+8434362214",
            //    PhoneNumberConfirmed = true,
            //    LockoutEnabled = true,
            //};
            //userList.Add(new SeedUserRole() { User = user07, RoleId = "3" });

            //var user08 = new ApplicationUser()
            //{
            //    Id = "8",
            //    UserName = "Thanh",
            //    PasswordHash = password,
            //    Email = "thanhnguyen@fpt.edu.vn",
            //    EmailConfirmed = true,
            //    PhoneNumber = "+8434236956",
            //    PhoneNumberConfirmed = true,
            //    LockoutEnabled = true,
            //};
            //userList.Add(new SeedUserRole() { User = user08, RoleId = "3" });

            //var user09 = new ApplicationUser()
            //{
            //    Id = "9",
            //    UserName = "Loi",
            //    PasswordHash = password,
            //    Email = "loichuvan@fpt.edu.vn",
            //    EmailConfirmed = true,
            //    PhoneNumber = "+8434698569",
            //    PhoneNumberConfirmed = true,
            //    LockoutEnabled = true,
            //};
            //userList.Add(new SeedUserRole() { User = user09, RoleId = "3" });

            //var user10 = new ApplicationUser()
            //{
            //    Id = "10",
            //    UserName = "Long",
            //    PasswordHash = password,
            //    Email = "tranlong@fpt.edu.vn",
            //    EmailConfirmed = true,
            //    PhoneNumber = "+8434698236",
            //    PhoneNumberConfirmed = true,
            //    LockoutEnabled = true,
            //};
            //userList.Add(new SeedUserRole() { User = user10, RoleId = "3" });

            //var user11 = new ApplicationUser()
            //{
            //    Id = "11",
            //    UserName = "Thang",
            //    PasswordHash = password,
            //    Email = "Thang@gmail.com",
            //    EmailConfirmed = true,
            //    PhoneNumber = "+84347561955",
            //    PhoneNumberConfirmed = true,
            //    LockoutEnabled = true,
            //};
            //userList.Add(new SeedUserRole() { User = user11, RoleId = "3" });

            //var user12 = new ApplicationUser()
            //{
            //    Id = "12",
            //    UserName = "Manh",
            //    PasswordHash = password,
            //    Email = "manh@gmail.com",
            //    EmailConfirmed = true,
            //    PhoneNumber = "+84347561875",
            //    PhoneNumberConfirmed = true,
            //    LockoutEnabled = true,
            //};
            //userList.Add(new SeedUserRole() { User = user12, RoleId = "3" });

            // seed user + userRole
            foreach (var seedUserRole in userList)
            {
                var roleIdTemp = seedUserRole.RoleId;
                var userTemp = seedUserRole.User;
                var userRoleTemp = new IdentityUserRole();
                userRoleTemp.RoleId = roleIdTemp;
                userRoleTemp.UserId = userTemp.Id;
                userTemp.Roles.Add(userRoleTemp);
                context.Users.AddOrUpdate(x => x.Id, userTemp);
            }

            // Category
            context.Categories.AddOrUpdate(x => x.Id,
                new Category()
                {
                    Id = 1,
                    Name = "T-Shirt",
                    Status = ECategoryStatus.Active,
                    CreatedAt = DateTime.Parse("2019-04-24")
                },

                new Category()
                {
                    Id = 2,
                    Name = "Shirt",
                    Status = ECategoryStatus.Active,
                    CreatedAt = DateTime.Parse("2019-04-24")
                },

                new Category()
                {
                    Id = 3,
                    Name = "Short",
                    Status = ECategoryStatus.Active,
                    CreatedAt = DateTime.Parse("2019-04-24")
                },

                new Category()
                {
                    Id = 4,
                    Name = "Jeans",
                    Status = ECategoryStatus.Active,
                    CreatedAt = DateTime.Parse("2019-04-24")
                }
            );

            //Product
            context.Products.AddOrUpdate(x => x.Id,
                //T-shirt 1
                new Product()
                {
                    Id = 1,
                    Name = "SUPIMA© COTTON CREW NECK SHORT-SLEEVE T-SHIRT",
                    Price = 14.9,
                    Discount = 9.9,
                    Description = "100% Supima® cotton for a high-quality feel. A basic item that goes with any look.",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422990/sub/goods_422990_sub7.jpg",
                    CategoryId = 1,
                    Status = EProductStatus.Active,
                    CreatedAt = DateTime.Parse("2020-04-24")
                },
                //T-shirt 2
                new Product()
                {
                    Id = 2,
                    Name = "DRY V-NECK SHORT-SLEEVE COLOR T-SHIRT",
                    Price = 7.9,
                    Description = "Simple and versatile. Stays dry, giving it a comfortable and dry feeling against the skin.",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427916/sub/goods_427916_sub7.jpg",
                    CategoryId = 1,
                    Status = EProductStatus.Active,
                    CreatedAt = DateTime.Parse("2020-05-24")
                },
                //Shirt 3
                new Product()
                {
                    Id = 3,
                    Name = "EXTRA FINE COTTON SHORT-SLEEVE SHIRT",
                    Price = 29.9,
                    Discount = 19.9,
                    Description = "Made from fine cotton for a soft feel. The surface is soft for a more comfortable feel.",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427315/sub/goods_427315_sub7.jpg",
                    CategoryId = 2,
                    Status = EProductStatus.Active,
                    CreatedAt = DateTime.Parse("2019-10-24")
                },
                //Shirt 4
                new Product()
                {
                    Id = 4,
                    Name = "EXTRA FINE COTTON BROADCLOTH SHORT-SLEEVE SHIRT",
                    Price = 29.9,
                    Description = "Made with fine cotton to reduce wrinkles after washing.",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/426933/sub/goods_426933_sub7.jpg",
                    CategoryId = 2,
                    Status = EProductStatus.Active,
                    CreatedAt = DateTime.Parse("2020-05-10")
                },
                //Short 5
                new Product()
                {
                    Id = 5,
                    Name = "NYLON ACTIVE SHORTS",
                    Price = 29.9,
                    Description = "Both materials and details have a sporty finish. A different take on a stylish piece.",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425150/sub/goods_425150_sub8.jpg",
                    CategoryId = 3,
                    Status = EProductStatus.Active,
                    CreatedAt = DateTime.Parse("2020-03-24")
                },
                //Short 6
                new Product()
                {
                    Id = 6,
                    Name = "ERSEY EASY SHORTS",
                    Price = 19.9,
                    Description = "These relaxed pants are soft and comfortable. Short and easy to wear.",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/424152/sub/goods_424152_sub7.jpg",
                    CategoryId = 3,
                    Status = EProductStatus.Active,
                    CreatedAt = DateTime.Parse("2020-04-15")
                },
                //Jeans 7
                new Product()
                {
                    Id = 7,
                    Name = "EZY ULTRA STRETCH COLOR JEANS",
                    Price = 39.9,
                    Discount = 29.9,
                    Description = "Ultra stretch fabric makes it incredibly comfortable. Refined design and texture.",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422368/sub/goods_422368_sub7.jpg",
                    CategoryId = 4,
                    Status = EProductStatus.Active,
                    CreatedAt = DateTime.Parse("2020-01-24")
                },
                //Jeans 8
                new Product()
                {
                    Id = 8,
                    Name = "ULTRA STRETCH SKINNY FIT JEANS",
                    Price = 49.9,
                    Description = "The slimmest skinny fit of all UNIQLO jeans. It's surprisingly flexible and still comfortable.",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425297/sub/goods_425297_sub7.jpg",
                    CategoryId = 4,
                    Status = EProductStatus.Active,
                    CreatedAt = DateTime.Parse("2019-12-24")
                }
            );

            //Product Details
            context.ProductDetails.AddOrUpdate(x => x.Id,
                //T-shirt 1 
                new ProductDetail()
                {
                    Id = 1,
                    ProductId = 1,
                    Color = "Navy",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422990/item/goods_69_422990.jpg",
                    Quantity = 18,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 2,
                    ProductId = 1,
                    Color = "Navy",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422990/item/goods_69_422990.jpg",
                    Quantity = 10,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 3,
                    ProductId = 1,
                    Color = "Navy",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422990/item/goods_69_422990.jpg",
                    Quantity = 45,
                    Status = EProductStatus.Deleted,
                },
                new ProductDetail()
                {
                    Id = 4,
                    ProductId = 1,
                    Color = "Beige",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422990/item/goods_32_422990.jpg",
                    Quantity = 31,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 5,
                    ProductId = 1,
                    Color = "Beige",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422990/item/goods_32_422990.jpg",
                    Quantity = 21,
                    Status = EProductStatus.Deactive,
                },
                new ProductDetail()
                {
                    Id = 6,
                    ProductId = 1,
                    Color = "Beige",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422990/item/goods_32_422990.jpg?",
                    Quantity = 11,
                    Status = EProductStatus.Active,
                },
                //T-shirt 2
                new ProductDetail()
                {
                    Id = 7,
                    ProductId = 2,
                    Color = "Gray",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427916/item/goods_03_427916.jpg",
                    Quantity = 22,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 8,
                    ProductId = 2,
                    Color = "Gray",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427916/item/goods_03_427916.jpg",
                    Quantity = 32,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 9,
                    ProductId = 2,
                    Color = "Gray",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427916/item/goods_03_427916.jpg",
                    Quantity = 22,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 10,
                    ProductId = 2,
                    Color = "Dark Gray",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427916/item/goods_08_427916.jpg",
                    Quantity = 12,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 11,
                    ProductId = 2,
                    Color = "Dark Gray",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427916/item/goods_08_427916.jpg",
                    Quantity = 34,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 12,
                    ProductId = 2,
                    Color = "Dark Gray",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427916/item/goods_08_427916.jpg",
                    Quantity = 10,
                    Status = EProductStatus.Active,
                },
                //Shirt 3
                new ProductDetail()
                {
                    Id = 13,
                    ProductId = 3,
                    Color = "Yellow",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427315/item/goods_48_427315.jpg",
                    Quantity = 14,
                    Status = EProductStatus.Deactive,
                },
                new ProductDetail()
                {
                    Id = 14,
                    ProductId = 3,
                    Color = "Yellow",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427315/item/goods_48_427315.jpg",
                    Quantity = 10,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 15,
                    ProductId = 3,
                    Color = "Yellow",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427315/item/goods_48_427315.jpg",
                    Quantity = 42,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 16,
                    ProductId = 3,
                    Color = "White",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427315/item/goods_00_427315.jpg",
                    Quantity = 10,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 17,
                    ProductId = 3,
                    Color = "White",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427315/item/goods_00_427315.jpg",
                    Quantity = 10,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 18,
                    ProductId = 3,
                    Color = "White",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/427315/item/goods_00_427315.jpg",
                    Quantity = 35,
                    Status = EProductStatus.Active,
                },
                //Shirt 4
                new ProductDetail()
                {
                    Id = 19,
                    ProductId = 4,
                    Color = "Blue",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/426933/sub/goods_426933_sub4.jpg",
                    Quantity = 25,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 20,
                    ProductId = 4,
                    Color = "Blue",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/426933/sub/goods_426933_sub4.jpg",
                    Quantity = 15,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 21,
                    ProductId = 4,
                    Color = "Blue",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/426933/sub/goods_426933_sub4.jpg",
                    Quantity = 20,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 22,
                    ProductId = 4,
                    Color = "Yellow",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/426933/item/goods_45_426933.jpg",
                    Quantity = 30,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 23,
                    ProductId = 4,
                    Color = "Yellow",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/426933/item/goods_45_426933.jpg",
                    Quantity = 40,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 24,
                    ProductId = 4,
                    Color = "Yellow",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/426933/item/goods_45_426933.jpg",
                    Quantity = 8,
                    Status = EProductStatus.Deleted,
                },
                //Short 5
                new ProductDetail()
                {
                    Id = 25,
                    ProductId = 5,
                    Color = "Gray",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425150/sub/goods_425150_sub3.jpg",
                    Quantity = 10,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 26,
                    ProductId = 5,
                    Color = "Gray",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425150/sub/goods_425150_sub3.jpg",
                    Quantity = 15,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 27,
                    ProductId = 5,
                    Color = "Gray",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425150/sub/goods_425150_sub3.jpg",
                    Quantity = 15,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 28,
                    ProductId = 5,
                    Color = "Green",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425150/item/goods_55_425150.jpg",
                    Quantity = 25,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 29,
                    ProductId = 5,
                    Color = "Green",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425150/item/goods_55_425150.jpg",
                    Quantity = 30,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 30,
                    ProductId = 5,
                    Color = "Green",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425150/item/goods_55_425150.jpg",
                    Quantity = 8,
                    Status = EProductStatus.Active,
                },
                //Short 6
                new ProductDetail()
                {
                    Id = 31,
                    ProductId = 6,
                    Color = "Green",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/424152/item/goods_69_424152.jpg",
                    Quantity = 2,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 32,
                    ProductId = 6,
                    Color = "Green",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/424152/item/goods_69_424152.jpg",
                    Quantity = 30,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 33,
                    ProductId = 6,
                    Color = "Green",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/424152/item/goods_69_424152.jpg",
                    Quantity = 10,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 34,
                    ProductId = 6,
                    Color = "Red",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/424152/item/goods_13_424152.jpg",
                    Quantity = 19,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 35,
                    ProductId = 6,
                    Color = "Red",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/424152/item/goods_13_424152.jpg",
                    Quantity = 22,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 36,
                    ProductId = 6,
                    Color = "Red",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/424152/item/goods_13_424152.jpg",
                    Quantity = 15,
                    Status = EProductStatus.Active,
                },
                //Jeans 7
                new ProductDetail()
                {
                    Id = 37,
                    ProductId = 7,
                    Color = "Blue",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422368/sub/goods_422368_sub3.jpg",
                    Quantity = 10,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 38,
                    ProductId = 7,
                    Color = "Blue",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422368/sub/goods_422368_sub3.jpg",
                    Quantity = 10,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 39,
                    ProductId = 7,
                    Color = "Blue",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422368/sub/goods_422368_sub3.jpg",
                    Quantity = 10,
                    Status = EProductStatus.Deleted,
                },
                new ProductDetail()
                {
                    Id = 40,
                    ProductId = 7,
                    Color = "Olive",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422368/item/goods_56_422368.jpg",
                    Quantity = 10,
                    Status = EProductStatus.Deactive,
                },
                new ProductDetail()
                {
                    Id = 41,
                    ProductId = 7,
                    Color = "Olive",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422368/item/goods_56_422368.jpg",
                    Quantity = 18,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 42,
                    ProductId = 7,
                    Color = "Olive",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/422368/item/goods_56_422368.jpg",
                    Quantity = 15,
                    Status = EProductStatus.Active,
                },
                //Jeans 8
                new ProductDetail()
                {
                    Id = 43,
                    ProductId = 8,
                    Color = "Blue",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425297/sub/goods_425297_sub3.jpg",
                    Quantity = 0,
                    Status = EProductStatus.Deactive,
                },
                new ProductDetail()
                {
                    Id = 44,
                    ProductId = 8,
                    Color = "Blue",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425297/sub/goods_425297_sub3.jpg",
                    Quantity = 5,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 45,
                    ProductId = 8,
                    Color = "Blue",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425297/sub/goods_425297_sub3.jpg",
                    Quantity = 20,
                    Status = EProductStatus.Active,
                },
                new ProductDetail()
                {
                    Id = 46,
                    ProductId = 8,
                    Color = "Dark Gray",
                    Size = "S",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425297/item/goods_08_425297.jpg",
                    Quantity = 0,
                    Status = EProductStatus.Deleted,
                },
                new ProductDetail()
                {
                    Id = 47,
                    ProductId = 8,
                    Color = "Dark Gray",
                    Size = "M",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425297/item/goods_08_425297.jpg",
                    Quantity = 8,
                    Status = EProductStatus.Deactive,
                },
                new ProductDetail()
                {
                    Id = 48,
                    ProductId = 8,
                    Color = "Dark Gray",
                    Size = "L",
                    Thumbnails = "https://image.uniqlo.com/UQ/ST3/WesternCommon/imagesgoods/425297/item/goods_08_425297.jpg",
                    Quantity = 10,
                    Status = EProductStatus.Active,
                }
            );

            //Discount
            context.Discounts.AddOrUpdate(x => x.Id,
                new Discount()
                {
                    Code = "ALISALE001",
                    Value = 0.2,
                    ExprirationDate = DateTime.Parse("2021-10-24"),
                    MinTotal = 100,
                    UseTime = 1,
                    Status = EDiscountStatus.Active,
                    CreatedAt = DateTime.Parse("2020-04-24")
                },
                new Discount()
                {
                    Code = "ALISALE002",
                    Value = 0.1,
                    ExprirationDate = DateTime.Parse("2021-10-24"),
                    MinTotal = 50,
                    UseTime = 10,
                    Status = EDiscountStatus.Active,
                    CreatedAt = DateTime.Parse("2020-04-24")
                }
            );

            //Order01
            var order01 = new Order()
            {
                CustomerName = "Matt Addie",
                CustomerPhone = "(423) 610-3161",
                CustomerEmail = "letter.japan@gmail.com",
                CustomerAddress = "777 Brockton Avenue, Abington MA 2351",
                PaymentMethod = EPaymentMethod.Cash,
                TotalPrice = 25.7,
                Status = EOrderStatus.Delivered,
                CreatedAt = DateTime.Parse("2020-01-24")
            };

            var orderDetail01 = new OrderDetail()
            {
                OrderId = 1,
                ProductDetailId = 1,
                UnitPrice = 14.9,
                Discount = 9.9,
                Quantity = 1,
            };

            var orderDetail02 = new OrderDetail()
            {
                OrderId = 1,
                ProductDetailId = 7,
                UnitPrice = 7.9,
                //Discount = 9.9,
                Quantity = 2,
            };

            order01.AddOrderDetail(orderDetail01);
            order01.AddOrderDetail(orderDetail02);
            context.Orders.AddOrUpdate(order01);

            //Order02
            var order02 = new Order()
            {
                CustomerName = "Allen Quimby",
                CustomerPhone = "(739) 261-3110",
                CustomerEmail = "allen@gmail.com",
                CustomerAddress = "30 Memorial Drive, Avon MA 2322",
                PaymentMethod = EPaymentMethod.Paypal,
                TotalPrice = 209.3,
                Status = EOrderStatus.Delivered,
                CreatedAt = DateTime.Parse("2020-01-15")
            };

            var orderDetail03 = new OrderDetail()
            {
                OrderId = 2,
                ProductDetailId = 30,
                UnitPrice = 29.9,
                //Discount = 9.9,
                Quantity = 3,
            };

            var orderDetail04 = new OrderDetail()
            {
                OrderId = 2,
                ProductDetailId = 25,
                UnitPrice = 29.9,
                //Discount = 9.9,
                Quantity = 4,
            };

            order02.AddOrderDetail(orderDetail03);
            order02.AddOrderDetail(orderDetail04);
            context.Orders.AddOrUpdate(order02);

            //Order03
            var order03 = new Order()
            {
                CustomerName = "Weldon Ries",
                CustomerPhone = "(314) 345-9898",
                CustomerEmail = "weldon@gmail.com",
                CustomerAddress = "250 Hartford Avenue, Bellingham MA 2019",
                PaymentMethod = EPaymentMethod.Cash,
                TotalPrice = 139.6,
                Status = EOrderStatus.Delivered,
                CreatedAt = DateTime.Parse("2020-02-24")
            };

            var orderDetail05 = new OrderDetail()
            {
                OrderId = 3,
                ProductDetailId = 42,
                UnitPrice = 39.9,
                Discount = 29.9,
                Quantity = 3,
            };

            var orderDetail06 = new OrderDetail()
            {
                OrderId = 3,
                ProductDetailId = 45,
                UnitPrice = 49.9,
                //Discount = 9.9,
                Quantity = 1,
            };

            order03.AddOrderDetail(orderDetail05);
            order03.AddOrderDetail(orderDetail06);
            context.Orders.AddOrUpdate(order03);

            //Order04
            var order04 = new Order()
            {
                CustomerName = "Cary Mcmurtrie",
                CustomerPhone = "(797) 740-3175",
                CustomerEmail = "cary@gmail.com",
                CustomerAddress = "66-4 Parkhurst Rd, Chelmsford MA 1824",
                PaymentMethod = EPaymentMethod.Cash,
                TotalPrice = 45.7,
                Status = EOrderStatus.Delivered,
                CreatedAt = DateTime.Parse("2020-02-02")
            };

            var orderDetail07 = new OrderDetail()
            {
                OrderId = 4,
                ProductDetailId = 12,
                UnitPrice = 7.9,
                //Discount = 29.9,
                Quantity = 2,
            };

            var orderDetail08 = new OrderDetail()
            {
                OrderId = 4,
                ProductDetailId = 20,
                UnitPrice = 29.9,
                //Discount = 9.9,
                Quantity = 1,
            };

            order04.AddOrderDetail(orderDetail07);
            order04.AddOrderDetail(orderDetail08);
            context.Orders.AddOrUpdate(order04);

            //Order05
            var order05 = new Order()
            {
                CustomerName = "Wade Coy",
                CustomerPhone = "(696) 658-5886",
                CustomerEmail = "wade@gmail.com",
                CustomerAddress = "591 Memorial Dr, Chicopee MA 1020",
                PaymentMethod = EPaymentMethod.Cash,
                TotalPrice = 79.6,
                Status = EOrderStatus.Delivered,
                CreatedAt = DateTime.Parse("2020-02-19")
            };

            var orderDetail09 = new OrderDetail()
            {
                OrderId = 5,
                ProductDetailId = 35,
                UnitPrice = 19.9,
                //Discount = 29.9,
                Quantity = 2,
            };

            var orderDetail10 = new OrderDetail()
            {
                OrderId = 5,
                ProductDetailId = 15,
                UnitPrice = 29.9,
                Discount = 19.9,
                Quantity = 2,
            };

            order05.AddOrderDetail(orderDetail09);
            order05.AddOrderDetail(orderDetail10);
            context.Orders.AddOrUpdate(order05);

            //Order06
            var order06 = new Order()
            {
                CustomerName = "Winfred Kitamura",
                CustomerPhone = "(544) 926-3679",
                CustomerEmail = "winfred@gmail.com",
                CustomerAddress = "55 Brooksby Village Way, Danvers MA 1923",
                PaymentMethod = EPaymentMethod.Cash,
                TotalPrice = 169.5,
                Status = EOrderStatus.Delivered,
                CreatedAt = DateTime.Parse("2020-03-24")
            };

            var orderDetail11 = new OrderDetail()
            {
                OrderId = 6,
                ProductDetailId = 24,
                UnitPrice = 29.9,
                //Discount = 29.9,
                Quantity = 4,
            };

            var orderDetail12 = new OrderDetail()
            {
                OrderId = 6,
                ProductDetailId = 43,
                UnitPrice = 49.9,
                //Discount = 19.9,
                Quantity = 1,
            };

            order06.AddOrderDetail(orderDetail11);
            order06.AddOrderDetail(orderDetail12);
            context.Orders.AddOrUpdate(order06);

            //Order07
            var order07 = new Order()
            {
                CustomerName = "Winfred Kitamura",
                CustomerPhone = "(544) 926-3679",
                CustomerEmail = "winfred@gmail.com",
                CustomerAddress = "55 Brooksby Village Way, Danvers MA 1923",
                PaymentMethod = EPaymentMethod.Cash,
                TotalPrice = 169.5,
                Status = EOrderStatus.Delivered,
                CreatedAt = DateTime.Parse("2020-03-16")
            };

            var orderDetail13 = new OrderDetail()
            {
                OrderId = 7,
                ProductDetailId = 24,
                UnitPrice = 29.9,
                //Discount = 29.9,
                Quantity = 4,
            };

            var orderDetail14 = new OrderDetail()
            {
                OrderId = 7,
                ProductDetailId = 43,
                UnitPrice = 49.9,
                //Discount = 19.9,
                Quantity = 1,
            };

            order07.AddOrderDetail(orderDetail13);
            order07.AddOrderDetail(orderDetail14);
            context.Orders.AddOrUpdate(order07);

            //Order08
            var order08 = new Order()
            {
                CustomerName = "Winfred Kitamura",
                CustomerPhone = "(544) 926-3679",
                CustomerEmail = "winfred@gmail.com",
                CustomerAddress = "55 Brooksby Village Way, Danvers MA 1923",
                PaymentMethod = EPaymentMethod.Cash,
                TotalPrice = 169.5,
                Status = EOrderStatus.Delivered,
                CreatedAt = DateTime.Parse("2020-04-24")
            };

            var orderDetail15 = new OrderDetail()
            {
                OrderId = 8,
                ProductDetailId = 24,
                UnitPrice = 29.9,
                //Discount = 29.9,
                Quantity = 4,
            };

            var orderDetail16 = new OrderDetail()
            {
                OrderId = 8,
                ProductDetailId = 43,
                UnitPrice = 49.9,
                //Discount = 19.9,
                Quantity = 1,
            };

            order08.AddOrderDetail(orderDetail15);
            order08.AddOrderDetail(orderDetail16);
            context.Orders.AddOrUpdate(order08);

            //Order09
            var order09 = new Order()
            {
                CustomerName = "Winfred Kitamura",
                CustomerPhone = "(544) 926-3679",
                CustomerEmail = "winfred@gmail.com",
                CustomerAddress = "55 Brooksby Village Way, Danvers MA 1923",
                PaymentMethod = EPaymentMethod.Cash,
                TotalPrice = 169.5,
                Status = EOrderStatus.Delivered,
                CreatedAt = DateTime.Parse("2020-04-04")
            };

            var orderDetail17 = new OrderDetail()
            {
                OrderId = 9,
                ProductDetailId = 24,
                UnitPrice = 29.9,
                //Discount = 29.9,
                Quantity = 4,
            };

            var orderDetail18 = new OrderDetail()
            {
                OrderId = 9,
                ProductDetailId = 43,
                UnitPrice = 49.9,
                //Discount = 19.9,
                Quantity = 1,
            };

            order08.AddOrderDetail(orderDetail15);
            order08.AddOrderDetail(orderDetail16);
            context.Orders.AddOrUpdate(order08);

            //Order10
            var order10 = new Order()
            {
                CustomerName = "Winfred Kitamura",
                CustomerPhone = "(544) 926-3679",
                CustomerEmail = "winfred@gmail.com",
                CustomerAddress = "55 Brooksby Village Way, Danvers MA 1923",
                PaymentMethod = EPaymentMethod.Cash,
                TotalPrice = 169.5,
                Status = EOrderStatus.Delivered,
                CreatedAt = DateTime.Parse("2020-05-19")
            };

            var orderDetail19 = new OrderDetail()
            {
                OrderId = 10,
                ProductDetailId = 24,
                UnitPrice = 29.9,
                //Discount = 29.9,
                Quantity = 4,
            };

            var orderDetail20 = new OrderDetail()
            {
                OrderId = 10,
                ProductDetailId = 43,
                UnitPrice = 49.9,
                //Discount = 19.9,
                Quantity = 1,
            };

            order10.AddOrderDetail(orderDetail19);
            order10.AddOrderDetail(orderDetail20);
            context.Orders.AddOrUpdate(order10);
        }
    }
}
