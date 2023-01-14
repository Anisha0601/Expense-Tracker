using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TrackerExpenseMVC.Models;

namespace TrackerExpenseMVC.Controllers
{
    public class CategoryEController : Controller
    {
        // GET: CategoryE
        public ActionResult Index(int id)
        {
            IEnumerable<ExpenseMVC> expList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Expense").Result;
            expList = response.Content.ReadAsAsync<IEnumerable<ExpenseMVC>>().Result;
            var sai = expList.Where(p => p.CId == id).ToList();
            return View(sai);
        }
        public ActionResult Index1(int id)
        {
            IEnumerable<CategoryMVC> expList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category").Result;
            expList = response.Content.ReadAsAsync<IEnumerable<CategoryMVC>>().Result;
            /*ViewBag.a=expList.Where(p=>p.CId==id).Select(p=>p.CName);*/
            var sai = expList.Where(p => p.CId == id).ToList();
            return View(sai);
        }
    }
}