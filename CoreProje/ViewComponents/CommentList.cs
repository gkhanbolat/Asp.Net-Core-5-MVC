using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents
{
    public class CommentList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    UserName="Gökhan"
                },
                new UserComment
                {
                    ID=2,
                    UserName="Murat"
                },
                new UserComment
                {
                    ID=3,
                    UserName="Bolat"
                },
            };
            return View(commentvalues);
        }
    }
}
