using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AskAndTell.Models
{
    public class Question
    {
        public Question()
        {
            this.Tags = new HashSet<Tag>();
            this.Answers = new HashSet<Answer>();
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public DateTime DateTime { get; set; }
        public int Votes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public string  UserId { get; set; }
    }
}