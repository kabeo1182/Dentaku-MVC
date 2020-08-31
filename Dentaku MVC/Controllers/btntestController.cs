using Antlr.Runtime;
using Dentaku_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace Dentaku_MVC.Controllers
{
    public class btntestController : Controller
    {
        // GET: btntest
        public ActionResult btntest(btntestModel model,string keisan)
        {
            if (keisan == "+")
            {
               model.result = CalcProcPlus(model).ToString();
            }
            else if (keisan == "-")
            {
                model.result = CalcProcMinus(model).ToString();
            }
            else if (keisan == "*")
            {
                model.result = CalcProcTimesMultiplied(model).ToString();
            }
            else if (keisan == "/")
            {
                model.result = CalcProcDivided(model).ToString();
            }
            return View(model);
        }

        private int CalcProcPlus(btntestModel model)
        {

            try
            {
                string left = String.Empty;
                string right = String.Empty;
                int leftres = 0;
                int rightres = 0;
                int result = 0;

                //値渡しをする
                left = model.leftsiki;
                right = model.rightsiki;

                //左の式が空の時は処理を抜ける
                if (String.IsNullOrEmpty(left))
                {
                    return 0;
                }
                //右の式が空の時は処理を抜ける
                if (String.IsNullOrEmpty(right))
                {
                    return 0;
                }

                //数字に変換可能か
                if (!int.TryParse(left, out leftres))
                {
                    //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                    //とりあえず後回し
                    return 0;
                }
                //数字に変換可能か
                if (!int.TryParse(right, out rightres))
                {
                    //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                    //とりあえず後回し
                    return 0;
                }

                result = leftres + rightres;
                       

                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private int CalcProcMinus(btntestModel model)
        {

            try
            {
                string left = String.Empty;
                string right = String.Empty;
                int leftres = 0;
                int rightres = 0;
                int result = 0;

                //値渡しをする
                left = model.leftsiki;
                right = model.rightsiki;

                //左の式が空の時は処理を抜ける
                if (String.IsNullOrEmpty(left))
                {
                    return 0;
                }
                //右の式が空の時は処理を抜ける
                if (String.IsNullOrEmpty(right))
                {
                    return 0;
                }

                //数字に変換可能か
                if (!int.TryParse(left, out leftres))
                {
                    //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                    //とりあえず後回し
                    return 0;
                }
                //数字に変換可能か
                if (!int.TryParse(right, out rightres))
                {
                    //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                    //とりあえず後回し
                    return 0;
                }

                result = leftres - rightres;


                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private int CalcProcTimesMultiplied(btntestModel model)
        {

            try
            {
                string left = String.Empty;
                string right = String.Empty;
                int leftres = 0;
                int rightres = 0;
                int result = 0;

                //値渡しをする
                left = model.leftsiki;
                right = model.rightsiki;

                //左の式が空の時は処理を抜ける
                if (String.IsNullOrEmpty(left))
                {
                    return 0;
                }
                //右の式が空の時は処理を抜ける
                if (String.IsNullOrEmpty(right))
                {
                    return 0;
                }

                //数字に変換可能か
                if (!int.TryParse(left, out leftres))
                {
                    //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                    //とりあえず後回し
                    return 0;
                }
                //数字に変換可能か
                if (!int.TryParse(right, out rightres))
                {
                    //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                    //とりあえず後回し
                    return 0;
                }

                result = leftres * rightres;


                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private int CalcProcDivided(btntestModel model)
        {

            try
            {
                string left = String.Empty;
                string right = String.Empty;
                int leftres = 0;
                int rightres = 0;
                int result = 0;

                //値渡しをする
                left = model.leftsiki;
                right = model.rightsiki;

                //左の式が空の時は処理を抜ける
                if (String.IsNullOrEmpty(left))
                {
                    return 0;
                }
                //右の式が空の時は処理を抜ける
                if (String.IsNullOrEmpty(right))
                {
                    return 0;
                }

                //数字に変換可能か
                if (!int.TryParse(left, out leftres))
                {
                    //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                    //とりあえず後回し
                    return 0;
                }
                //数字に変換可能か
                if (!int.TryParse(right, out rightres))
                {
                    //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                    //とりあえず後回し
                    return 0;
                }

                result = leftres / rightres;


                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}