using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ImageBoard.Models;

namespace ImageBoard.Controllers
{
    public abstract class BoardBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewData["BoardsViewModel"] = new BoardsViewModel();

            base.OnActionExecuting(context);
        }
    }
}