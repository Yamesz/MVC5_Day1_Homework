using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day1Homework.Models.Enums
{
    /// <summary>
    /// 記帳類型
    /// </summary>
    /// <remarks>
    /// view顯示的文字不會吃Display 改由UIHint=>MoneyCategory 決定
    /// </remarks>
    public enum MoneyCategory
    {
        /// <summary>
        /// 支出
        /// </summary>
        [Display(Name = "支出")]
        pay = 0,
        /// <summary>
        /// 收入
        /// </summary>
        [Display(Name = "收入")]
        income = 1
    }
}