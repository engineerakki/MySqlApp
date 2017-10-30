using Apprenda.Services.Logging;
using DataObjects;
using DBApp.Models;
using System;
using System.Web.Mvc;

namespace DBApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger log = LogManager.Instance().GetLogger(typeof(HomeController));
        public ActionResult Index()
        {
            log.Info($"Loading index page");
            ViewBag.Header = "Account Analisys";
            BizLib.DB db = new BizLib.DB();
            DataBag bag = new DataBag();
            try
            {
                AccountData data = new AccountData();
                data.Deposit = 200;
                data.Balance = 1300;
                Results r = db.LoadLastResults();
                data.Balance = r.Balance;
                data.Deposit = r.Deposit;
                bag.Account = data;
            }
            catch (Exception ex)
            {
                log.Error($"Error loading index page: {ex}");
                //return the main page with hard-set defaults
            }
            return View(bag);
        }

        [HttpPost]
        public ActionResult WhatIf(DataBag data)
        {
            log.Info($"Loading whatif page and saving data");
            BizLib.DB db = new BizLib.DB();
            try
            {
                data.WhatIfResults = db.SaveWhatIfModel(data.Account);
            }
            catch(Exception ex)
            {
                log.Error($"Error loading whatif page: {ex}");
                return View("Error");
            }

            return View(data);
        }

        public ActionResult WhatIfResults()
        {
            log.Info($"Loading whatif results for display");
            BizLib.DB db = new BizLib.DB();
            DataBag bag = new DataBag();
             
            try
            {
                bag.WhatIfResults = db.LoadLastResults();
            }
            catch (Exception ex)
            {
                log.Error($"Error loading whatif results: {ex}");
                return View("Error");
            }

            return View(bag);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult InterestChart()
        {
            log.Info($"Loading interest chart");
            BizLib.DB db = new BizLib.DB();
            DataBag bag = new DataBag();
            try
            {
                InterestData recs = db.LoadInterestData();
                if (recs != null && recs.Months != null)
                {
                    bag.Interest = recs.Months;
                }


                return View(bag);
            }
            catch (Exception ex)
            {
                log.Error($"Error loading interest chart: {ex}");
                return View("Error");
            }
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}