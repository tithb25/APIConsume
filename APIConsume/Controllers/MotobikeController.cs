using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APIConsume.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIConsume.Controllers
{
    public class MotobikeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<MotobikeViewModel> motobikes = null;
            using (var client  = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307/api/");

                var responseTask = client.GetAsync("motobike/listmotobike");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<MotobikeViewModel>>();
                    readTask.Wait();

                    motobikes = readTask.Result;
                }
                else
                {
                    motobikes = Enumerable.Empty<MotobikeViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(motobikes);
        }
    }
}