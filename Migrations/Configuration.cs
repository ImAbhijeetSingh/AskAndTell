namespace AskAndTell.Migrations
{
    using AskAndTell.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AskAndTell.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AskAndTell.Models.ApplicationDbContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            ApplicationUser Admin = new ApplicationUser { Id = "b9c2deb4-f060-4f72-b30f-3136200199b0", Email = "admin@at.com", UserName = "admin@at.com", PasswordHash = "APS8TsYIDvM996DTkPgJDXI498paj4jSSUaGQEjwvYugT68xazctzQjnhT/f4jy6NA==", SecurityStamp = "e0544ac2-fd43-4346-93ab-da6edc6db442", };
            ApplicationUser User1 = new ApplicationUser { Id = "b9c2deb4-f060-4f72-b30f-3136200199b1", Email = "user1@at.com", UserName = "user1@at.com", PasswordHash = "APS8TsYIDvM996DTkPgJDXI498paj4jSSUaGQEjwvYugT68xazctzQjnhT/f4jy6NA==", SecurityStamp="e0544ac2-fd43-4346-93ab-da6edc6db442", Reputation =130 };
            ApplicationUser User2 = new ApplicationUser { Id = "b9c2deb4-f060-4f72-b30f-3136200199b2", Email = "user2@at.com", UserName = "user2@at.com", PasswordHash = "APS8TsYIDvM996DTkPgJDXI498paj4jSSUaGQEjwvYugT68xazctzQjnhT/f4jy6NA==", SecurityStamp = "e0544ac2-fd43-4346-93ab-da6edc6db442", Reputation = 120 };
            ApplicationUser User3 = new ApplicationUser { Id = "b9c2deb4-f060-4f72-b30f-3136200199b3", Email = "user3@at.com", UserName = "user3@at.com", PasswordHash = "APS8TsYIDvM996DTkPgJDXI498paj4jSSUaGQEjwvYugT68xazctzQjnhT/f4jy6NA==", SecurityStamp = "e0544ac2-fd43-4346-93ab-da6edc6db442", Reputation = 90 };


            context.Users.AddOrUpdate(u => u.Email, User1);
            context.Users.AddOrUpdate(u => u.Email, User2);
            context.Users.AddOrUpdate(u => u.Email, User3);
            context.Users.AddOrUpdate(u => u.Email, Admin);
            context.SaveChanges();

            Tag tag1 = new Tag { TagName = "HTML" };
            Tag tag2 = new Tag { TagName = "CSS" };
            Tag tag3 = new Tag { TagName = "JavaScript" };
            Tag tag4 = new Tag { TagName = "ReactJS" };
            Tag tag5 = new Tag { TagName = "C#" };
            Tag tag6 = new Tag { TagName = "SQL" };
            Tag tag7 = new Tag { TagName = "PHP" };
            Tag tag8 = new Tag { TagName = "LINQ" };

            context.Tags.AddOrUpdate(t => t.TagName, tag1);
            context.Tags.AddOrUpdate(t => t.TagName, tag2);
            context.Tags.AddOrUpdate(t => t.TagName, tag3);
            context.Tags.AddOrUpdate(t => t.TagName, tag4);
            context.Tags.AddOrUpdate(t => t.TagName, tag5);
            context.Tags.AddOrUpdate(t => t.TagName, tag6);
            context.Tags.AddOrUpdate(t => t.TagName, tag7);
            context.Tags.AddOrUpdate(t => t.TagName, tag8);
            context.SaveChanges();

            Question question1 = new Question { Id = 1, Title = "title1", Body = "body1", DateTime = DateTime.Today.AddDays(-7), Votes = 7, UserId = User1.Id, Tags = {tag1, tag2, tag3 } };
            Question question2 = new Question { Id = 2, Title = "title2", Body = "body2", DateTime = DateTime.Today.AddDays(-6), Votes = 8, UserId = User2.Id, Tags = { tag1, tag2, tag4 } };
            Question question3 = new Question { Id = 3, Title = "title3", Body = "body3", DateTime = DateTime.Today.AddDays(-5), Votes = 10, UserId = User3.Id, Tags = { tag4, tag5, tag6 } };
            Question question4 = new Question { Id = 4, Title = "title4", Body = "body4", DateTime = DateTime.Today.AddDays(-4), Votes = 12, UserId = User2.Id, Tags = { tag1, tag2, tag7 } };
            Question question5 = new Question { Id = 5, Title = "title5", Body = "body5", DateTime = DateTime.Today.AddDays(-3), Votes = 15, UserId = User3.Id, Tags = { tag1, tag2, tag8 } };
            Question question6 = new Question { Id = 6, Title = "title6", Body = "body6", DateTime = DateTime.Today.AddDays(-2), Votes = 18, UserId = User3.Id, Tags = { tag1, tag4, tag3 } };
            Question question7 = new Question { Id = 7, Title = "title7", Body = "body7", DateTime = DateTime.Today.AddDays(-1), Votes = 20, UserId = User1.Id, Tags = { tag1, tag6, tag3 } };

            context.Questions.AddOrUpdate(q => q.Id, question1);
            context.Questions.AddOrUpdate(q => q.Id, question2);
            context.Questions.AddOrUpdate(q => q.Id, question3);
            context.Questions.AddOrUpdate(q => q.Id, question4);
            context.Questions.AddOrUpdate(q => q.Id, question5);
            context.Questions.AddOrUpdate(q => q.Id, question6);
            context.Questions.AddOrUpdate(q => q.Id, question7);
            context.SaveChanges();

            Answer answer1 = new Answer { Id = 1, Body = "Answer body 1", IsAccepted = true, Votes = 10, QuestionId = 1, UserId = User2.Id };
            Answer answer2 = new Answer { Id = 2, Body = "Answer body 2", IsAccepted = true, Votes = 6, QuestionId = 1, UserId = User3.Id };
            Answer answer3 = new Answer { Id = 3, Body = "Answer body 3", IsAccepted = true, Votes = 12, QuestionId = 2, UserId = User3.Id };
            Answer answer4 = new Answer { Id = 4, Body = "Answer body 4", IsAccepted = true, Votes = 8, QuestionId = 2, UserId = User1.Id };
            Answer answer5 = new Answer { Id = 5, Body = "Answer body 5", IsAccepted = true, Votes = 16, QuestionId = 3, UserId = User1.Id };
            Answer answer6 = new Answer { Id = 6, Body = "Answer body 6", IsAccepted = true, Votes = 14, QuestionId = 3, UserId = User2.Id };

            context.Answers.AddOrUpdate(a => a.Id, answer1);
            context.Answers.AddOrUpdate(a => a.Id, answer2);
            context.Answers.AddOrUpdate(a => a.Id, answer3);
            context.Answers.AddOrUpdate(a => a.Id, answer4);
            context.Answers.AddOrUpdate(a => a.Id, answer5);
            context.Answers.AddOrUpdate(a => a.Id, answer6);
            context.SaveChanges();

            Comment comment1 = new Comment { Id = 1, QuestionId = 1, AnswerId = null, Body = "comment 1", UserId = User2.Id };
            Comment comment2 = new Comment { Id = 2, QuestionId = 1, AnswerId = null, Body = "comment 2", UserId = User3.Id };
            Comment comment3 = new Comment { Id = 3, QuestionId = 2, AnswerId = null, Body = "comment 3", UserId = User3.Id };
            Comment comment4 = new Comment { Id = 4, QuestionId = 2, AnswerId = null, Body = "comment 4", UserId = User1.Id };
            Comment comment5 = new Comment { Id = 5, QuestionId = 3, AnswerId = null, Body = "comment 5", UserId = User2.Id };
            Comment comment6 = new Comment { Id = 6, QuestionId = 3, AnswerId = null, Body = "comment 6", UserId = User2.Id };
            Comment comment7 = new Comment { Id = 7, QuestionId = null, AnswerId = 1, Body = "comment 7", UserId = User2.Id };
            Comment comment8 = new Comment { Id = 8, QuestionId = null, AnswerId = 1, Body = "comment 8", UserId = User3.Id };
            Comment comment9 = new Comment { Id = 9, QuestionId = null, AnswerId = 4, Body = "comment 9", UserId = User1.Id };
            Comment comment10 = new Comment { Id = 10, QuestionId = null, AnswerId = 4, Body = "comment 10", UserId = User3.Id };
            Comment comment11 = new Comment { Id = 11, QuestionId = null, AnswerId = 5, Body = "comment 11", UserId = User2.Id };
            Comment comment12 = new Comment { Id = 12, QuestionId = null, AnswerId = 5, Body = "comment 12", UserId = User1.Id };


            context.Comments.AddOrUpdate(c => c.Id, comment1);
            context.Comments.AddOrUpdate(c => c.Id, comment2);
            context.Comments.AddOrUpdate(c => c.Id, comment3);
            context.Comments.AddOrUpdate(c => c.Id, comment4);
            context.Comments.AddOrUpdate(c => c.Id, comment5);
            context.Comments.AddOrUpdate(c => c.Id, comment6);
            context.Comments.AddOrUpdate(c => c.Id, comment7);
            context.Comments.AddOrUpdate(c => c.Id, comment8);
            context.Comments.AddOrUpdate(c => c.Id, comment9);
            context.Comments.AddOrUpdate(c => c.Id, comment10);
            context.Comments.AddOrUpdate(c => c.Id, comment11);
            context.Comments.AddOrUpdate(c => c.Id, comment12);
            context.SaveChanges();
        }
    }
}
