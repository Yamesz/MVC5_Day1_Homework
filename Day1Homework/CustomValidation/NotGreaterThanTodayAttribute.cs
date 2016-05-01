using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.CustomValidation
{
    //ref https://hossamhassan47.wordpress.com/2012/12/09/mvc-4-0-how-to-support-client-side-custom-validation/
    public class NotGreaterThanTodayAttribute : ValidationAttribute, IClientValidatable
    {
        public NotGreaterThanTodayAttribute(){}

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            DateTime inputValue;
            if (value != null && DateTime.TryParse(value.ToString(),out inputValue))
            {

                if (inputValue > DateTime.Now)
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName)
                    );
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            
            //低調用戶端驗證規則中的驗證型別名稱必須只能包含小寫字母。無效名稱: "notGreaterThanToday"，
            //用戶端規則型別: System.Web.Mvc.ModelClientValidationRule
            //rule.ValidationType = "NotGreaterThanToday";
            rule.ValidationType = "notgreaterthantoday";

            //欄位 日期不能大於今天 無效。
            //rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName() + "不能大於今天");

            rule.ErrorMessage = metadata.GetDisplayName() + "不能大於今天";
            yield return rule;
        }
    }
}