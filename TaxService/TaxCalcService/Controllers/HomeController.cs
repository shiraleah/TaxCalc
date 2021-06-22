using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxCalcService.Models;
using TaxCalcService.Models.Payloads;
using TaxCalcService.Services;

namespace TaxCalcService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var taxJarClientService = new TaxJarClientService();
            var rate = taxJarClientService.GetTaxRateForLocation("20853", "US", "MD");

            ViewBag.StateRate = rate.Rate.StateRate;

            var order = new Order
            {
                ToCountry = "US",
                Shipping = 5,
                Amount = 25,
                ToZip = null,
                ToState = "MD",
                FromCountry = "US",
                FromZip = "20853",
                FromState = "MD"
            };

            ViewBag.TotalTaxes = taxJarClientService.CalculateTaxesForOrder(order);
            return View();
        }
    }
}
