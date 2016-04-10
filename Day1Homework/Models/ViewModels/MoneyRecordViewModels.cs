using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Day1Homework.Models.ViewModels
{
    public class MoneyRecordViewModels
    {
        [Display(Name = "類別")]
        public string category { get; set; }

        [Display(Name = "金額")]
        public int money { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "日期")]
        public DateTime date { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "備註")]
        public string description { get; set; }

    }
}
