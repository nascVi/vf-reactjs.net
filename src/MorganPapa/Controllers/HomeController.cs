﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactDemo.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MorganPapa.Controllers
{
    public class HomeController : Controller
    {

        private static readonly IList<CommentModel> _comments;

        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Morgan",
                    Text = "Hello ReactJS.NET Gazou gazou nono!"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Papa",
                    Text = "La liste"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Apple-Jack",
                    Text = "Wouf *wouf* wouf!"
                },
            };
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]

        public ActionResult Comments()
        {
            return Json(_comments);
        }

        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            // Create a fake ID for this comment
            comment.Id = _comments.Count + 1;
            _comments.Add(comment);
            return Content("Success :)");
        }

    }
}
