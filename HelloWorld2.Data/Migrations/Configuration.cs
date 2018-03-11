namespace HelloWorld2.Data.Migrations
{
    using HelloWorld2.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HelloWorld2.Data.HelloWorldDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HelloWorld2.Data.HelloWorldDb context)
        {
            //
            // Projects
            context.Projects.AddOrUpdate(
                p => p.Name,
                new Project
                {
                    Name = "Hello Project",
                    Posts = new List<Post> {
                            new Post { 
                                Author = "Ernesto",
                                Title = "Hello World",
                                Content = "Hello and welcome to my site. This is my first post of my first project for this website, and the project is the website itself. \r\n\r\nI wanted to create this website as kind of a project repository where I openly work on personal projects and get feedback from anyone interested in taking a look. So when I decide to work on personal project I will create an entry here, each project has one or more posts associated with it which are basically units of work towards completion of the project.\r\nSo about this website, technically. This website is written with C# and the ASP.NET MVC framework. The front-end is done with javascript and jQuery. The back-end consists of a SQLCE database and the Entity Framework ORM framework for communicating with the database. You can actually find the source code for this website as well as most of my projects here in my github repo at https://github.com/epavon/ \r\n\r\nA bit about me. As you might have guessed I'm software developer by trade. I'm happily married and I'm also a major tech enthusiast who loves technology and science. I also enjoy playing video games when I have the time. So with that bit of background, the projects I will be tackling here will mostly focused on new technologies. I like coding in pretty much any language that fits the task at hand but I do have my preferences. I've been using the Microsoft stack long enough to be comfortable in it and enjoy it, especially the C# language. However, I am also a bit of a control freak so that means I do not like working with some MS technologies that try to do too much for you (webforms.. ). Most of my career I spent using C++ and although I've lost touch with this language lately I still consider it my favorite for the balance between usability and control that it provides. I've been delving in functional programming lately and I love it, as a result I've actually been trying to make my C# code more functional whereever it makes sense to do so. I've played with a long and wide array of technologies in my studies and professional career and have come to appreciate the underlying principles to software engineering beyond any one specific technology. With that in mind, and as a responsible developer I like using Design Patterns when it makes sense. Design patterns are a great tool to communicate with other developers and tackle establish problems with well defined and tested solutions. However, in my projects it will be just me most of the time and depending on the size of the project I may not follow established patterns. In that note, I don't expect to have the best solution or even working solutions at times and as such I'm open and welcome suggestions and ideas. I expect to fail and that's totally fine, this is my playground and luckily I can't fire myself so it's safe enough.\r\n\r\nTo anyone who's read this far, thank you for taking interest in my website and welcome aboard. If you still want to see some more of old work, you can check my old blog which I created during my college years, it lives here http://pavone87.blogspot.com/" , 
                                Date = DateTime.Now, 
                                Comments = new List<Comment> {  
                                           new Comment { Author="Ernesto", Content="Hello", Date = DateTime.Today }
                                }  
                            },
                            
                     },
                    Description = "This project consists of the making of this website.",
                    Progress = "In Progress"
                },
                new Project
                {
                    Name = "MonoGame Project",
                    Posts = new List<Post>
                    {
                        new Post {
                            Author = "Ernesto",
                            Title = "The MonoGame Intro",
                            Content = "This will be a simple 2D action game I've wanted to write for a while. This will be done using C# and the MonoGame framework.",
                            Date = DateTime.Now,
                            Comments = new List<Comment> {

                            }
                        }
                    },
                    Description = "This is a game I want to create",
                    Progress = "Starting"
                }

            );


            //
            // About

            context.Schools.AddOrUpdate(
                    s => s.SchoolName,
                    new School
                    {
                        SchoolName = "UNLV",
                        Degrees = "Bachelors of Science in Computer Science,Bachelors of Science in Accounting,Minor in Mathematics",
                        GPA = "3.6",
                        From = new DateTime(2005, 1, 21).Date,
                        To = new DateTime(2012, 5, 14).Date,
                    }
              );

            context.Works.AddOrUpdate(
                w => w.WorkName,
                new Work
                {
                    WorkName = "Bally Technologies",
                    WorkTitle = "Software Engineer",
                    From = new DateTime(2012, 5, 21).Date,
                    To = new DateTime(2014, 11, 14).Date,
                    Description = "At Bally Technologies I worked on automating the build and release process of various distinct software products. I worked in a fast-paced environment with a wide array of technologies including C#, ASP.NET, Bash, Python, Batch, Powershell, AWK among others."
                },
                new Work
                {
                    WorkName = "Credit One Bank",
                    WorkTitle = "Business System Engineer",
                    From = new DateTime(2014, 11, 17).Date,
                    Description = "At Credit One I work in all aspects of the software development cycle from design to implementation.",
                }
             );

            context.Skills.AddOrUpdate(
                s => s.SkillName,
                new Skill { SkillName = "C#" },
                new Skill { SkillName = "ASP.NET MVC and WebForms" },
                new Skill { SkillName = "Javascript and jQuery" },
                new Skill { SkillName = "CSS" },
                new Skill { SkillName = "C++" },
                new Skill { SkillName = "Nodejs" },
                new Skill { SkillName = "Java" },
                new Skill { SkillName = "AngularJS" }
              );

            context.Abouts.AddOrUpdate(
                a => a.AboutId,
                new About { AboutId = 1, Description = "I am a technology enthusiast and software engineer. I love writing good-quality software with emphasis on reliability, robustness, and maintanability.\r\nI specialize in writing web application using the .NET stack, but I'm also very familiar and throughouly enjoy writing front-end applications using Javascript." }
                );

            context.Creations.AddOrUpdate(
                c => c.CreationName,
                new Creation
                {
                    CreationName = "Web Applications"
                },
                new Creation
                {
                    CreationName = "Desktop Applications"
                },
                new Creation
                {
                    CreationName = "Mobile Applications"
                },
                new Creation
                {
                    CreationName = "Games"
                },
                new Creation
                {
                    CreationName = "Systems Automation"
                }

              );

            context.Websites.AddOrUpdate(
                w => w.Name,
                new Website
                {
                    Description = "This little corner in the net is where I share my love and enthusiasm for technology. This is a project-driven website and I hope to get different views and critics on my development approach. Every post I make here is related to some project I'll be working on. "
                });

            
        }
    }
}
