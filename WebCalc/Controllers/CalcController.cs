using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;
using CalcLibrary;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            var model = new OperationViewModel();
            var calc = new CalcLibrary.Calc(@"C:\Projects\sharpcalc\WebCalc\bin");
            
            //Подготовка источника данных для DropDownList
            model.Operations = calc.Operations
                .Where(o => o is IOperationArgs)
                .ToDictionary(o => o.GetType().FullName, 
                              o => $"{o.GetType().Name}.{o.Name}");

            return View(model);
        }

        // POST: Calc
        [HttpPost]
        public ActionResult Index(OperationViewModel model)
        {
            var calc = new CalcLibrary.Calc(@"C:\Projects\sharpcalc\WebCalc\bin");
            //Подготовка словаря операций с тем же ключом, что в DropDownList
            var opers= calc.Operations
                .Where(o => o is IOperationArgs)
                .ToDictionary(o => o.GetType().FullName, 
                        o => o);

            var result = calc.Execute(opers[model.Operation], model.InputData.Split(' '));
            model.Result = result.ToString();

            model.Operations = calc.Operations
                .Where(o => o is IOperationArgs)
                .ToDictionary(o => o.GetType().FullName,
                             o => $"{o.GetType().Name}.{o.Name}");

            return View(model);
        }

    }
}