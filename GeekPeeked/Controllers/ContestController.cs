using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeekPeeked.Controllers
{
    public class ContestController : Controller
    {
        // GET: Contest
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contest/SignUp
        public ActionResult SignUp(int contestId)
        {
            return View();
        }

        // GET: Contest/Update
        public ActionResult Update(int contestId)
        {
            return View();
        }
    }
}