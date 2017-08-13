using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EntityFrameworkUsingFluentAPI.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkUsingFluentAPI.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFrameworkUsingFluentAPI.PlutoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            #region Add Tags

            var tags = new Dictionary<string, Tag>
            {
                {"c#", new Tag{Id = 1, Name = "c#"}},
                {"angularjs", new Tag{Id = 2, Name = "angularjs"}},
                {"javascript", new Tag{Id = 3, Name = "javascript"}},
                {"nodejs", new Tag{Id = 4, Name = "nodejs"}},
                {"oop", new Tag{Id = 5, Name = "oop"}},
                {"linq", new Tag{Id = 6, Name = "linq"}}
            };

            foreach (var tag in tags.Values)
                context.Tags.AddOrUpdate(t => t.Id, tag);
            #endregion

            #region Add Authors



            var authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    Name = "Jason Pacia",
                    Courses = new List<Course>()
                },
                new Author
                {
                    Id = 2,
                    Name = "Mary Cris Yamuyam",
                    Courses = new List<Course>()
                },
                new Author
                {
                    Id = 3,
                    Name = "Roceny Dalmacio",
                    Courses = new List<Course>()
                },
                new Author
                {
                    Id = 4,
                    Name = "Mark Cabreros",
                    Courses = new List<Course>()
                }
            };

            foreach (var author in authors)
                context.Authors.AddOrUpdate(a => a.Id, author);
            #endregion

            #region Add Courses
            var courses = new List<Course>
            {
                new Course
                {
                    Id = 1,
                    Name = "C# Basics",
                    Author = authors[0],
                    FullPrice = 100,
                    Description = "C# Course for Beginners",
                    Level = 1,
                    Tags = new Collection<Tag>
                    {
                        tags["c#"]
                    }
                },
                new Course
                {
                    Id = 2,
                    Name = "C# Intermediate",
                    Author = authors[0],
                    FullPrice = 150,
                    Description = "C# Course for Intermediate Developer",
                    Level = 2,
                    Tags = new Collection<Tag>
                    {
                        tags["c#"]
                    }
                },
                new Course
                {
                    Id = 3,
                    Name = "C# Advanced",
                    Author = authors[0],
                    FullPrice = 250,
                    Description = "Advanced Topics on C#",
                    Level = 1,
                    Tags = new Collection<Tag>
                    {
                        tags["c#"]
                    }
                }

            };
            #endregion
        }
    }
}
