using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBoard.Models
{
    public class Thread
    {
        public int Id { get; set; }

        public DateTime CreationDateTime { get; set; } = new DateTime();

        public List<Post> Posts { get; set; } = new List<Post>();

        public int? BoardId { get; set; }
        public Board Board { get; set; }
    }
}
