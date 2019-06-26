using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var boards = _boardDB.Boards.ToArray();
            return View(boards);
        }

        [HttpGet]
        [Route("{board_name}")]
        public IActionResult GetBoard(string board_name)
        {
            var board = _boardDB.Boards.Where(b => b.ShortName == board_name).FirstOrDefault();
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
            var thread = _boardDB.Threads.Where(t => t.Id == thread_id).FirstOrDefault();
            if(thread == null)
            {
                return BadRequest($"Thread {thread_id} is not found");
            }
            ViewData["SenderName"] = "Анонимус";
            return View(thread);
        }

        [HttpPost]
        [Route("{board}/{thread_id:int}")]
        public IActionResult GetThread(Post post)
        {
            var thread = _boardDB.Threads.Where(t => t.Id == post.ThreadId).FirstOrDefault();
            var p = post;
            p.PostDateTime = DateTime.Now;
            p.Thread = thread;
            var result = _boardDB.Posts.Add(p);
            _boardDB.SaveChanges();
            var s = _boardDB.Boards.Where(b => b.Id == thread.BoardId).FirstOrDefault().ShortName;
            return LocalRedirect($"~/{s}/{p.ThreadId}#log_bottom");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
