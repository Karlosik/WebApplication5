using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
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
            Random ra = new Random();
            int chislo = ra.Next(10,100);
            int chislo1 = ra.Next(10, 100);

            List<string> lEctrasens = (List<string>)Session["Ectrasens"];
            List<string> lEctrasens1 = (List<string>)Session["Ectrasens1"];
            Dannye dannye = new Dannye();
            List<string> ChExstrasens = dannye.DannyeExtrasensa1(lEctrasens, chislo.ToString());
            List<string> ChExstrasens1 = dannye.DannyeExtrasensa1(lEctrasens1, chislo1.ToString());
            Session["Ectrasens"] = ChExstrasens;
            Session["Ectrasens1"] = ChExstrasens1;

            var data = new
             {
                Ectrasens = chislo,
                Ectrasens1 = chislo1
            };
           return Json(data, JsonRequestBehavior.AllowGet);
        }
        public class PeopleWwod
        {
            public string Wwod { get; set; }
        }
        [HttpGet]
        public JsonResult PepleWWod(PeopleWwod ChisloPeople)
        {
            Boolean ww = false;
            int WwodPeople = 0;
            List<string> lEctrasens = new List<string>();
            List<string> lEctrasens1 = new List<string>();
            List<string> lPeople = (List<string>)Session["People"];
            if (Int32.TryParse(ChisloPeople.Wwod, out WwodPeople))
            {
                if (WwodPeople > 9 & WwodPeople < 100)
                {
                    ww = true;
                }
                else
                ww = false;
                int chislo = 0;
                int chislo1 = 0;

                if (ww == true)
                {
                    Dannye dannye = new Dannye();
                    List<string> ChPeople = dannye.DannyePeople(lPeople, ChisloPeople.Wwod);
                    Session["People"] = ChPeople;
                    lPeople = ChPeople;
                }
                lEctrasens = (List<string>)Session["Ectrasens"];
                lEctrasens1 = (List<string>)Session["Ectrasens1"];
                int ChislaCount = lEctrasens.Count();
                chislo = Convert.ToInt32(lEctrasens[ChislaCount - 1]);
                chislo1 = Convert.ToInt32(lEctrasens1[ChislaCount - 1]);
                if (chislo == WwodPeople)
                {
                    Dostowernost.P += 0.1;
                }
                else
                    Dostowernost.P -=0.1;
                if (chislo1 == WwodPeople)
                {
                    Dostowernost.P1 += 0.1;
                }
                else
                    Dostowernost.P1 -= 0.1;
            } 
            else
            {
                ww = false;
            }
            Dostowernost.P=Math.Round(Dostowernost.P,2);
            Dostowernost.P1=Math.Round(Dostowernost.P1,2);
            var data = new
                {
                    w=ww,
                    credibility1 = Dostowernost.P,
                    credibility2 = Dostowernost.P1,
                    EctrasensChisla1 = lEctrasens,
                    EctrasensChisla2 = lEctrasens1,
                    WwodChisel = lPeople
                };

            
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}