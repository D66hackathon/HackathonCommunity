using Hackathon_Community.Commands;
using Hackathon_Community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hackathon_Community.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeModel hm = new HomeModel();
            hm.teams = new List<Team>();
            hm.teams.Add(new Team
            {
                Naam = "Wijzen uit het Oosten",
                Idee = "Hackathon Community",
                Leden = new List<Lid>
                {
                    new Lid {Naam = "Mariëtta Buitenhuis"},
                    new Lid {Naam = "Tom van Dijk"},
                    new Lid {Naam = "Jeroen Slobbe"},
                    new Lid {Naam = "Michael de Lang"}
                }
            });

            try
            {
                var ses = NhibernateSessionCommand.OpenSession();
                var teams = ses.QueryOver<Team>().List();
                foreach (var team in teams)
                {
                    hm.teams.Add(team);
                }
            }
            catch (Exception e)
            {
                var test = 0;
            }

            return View(hm);
        }

        public ActionResult NieuwTeam(string TeamNaam, string TeamIdee, string TeamDatum)
        {
            var ses = NhibernateSessionCommand.OpenSession();

            Team t = new Team();
            t.Naam = TeamNaam;
            t.Idee = TeamIdee;
            t.Datum = TeamDatum;
            ses.Save(t);
            ses.Flush();

            return RedirectToAction("Index", "Home");
        }
    }
}