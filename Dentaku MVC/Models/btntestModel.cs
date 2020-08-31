using System.ComponentModel.DataAnnotations;

namespace Dentaku_MVC.Models
{
    public class btntestModel
    {
        [Display(Name = "計算式1")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        public string leftsiki { get; set; }

        [Display(Name = "計算式2")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "半角数字のみ入力できます")]
        public string rightsiki { get; set; }

        [Display(Name = "答え")]
        public string result { get; set; }
    }
}