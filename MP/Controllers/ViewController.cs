using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MP.Models;

namespace MP.Controllers
{
    public class ViewController : Controller
    {
        DemoEntities db = new DemoEntities();
        public int ID = 3;
        // GET: View
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin()
        {
            List<Menu> Access = new List<Menu>();
            ID = Convert.ToInt32(Session["Permission"]);
            Permission per = db.Permission.SingleOrDefault(a => a.PermissionID == ID);
            List<String> list = db.Menu_Permission.Where(a => a.PermissionID == per.PermissionID).Select(a => a.MenuID).ToList();
            Access = db.Menu.Where(t => list.Contains(t.MenuID)).ToList();
            List<MenuChild> Child = new List<MenuChild>();
            foreach (var item in Access)
            {
                Child.Add(new MenuChild
                {
                    MenuName = item.MenuName,
                    ChildMenu = db.ChildMenu.Where(x => x.MenuID == item.MenuID).Select(x => x.ChildMenu1).ToList()
                });
            }
            return View(Child);
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session["Username"] = null;
            Session["Fullname"] = null;
            Session["Avatar"] = null;
            Session["Permission"] = null;
            return RedirectToAction("Login");
        }
    }
}