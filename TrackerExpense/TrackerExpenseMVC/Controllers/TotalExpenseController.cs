using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackerExpenseMVC.Models;
using System.Net.Http;

namespace TrackerExpenseMVC.Controllers
{
    public class TotalExpenseController : Controller
    {
        // GET: TotalExpense
        public ActionResult Index()
        {
            IEnumerable<TotalExpenseMVC> expList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TotalExpense").Result;
            expList = response.Content.ReadAsAsync<IEnumerable<TotalExpenseMVC>>().Result;
            return View(expList);
        }
        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0 && ModelState.IsValid)
                return View(new TotalExpenseMVC());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TotalExpense/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<TotalExpenseMVC>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(TotalExpenseMVC exp)
        {
            if (exp.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("TotalExpense", exp).Result;
                TempData["SuccessMessage"] = "Created Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("TotalExpense/" + exp.Id, exp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("TotalExpense/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}