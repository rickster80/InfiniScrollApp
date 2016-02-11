using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InfiniScrollTest.Controllers
{
    public class SomeThing
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ThingsController : ApiController
    {
        public List<SomeThing> Things { get; set; }
        public List<string> Names { get; set; } = new List<string>()
        {
            "Ricky", "Ken", "Andrea", "Steve", "Jeremy", "Alan", "Rod", "Jon", "Jono", "Ross", "Vicki"
        };
        private int NumPerPage = 10;
        public ThingsController()
        {
            Things = new List<SomeThing>();
            var random = new Random();            
            for (int i = 0; i < 1000; i++)
            {
                int index = random.Next(Names.Count);
                Things.Add(new SomeThing() { Id = i, Name = $"{Names[index]}{i}" });
            }
        }
        public IHttpActionResult Get(int page)
        {
            return Json(Things.Skip((page - 1) * NumPerPage).Take(NumPerPage));
        }
        [HttpGet]
        public IHttpActionResult Search(string search = "", int page = 1)
        {
            var data = Things.AsEnumerable();
            var s = search.Trim().ToLower();
            data = !string.IsNullOrEmpty(search) ? data.Where(t => t.Name.ToLower().Contains(s)) : data;
            data = data.Skip((page - 1) * NumPerPage).Take(NumPerPage);
            return Json(data);
        }
    }
}
