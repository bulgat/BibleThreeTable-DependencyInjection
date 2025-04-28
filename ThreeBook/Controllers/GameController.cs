using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThreeBook.Controllers
{
    public class GameController: Controller
    {
        [HttpGet]
        public string GetNumber()
        { 
        return "stop";
        }
        [HttpPost]
        public string GetNum()
        {
            return "This is Post";
        }
        [HttpPost]
        public string GetCount(int Num)
        {
            return "This is Post = "+Num;
        }
    }
}