using System.Linq;
using System.Web.Mvc;
using SuperTemplate.Core;
using SuperTemplate.Core.Entities;
using SuperTemplate.Core.Repository;

namespace SuperTemplate.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDoSomething _doSomething;
        private readonly IRepository<Person> _personRepository;

        public HomeController(
            IDoSomething doSomething,
            IRepository<Person> personRepository 
            )
        {
            _personRepository = personRepository;
            _doSomething = doSomething;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = _doSomething.GiveMeAString();
            if (!_personRepository.GetQuery().Any(x => x.FirstName == "Shawn"))
            {
                _personRepository.Insert(new Person{ FirstName = "Shawn", LastName = "Lee"});
            }
            return View();
        }

        public ActionResult Contact()
        {
            var person = _personRepository.GetQuery().SingleOrDefault(x => x.FirstName == "Shawn");
            ViewBag.Message = "Hello " +( person == null ? "ERROR" : person.LastName);

            return View();
        }
    }
}