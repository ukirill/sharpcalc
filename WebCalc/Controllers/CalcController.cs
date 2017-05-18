﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;
using CalcLibrary;
using WebCalc.Managers;
using System.Diagnostics;

namespace WebCalc.Controllers
{
    
    public class CalcController : Controller
    {
        #region private
        private IOperationResultRepository OperationResultRepository { get; set; }

        private Calc Calc { get; set; }

        private Dictionary<string, string> Operations { get; set; }

        //private IEnumerable<SelectListItem> OperationList { get; set; }
        #endregion



        public CalcController()
        {
            Calc = new Calc(@"C:\Projects\sharpcalc\WebCalc\bin");
            //OperationList = Calc.Operations.Select(o => new SelectListItem() { Text = $"{o.GetType().Name}.{o.Name}", Value = $"{o.GetType().Name}.{o.Name}" });
            Operations = Calc.Operations
                .Where(o => o is IOperationArgs)
                .ToDictionary(o => o.GetType().FullName,
                              o => $"{o.GetType().Name}.{o.Name}");
            OperationResultRepository = new OperationManager();
        }



        // GET: Calc
        public ActionResult Index()
        {
            var model = new OperationViewModel();
            model.Operations = Operations;
            return View(model);
        }

        // POST: Calc
        [HttpPost]
        public ActionResult Index(OperationViewModel model, string submit)
        {
            bool forcedCalc = (submit == "Forced Calc");

            var operResults = OperationResultRepository.GetAll();

            var oldResult = operResults.FirstOrDefault(o =>
                        o.OperationName == model.Operation && o.Arguments == model.InputData);

            if (oldResult != null && !forcedCalc)
            {
                model.Result = $"old => {oldResult.Result}";
            }
            else
            {

                var stopwatch = new Stopwatch();
                stopwatch.Start();
                //Подготовка словаря операций с тем же ключом, что в DropDownList
                var opers = Calc.Operations
                    .Where(o => o is IOperationArgs)
                    .ToDictionary(o => o.GetType().FullName,
                                  o => o);

                var result = Calc.Execute(opers[model.Operation], model.InputData.Split(' '));

                stopwatch.Stop();
                model.Result = result.ToString();
                //!!!Опасное преобразовние
                bool nanOrInfinity = (double.IsNaN((double)result) || double.IsInfinity((double)result)); 
                var operResult = new OperationResult()
                {
                    Id = (oldResult != null) ? oldResult.Id : 0,
                    OperationName = model.Operation,
                    Result = !nanOrInfinity ? result as double? : null,
                    Arguments = model.InputData,
                    ExecutionTime = stopwatch.ElapsedMilliseconds,
                    ExecutionDate = DateTime.Now
                };
                //запись в базу
                if (forcedCalc && oldResult != null)
                    OperationResultRepository.Update(operResult);
                else
                    OperationResultRepository.Save(operResult);
            }
            model.Operations = Operations;

            return View(model);
        }

        [HttpGet]
        public ActionResult History()
        {
            var model = new HistoryViewModel();
            model.OperationHistory = OperationResultRepository.GetAll("Id");
            return View(model);
        }

    }
}