using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TrackerExpenseMVC.Models;

namespace TrackerExpenseMVC.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
            public ActionResult Index()
            {
                IEnumerable<ExpenseMVC> expList;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Expense").Result;
                expList = response.Content.ReadAsAsync<IEnumerable<ExpenseMVC>>().Result;
                return View(expList);
            }
        public ActionResult AddorEdit(int id = 0)
        {
            IEnumerable<CategoryMVC> expList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category").Result;
            expList = response.Content.ReadAsAsync<IEnumerable<CategoryMVC>>().Result;
            var CList= expList.ToList();
            ViewBag.Id = new SelectList(CList, "CId", "CName");
            if (id == 0&& ModelState.IsValid)
                return View(new ExpenseMVC());
            else
            {
                HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("Expense/" + id.ToString()).Result;
                return View(response1.Content.ReadAsAsync<ExpenseMVC>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(ExpenseMVC exp)
        {
            /*HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost/api/expense");
            var insertCategory = client.PostAsJsonAsync<ExpenseMVC>("categories", exp).Result;*/
            if (exp.EId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Expense", exp).Result;
                TempData["SuccessMessage"] = "Created Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Expense/" + exp.EId, exp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            return RedirectToAction("AddorEdit",new {id=exp.EId});
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Expense/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}