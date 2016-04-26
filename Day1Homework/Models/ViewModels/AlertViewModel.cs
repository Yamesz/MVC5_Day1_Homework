using Day1Homework.CustomValidation;
using Day1Homework.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Day1Homework.Models.ViewModels
{
    public class AlertViewModel
    {
        public string Title { get; set; }
        public string Msg { get; set; }
        public string Status { get; set; }



    }
}
