using InterViewWebApiCurd.DB_Context;
using InterViewWebApiCurd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace InterViewWebApiCurd.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {


            List<Employee> Emptab = new List<Employee>();

            client.BaseAddress = new Uri("http://localhost:59641/api/CurdApi");
            var res = client.GetAsync("CurdApi");
            res.Wait();
            var test = res.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                Emptab = display.Result;
            }

            return View(Emptab);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmpModel mod)
        {
            client.BaseAddress = new Uri("http://localhost:59641/api/CurdApi");
            var responce = client.PostAsJsonAsync<EmpModel>("CurdApi", mod);
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmpModel e = null;
            client.BaseAddress = new Uri("http://localhost:59641/api/CurdApi");
            var responce = client.GetAsync("CurdApi?id=" + id.ToString());
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<EmpModel>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost]

        public ActionResult Edit(EmpModel emp)
        {
            client.BaseAddress = new Uri("http://localhost:59641/api/CurdApi");
            var responce = client.PutAsJsonAsync<EmpModel>("CurdApi", emp);
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Edit");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            EmpModel e = null;
            client.BaseAddress = new Uri("http://localhost:59641/api/CurdApi");
            var responce = client.GetAsync("CurdApi?id=" + id.ToString());
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<EmpModel>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConformerd(int id)
        {
            EmpModel e = null;
            client.BaseAddress = new Uri("http://localhost:59641/api/CurdApi");
            var responce = client.DeleteAsync("CurdApi/" + id.ToString());
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Delete"); 
        }
    }
}
