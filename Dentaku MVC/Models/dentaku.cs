using System.ComponentModel.DataAnnotations;

namespace Dentaku_MVC.Models
{
    public class dentaku
    {
        [Display(Name = "計算式")]
        public string siki { get; set; }

        [Display(Name = "答え")]
        public string kotae { get; set; }
    }
}