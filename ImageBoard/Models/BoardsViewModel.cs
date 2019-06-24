using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageBoard.Models;

namespace ImageBoard.Models
{
    public class BoardsViewModel
    {
        public IEnumerable<Board> Boards;

        public BoardsViewModel()
        {
            BoardDBContext boardDB = new BoardDBContext();
            Boards = boardDB.Boards;
        }
    }
}
