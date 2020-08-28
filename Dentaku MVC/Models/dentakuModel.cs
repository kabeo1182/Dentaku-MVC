using System.ComponentModel.DataAnnotations;

namespace Dentaku_MVC.Models
{
    public class dentakuModel
    {
        [Display(Name = "計算式")]
        [RegularExpression(@"[a-zA-Z0-9 -/:-@\[-\`\{-\~]+", ErrorMessage = "半角英数字記号のみ入力できます")]
        public string siki { get; set; }

        [Display(Name = "答え")]
        public string result { get; set; }
    }
}