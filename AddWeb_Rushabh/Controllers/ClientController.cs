using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Bal;
using Microsoft.AspNetCore.Http;
using Models;
using Newtonsoft.Json;

namespace AddWeb_Rushabh.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        ClientBal objclientBal = new ClientBal();
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Index(int? Id = null)
        //{
        //    HomeModel objHomeModel = new HomeModel();
        //    if (Id > 0 && Id != null)
        //    {
        //        objHomeModel = objclientBal.GetClientData();
        //    }
        //    return View(objHomeModel);
        //}
        public ActionResult ClientDataList()
        {
            return View(objclientBal.GetClientData());
        }

        [HttpPost]
        public ActionResult Index(HomeModel objHomeModel = null)
        {            
            if (ModelState.IsValid)
            {
                int iReturn = objclientBal.InsertClientData(objHomeModel);
                if (iReturn > 0)
                {
                    TempData["SuccessMessage"] = "Record save successfully";
                    //ViewBag.SuccessMessage = ValidationMessages.Save;
                    return RedirectToAction("Index", "Client", new { id = 0 });
                }
                else
                    ViewBag.ErrorMessage = "Record not save successfully";
                ModelState.Clear();
            }
            return View(objHomeModel);
        }

        
        public async Task<ActionResult> GetSearchData(string strSearch)
        {
            string Baseurl = HttpContext.Request.Url.OriginalString.Replace(HttpContext.Request.Url.LocalPath,"");    
            List<HomeModel> liClientData = new List<HomeModel>();
            using (var client = new HttpClient())
            {               
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();             
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
                HttpResponseMessage Res = await client.GetAsync("/api/GetData/" + strSearch);                
                if (Res.IsSuccessStatusCode)
                {                    
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;                    
                    liClientData = JsonConvert.DeserializeObject<List<HomeModel>>(EmpResponse);
                }
                return View(liClientData);
            }
        }
    }
}