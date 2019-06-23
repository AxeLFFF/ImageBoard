﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBoard.Models
{
    public class Board
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string IconRef { get; set; }

        public List<Thread> Threads { get; set; } = new List<Thread>();
    }
}