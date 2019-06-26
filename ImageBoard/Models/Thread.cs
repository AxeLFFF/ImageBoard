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

        public virtual List<Post> Posts { get; set; }

        public int? BoardId { get; set; }
        public virtual Board Board { get; set; }
    }
}
