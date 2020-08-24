using Dentaku_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dentaku_MVC.Controllers
{
    public class dentakuController : Controller
    {
        // GET: dentaku
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(dentaku model)
        {
            CalcProc(model.siki);

            return View();
        }

        /// <summary>
        /// 演算用プロシージャ
        /// </summary>
        /// <param name="siki"></param>
        /// <returns></returns>
        private int CalcProc(string siki)
        {
       
            try
            {
                //()をそれぞれ保持する
                List<string> leftkakko = new List<string>();
                List<string> rightkakko = new List<string>();
                //数字を保持する
                List<string> numbers = new List<string>();
                //演算子を保持する
                List<string> enzansi = new List<string>();

                //分解のため変数
                string kari = String.Empty;
                string irekomi = String.Empty;
                int kotae = 0;

                for (int i = 0; i < siki.Length; i++)
                {
                    for (int j = i+1; j < siki.Length; j++)
                    {
                       
                        switch (kari)
                        {
                            default:
                                break;
                        }
                        kari = kari + siki.Substring(i, j);
                    }
                }

                return kotae;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}