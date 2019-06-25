using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ImageBoard.Models;

namespace ImageBoard.Controllers
{
    public class HomeController : BoardBaseController
    {
        private BoardDBContext _boardDB = new BoardDBContext();

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            IEnumerable<Board> boards = _boardDB.Boards.ToArray();
            return View(boards);
        }

        [HttpGet]
        [Route("{board_name}")]
        public IActionResult GetBoard(string board_name)
        {
            Board board = _boardDB.Boards.Where(b => b.ShortName == board_name).FirstOrDefault();
            if (board == null)
            {
                return BadRequest($"Board '{board_name}' is not found");
            }
            else return View(board);
        }

        [HttpGet]
        [Route("{board}/{thread_id:int}")]
        public IActionResult GetThread(string board, int thread_id)
        {
            Thread thread = _boardDB.Threads.Where(t => t.Board.ShortName == board && t.Id == thread_id).FirstOrDefault();
            if(thread == null)
            {
                return BadRequest($"Thread {thread_id} is not found");
            }
            return View(thread);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
