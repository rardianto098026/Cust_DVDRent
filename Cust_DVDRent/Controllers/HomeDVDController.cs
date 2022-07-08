using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cust_DVDRent.Models;
using System.Data;
using System.Net.Http;
using Newtonsoft.Json;

namespace Cust_DVDRent.Controllers
{
    public class HomeDVDController : Controller
    {
        // GET: HomeDVD
        public ActionResult Index(HomeDVDModels.HomeIndex<HomeDVDModels.HomeIndex> model)
        {
            DataTable tableModel = new DataTable();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:26403/api/CustDVDRent/GetMovie");
                //HTTP GET
                var responseTask = client.GetAsync("GetMovie");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    tableModel = (DataTable)JsonConvert.DeserializeObject(readTask, (typeof(DataTable)));
                }
            }

            model.listMovieAvailable = ListMovie(tableModel);

            model.listMovieAvailable = model.listMovieAvailable;

            return View(model);
        }

        public static List<HomeDVDModels.HomeIndex> ListMovie(DataTable dt)
        {
            List<HomeDVDModels.HomeIndex> model = new List<HomeDVDModels.HomeIndex>();
            DataTable tableModel = dt;

            foreach (DataRow dr in tableModel.Rows)
            {
                model.Add(new HomeDVDModels.HomeIndex
                {
                    ID = dr["ID"].ToString(),
                    Title = dr["Title"].ToString(),
                    AgeRating = dr["Rating"].ToString(),
                    Duration = dr["Duration"].ToString(),
                    PictureUrl = dr["PictureURL"].ToString(),
                    ReleaseYear = dr["ReleaseYear"].ToString(),
                    Genre = dr["Genre"].ToString()
                });
            }


            return model;
        }
    }
}