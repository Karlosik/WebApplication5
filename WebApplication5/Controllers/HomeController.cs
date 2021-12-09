using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        double P;
        double P1;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public JsonResult People()
        {
           //public const string SessionKeyName = "Name";
        int name = 0;
        int name1=0;
            Random ra = new Random();
            name = ra.Next(100);
            name1= ra.Next(100);
            List<string> liEx = (List<string>)Session["Ectrasens"];
            if (liEx == null)
            {
                liEx = new List<string>();
            }
            liEx.Add(name.ToString());
            List<string> liEx1 = (List<string>)Session["Ectrasens1"];
            if (liEx1 == null)
            {
                liEx1 = new List<string>();
            }
            liEx1.Add(name1.ToString());
            Session["Ectrasens"] = liEx;
            Session["Ectrasens1"] = liEx1;

            var data = new
             {
                 n = name,
                n1 = name1
             };
           return Json(data, JsonRequestBehavior.AllowGet);
        }
        public class G
        {
            public string St { get; set; }
        }
        [HttpGet]
        public JsonResult PepleWWod(G d)
        {
            int name=0;
            int name1=0;
            List<string> li = new List<string>();
            List<string> li1 = new List<string>();
            List<string> lih = (List<string>)Session["People"];
            List<string> lip = new List<string>();
            if (lih == null)
            {
                lih = new List<string>();
            }
            lih.Add(d.St.ToString());
            Session["People"] = lih;
            lip= (List<string>)Session["People"];
            li = (List<string>)Session["Ectrasens"];
            li1 = (List<string>)Session["Ectrasens1"];
            int k= li.Count();
            name = Convert.ToInt32(li[k-1]);
            name1 = Convert.ToInt32(li1[k-1]);
            int h= Convert.ToInt32(d.St);
            if (name == h)
            {
                Dost.P = Dost.P+ 0.1;
            }
            else
                Dost.P = Dost.P - 0.1;
            if (name1 == h)
            {
                Dost.P1 = Dost.P1 + 0.1;
            }
            else
                Dost.P1 = Dost.P1 - 0.1;
            var data = new
            {
                p1 = Dost.P,
                p2 = Dost.P1,
                e1 = li,
                e2 = li1,
                n = lip
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}