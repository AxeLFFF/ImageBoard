using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ImageBoard.Models
{
    public class Thread
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreationDateTime { get; set; } = new DateTime();

        public virtual List<Post> Posts { get; set; }

        public int BoardId { get; set; }
        public virtual Board Board { get; set; }
    }
}
