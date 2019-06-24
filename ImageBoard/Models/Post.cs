using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ImageBoard.Models
{
    public class Post
    {
        public int Id { get; set; }

        public DateTime PostDateTime { get; set; } = new DateTime();

        [Required]
        public string Text { get; set; }

        public string ContentRef { get; set; }

        public string SenderName { get; set; } = "Anonymous";

        public bool IsOP { get; set; }

        public bool IsSage { get; set; }

        public int? ThreadId { get; set; }
        public Thread Thread { get; set; }
    }
}
