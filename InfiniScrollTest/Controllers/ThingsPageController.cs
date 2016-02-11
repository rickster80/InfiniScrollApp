using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace InfiniScrollTest.Controllers
{
    public class ThingsPageController : Controller
    {
        // GET: ThingsPage
        public ActionResult Index()
        {
            var cli = new HttpClient();
            var res = cli.GetAsync("http://localhost:51778/api/things/search?page=0").Result.EnsureSuccessStatusCode();
            var con = JsonConvert.DeserializeObject<List<SomeThing>>(res.Content.ReadAsStringAsync().Result);
            return View(con);
        }
    }
}