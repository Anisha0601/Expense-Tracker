using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrackerExpenseMVC.Models;

namespace TrackerExpenseMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public async Task<ActionResult> Index()
        {
            /*ICollection<CategoryMVC> expList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category").Result;
            expList = response.Content.ReadAsAsync<ICollection<CategoryMVC>>().Result;
            return View(expList);*/

            HttpClient client = new HttpClient();
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category").Result;
            if (response.IsSuccessStatusCode)
            {
                var jstring = await response.Content.ReadAsStringAsync();
                List<CategoryMVC> list = JsonConvert.DeserializeObject<List<CategoryMVC>>(jstring);
                return View(list);
            }
            else
            {
                return View(new List<CategoryMVC>());
            }
        }

        //HttpClient client = new HttpClient();
        //string url = string.Format("");
        //HttpResponseMessage response = await client.GetAsync(url);
        //dynamic likesResult = await response.Content.ReadAsStringAsync();
        //var x = (JsonConvert.DeserializeObject<IDictionary<string, object>>(likesResult.ToString()))["HomeSummaryResult"];
        //likesList = JsonConvert.DeserializeObject<ObservableCollection<PageLike>>(x.ToString());
        
        
        //var x = (JsonConvert.DeserializeObject<IDictionary<string, object>>(likesResult.ToString()))["HomeSummaryResult"]["likes"];
        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0 && ModelState.IsValid)
                return View(new CategoryMVC());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<CategoryMVC>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(CategoryMVC exp)
        {
            if (exp.CId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Category", exp).Result;
                TempData["SuccessMessage"] = "Created Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Category/" + exp.CId, exp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Category/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}