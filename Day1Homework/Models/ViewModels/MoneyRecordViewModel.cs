using Day1Homework.CustomValidation;
using Day1Homework.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Day1Homework.Models.ViewModels
{
    public class MoneyRecordViewModel: IValidatableObject
    {
        [Display(Name = "AccountBookID")]
        public Guid accountBookID { get; set; }

        [Display(Name = "類別")]
        [UIHint("MoneyCategory")]
        public MoneyCategory category { get; set; }

        [Display(Name = "金額")]
        [Required]
        //作業要求的正整數
        //自己加入 當金額是0時，請輸入備註的客製化驗證
        //[Range(1, uint.MaxValue)]
        public uint money { get; set; }

        [Display(Name = "日期")]
        [DataType(DataType.Date)]
        [Required]
        [NotGreaterThanToday]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        
        [Display(Name = "備註")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        //ref http://www.itorian.com/2013/02/custom-validation-with.html
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var descriptionProperty = new[] { "description" };
            var descriptionLength = description == null
                                    ? 0
                                    : description.Length;
            if (money == 0 && descriptionLength == 0)
            {
                yield return new ValidationResult("當金額是0時，請輸入備註", descriptionProperty);
            }
        }
    }
}
