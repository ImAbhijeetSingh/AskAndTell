using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskAndTell.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }
    }
}