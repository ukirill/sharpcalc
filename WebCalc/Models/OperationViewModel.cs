using CalcLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class OperationViewModel
    {
        [Display(Name = "Операция")]
        [Required]
        public string Operation { get; set; }

        public Dictionary<string, string> Operations { get; set; }

        [Display(Name = "Параметры")]
        [Required]
        public string InputData { get; set; }

        [Display(Name = "Результат")]
        [ReadOnly(true)]
        public string Result { get; set; }

    }
}