using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Controllers
{
    public class ContentController:Controller
    {

        public IActionResult Index()
        {
            var contents = new List<Content>();
            for (int i = 0; i < 11; i++)
            {
                contents.Add(new Content
                {
                    Id = i,
                    title = $"{i}的标题",
                    content = $"{i}的内容",
                    status = 1,
                    add_time = DateTime.Now.AddDays(-i)
                });
            }
            return View(new ContentViewModel { Contents = contents });
                
        }

    }
}
