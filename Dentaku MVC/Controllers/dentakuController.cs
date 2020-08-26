using Dentaku_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace Dentaku_MVC.Controllers
{
    public class dentakuController : Controller
    {

        [HttpGet]
        public ActionResult dentaku()
        {
            return View();
        }

        [HttpPost]
        public ActionResult dentaku(dentakuModel model)
        {
            model.result = CalcProc(model.siki).ToString();
          
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
                string left = String.Empty;
                string right = String.Empty;
                string enzansi = String.Empty;
                string kari = String.Empty;
                int leftres = 0;
                int rightres = 0;
                int result = 0;

                //空の時は処理を抜ける
                if (String.IsNullOrEmpty(siki))
                {
                    return 0;
                }

                for (int i = 0; i < siki.Length; i++)
                {
                    //一文字ずつ取得していく
                    kari = siki.Substring(i, 1);
                    switch (kari)
                    {

                        case "+":
                            left = siki.Substring(0, i);   //左側の式を取得
                            enzansi = kari;         //kari変数の中に演算子が入っているはず
                            right = siki.Substring(i + 1);   //右側の式を取得
                            break;

                        case "-":
                            left = siki.Substring(0, i);   //左側の式を取得
                            enzansi = kari;         //kari変数の中に演算子が入っているはず
                            right = siki.Substring(i + 1);   //右側の式を取得
                            break;

                        case "%":
                            left = siki.Substring(0, i);   //左側の式を取得
                            enzansi = kari;         //kari変数の中に演算子が入っているはず
                            right = siki.Substring(i + 1);   //右側の式を取得
                            break;

                        case "/":
                            left = siki.Substring(0, i);   //左側の式を取得
                            enzansi = kari;         //kari変数の中に演算子が入っているはず
                            right = siki.Substring(i + 1);   //右側の式を取得
                            break;

                        case "*":
                            left = siki.Substring(0, i);   //左側の式を取得
                            enzansi = kari;         //kari変数の中に演算子が入っているはず
                            right = siki.Substring(i + 1);   //右側の式を取得
                            break;

                        default:
                            break;
                    }

                }

                #region チェック関連
                //左の式が空の時
                if (String.IsNullOrEmpty(left))
                {
                    //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                    //とりあえず後回し
                    return 0;
                }
                //数字に変換可能か
                if (!int.TryParse(left, out leftres))
                {
                    //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                    //とりあえず後回し
                    return 0;
                }

                //演算子が空の時
                if (String.IsNullOrEmpty(enzansi))
                {
                    //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                    //とりあえず後回し
                    return 0;
                }

                //右の式が空の時
                if (String.IsNullOrEmpty(right))
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
                #endregion

                //演算子を見て計算する
                switch (enzansi)
                {

                    case "+":
                        result = leftres + rightres;
                        break;

                    case "-":
                        result = leftres - rightres;
                        break;

                    case "%":
                        result = leftres % rightres;
                        break;

                    case "/":
                        result = leftres / rightres;
                        break;

                    case "*":
                        result = leftres * rightres;
                        break;

                    default:
                        result = 0;
                        break;
                }

                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #region 切り出し関数

        /// <summary>
        /// 文字列の指定した位置から指定した長さを取得する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="start">開始位置</param>
        /// <param name="len">長さ</param>
        /// <returns>取得した文字列</returns>
        public static string Mid(string str, int start, int len)
        {
            if (start <= 0)
            {
                throw new ArgumentException("引数'start'は1以上でなければなりません。");
            }
            if (len < 0)
            {
                throw new ArgumentException("引数'len'は0以上でなければなりません。");
            }
            if (str == null || str.Length < start)
            {
                return "";
            }
            if (str.Length < (start + len))
            {
                return str.Substring(start - 1);
            }
            return str.Substring(start - 1, len);
        }

        /// <summary>
        /// 文字列の指定した位置から末尾までを取得する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="start">開始位置</param>
        /// <returns>取得した文字列</returns>
        public static string Mid(string str, int start)
        {
            return Mid(str, start, str.Length);
        }

        /// <summary>
        /// 文字列の先頭から指定した長さの文字列を取得する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="len">長さ</param>
        /// <returns>取得した文字列</returns>
        public static string Left(string str, int len)
        {
            if (len < 0)
            {
                throw new ArgumentException("引数'len'は0以上でなければなりません。");
            }
            if (str == null)
            {
                return "";
            }
            if (str.Length <= len)
            {
                return str;
            }
            return str.Substring(0, len);
        }

        /// <summary>
        /// 文字列の末尾から指定した長さの文字列を取得する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="len">長さ</param>
        /// <returns>取得した文字列</returns>
        public static string Right(string str, int len)
        {
            if (len < 0)
            {
                throw new ArgumentException("引数'len'は0以上でなければなりません。");
            }
            if (str == null)
            {
                return "";
            }
            if (str.Length <= len)
            {
                return str;
            }
            return str.Substring(str.Length - len, len);
        }

        #endregion

    }
}