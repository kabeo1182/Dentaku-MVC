using System.ComponentModel.DataAnnotations;

namespace Dentaku_MVC.Models
{
    public class dentakuModel
    {
        [Display(Name = "計算式")]
        public string siki { get; set; }

        [Display(Name = "答え")]
        public string result { get; set; }
    }
}