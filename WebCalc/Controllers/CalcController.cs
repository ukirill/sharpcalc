using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(OperationViewModel model)
        {
            var calc = new CalcLibrary.Calc(@"C:\Projects\sharpcalc\WebCalc\bin");
            var result = calc.Execute(model.Operation, model.InputData.Split(' '));
            model.Result = result.ToString();
            return View(model);
        }

    }
}