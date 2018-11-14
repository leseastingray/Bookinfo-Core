﻿using GoodBookNook.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodBookNook.Repositories
{
    public class SeedData
    {
        public static void Seed(IServiceProvider services)

        {
            AppDbContext context = services.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();

            if (!context.Books.Any())
            {
                Author author = new Author { Name = "Samuel Shellabarger" };
                context.Authors.Add(author);

                User user = new User { Name = "Walter Cronkite" };
                context.Users.Add(user);

                Review review = new Review
                {
                    ReviewText = "Great book, a must read!",
                    Reviewer = user
                };
                context.Reviews.Add(review);

                Book book = new Book
                {
                    Title = "Prince of Foxes",
                    PubDate = DateTime.Parse("1/1/1947")
                };
                book.Authors.Add(author);
                book.Reviews.Add(review);
                context.Books.Add(book);

                context.SaveChanges(); // save all the data
            }
        }
    }
}
