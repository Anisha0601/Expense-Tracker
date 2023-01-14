using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TrackerExpenseMVC.Models;

namespace TrackerExpenseMVC.Controllers
{
    public class ExpenseTrackerController : Controller
    {
        // GET: ExpenseTracker
            public ActionResult Index()
            {
                dynamic de = new ExpandoObject();
                de.expense = GetExpense();
                de.category = GetCategory();
            de.totalexpense= GetTotalExpense();
                return View(de);
            }
            public List<ExpenseMVC> GetExpense()
            {
                List<ExpenseMVC> expList;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Expense").Result;
                expList = response.Content.ReadAsAsync<List<ExpenseMVC>>().Result;
            ViewBag.add = expList.Sum(a => a.Amount);
                return expList;
            }
            public List<CategoryMVC> GetCategory()
            {
                List<CategoryMVC> expList;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category").Result;
                expList = response.Content.ReadAsAsync<List<CategoryMVC>>().Result;
                return expList;

            }
            public List<TotalExpenseMVC> GetTotalExpense() 
            {
            List<TotalExpenseMVC> expList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TotalExpense").Result;
            expList = response.Content.ReadAsAsync<List<TotalExpenseMVC>>().Result;
            return expList;

        }

    }
    }