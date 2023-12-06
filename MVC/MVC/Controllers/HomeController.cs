using MVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            var db = new dbEntities();
            homeViewModel.Members = db.Member.ToList();
            return View(homeViewModel);
        }

        [HttpPost]
        public ActionResult Register(FormCollection obj)
        {
            var member = new Member();
            member.Name = obj["name"];
            int.TryParse(obj["age"], out int iAge);
            member.Age = iAge;
            member.Birthday = obj["birthday"];
            var db = new dbEntities();
            db.Member.Add(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Member member)
        {
            var editViewModel = new EditViewModel();
            var db = new dbEntities();
            editViewModel.Members = db.Member.ToList();
            editViewModel.Member = member;
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection obj)
        {
            var editViewModel = new EditViewModel();
            var db = new dbEntities();
            Member member = db.Member.Find(id);
            member.Name = obj["name"];
            int.TryParse(obj["age"], out int iAge);
            member.Age = iAge;
            member.Birthday = obj["birthday"];
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var editViewModel = new EditViewModel();
            var db = new dbEntities();
            var member = db.Member.Find(id);
            if(member != null)
            {
                db.Member.Remove(member);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}