using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Day1Homework.Models.ViewModels
{
    /// <summary>
    /// 記帳類型
    /// </summary>
    /// <remarks>
    /// view顯示的文字由UIHint=>MoneyCategory 決定
    /// </remarks>
    public enum MoneyCategory
    {
        /// <summary>
        /// 支出
        /// </summary>
        pay = 0,
        /// <summary>
        /// 收入
        /// </summary>
        income = 1
    }
    public class MoneyRecordViewModels
    {
        [Display(Name = "AccountBookID")]
        public Guid accountBookID { get; set; }

        [Display(Name = "類別")]
        [UIHint("MoneyCategory")]
        public MoneyCategory category { get; set; }

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
