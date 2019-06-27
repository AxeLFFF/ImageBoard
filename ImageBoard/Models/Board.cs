using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ImageBoard.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string IconRef { get; set; }

        public virtual List<Thread> Threads { get; set; }
    }
}
