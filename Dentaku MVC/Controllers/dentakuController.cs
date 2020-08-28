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
    public class dentakuController : Controller
    {

        public ActionResult dentaku(dentakuModel model)
        {
            model.result = CalcProcVer3(model.siki).ToString();

            //modelをView側に返却しないといけないらしい・・・
            return View(model);
        }

        /// <summary>
        /// 演算用プロシージャ
        /// </summary>
        /// <param name="siki"></param>
        /// 備考：１＋１のような単純計算に対応
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

                //式の長さ分ループ
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

        /// <summary>
        /// 演算用プロシージャ
        /// </summary>
        /// <param name="siki"></param>
        /// 備考：１＋２＊３のような複数計算に対応
        /// <returns></returns>
        private int CalcProcVer2(string siki)
        {

            try
            {
                
                List<string> strlist = new List<string>();
                List<int> numlist = new List<int>();
                List<string> enzansilist = new List<string>();
                string kari = String.Empty;
                int enzansi = 0;
                int tryres = 0;
                int result = 0;

                //空の時は処理を抜ける
                if (String.IsNullOrEmpty(siki))
                {
                    return 0;
                }

                //式の長さ分ループ
                for (int i = 0; i < siki.Length; i++)
                {
                    //一文字ずつ取得していく
                    kari = siki.Substring(i, 1);
                    switch (kari)
                    {
                        case "+":
                            //先頭か判断
                            if (enzansilist.Count != 0)
                            {
                                strlist.Add(siki.Substring(enzansi + 1, i - enzansi - 1));  //演算子の位置から次の演算子までの数字を保持
                            }
                            else
                            {
                                strlist.Add(siki.Substring(enzansi, i - enzansi));  //演算子の位置から次の演算子までの数字を保持
                            }
                            enzansilist.Add(kari);                              //演算子を保持
                            enzansi = i;                                        //演算子の位置を更新
                            break;

                        case "-":
                            //先頭か判断
                            if (enzansilist.Count != 0)
                            {
                                strlist.Add(siki.Substring(enzansi + 1, i - enzansi - 1));  //演算子の位置から次の演算子までの数字を保持
                            }
                            else
                            {
                                strlist.Add(siki.Substring(enzansi, i - enzansi));  //演算子の位置から次の演算子までの数字を保持
                            }
                            enzansilist.Add(kari);                              //演算子を保持
                            enzansi = i;                                        //演算子の位置を更新
                            break;

                        case "%":
                            //先頭か判断
                            if (enzansilist.Count != 0)
                            {
                                strlist.Add(siki.Substring(enzansi + 1, i - enzansi - 1));  //演算子の位置から次の演算子までの数字を保持
                            }
                            else
                            {
                                strlist.Add(siki.Substring(enzansi, i - enzansi));  //演算子の位置から次の演算子までの数字を保持
                            }
                            enzansilist.Add(kari);                              //演算子を保持
                            enzansi = i;                                        //演算子の位置を更新
                            break;

                        case "/":
                            //先頭か判断
                            if (enzansilist.Count != 0)
                            {
                                strlist.Add(siki.Substring(enzansi + 1, i - enzansi - 1));  //演算子の位置から次の演算子までの数字を保持
                            }
                            else
                            {
                                strlist.Add(siki.Substring(enzansi, i - enzansi));  //演算子の位置から次の演算子までの数字を保持
                            }
                            enzansilist.Add(kari);                              //演算子を保持
                            enzansi = i;                                        //演算子の位置を更新
                            break;

                        case "*":
                            //先頭か判断
                            if (enzansilist.Count != 0)
                            {
                                strlist.Add(siki.Substring(enzansi + 1, i - enzansi - 1));  //演算子の位置から次の演算子までの数字を保持
                            }
                            else
                            {
                                strlist.Add(siki.Substring(enzansi, i - enzansi));  //演算子の位置から次の演算子までの数字を保持
                            }
                            enzansilist.Add(kari);                              //演算子を保持
                            enzansi = i;                                        //演算子の位置を更新
                            break;

                        default:
                            break;
                    }

                    //最後までループした場合最後の数値を取得する
                    if (i == siki.Length - 1)
                    {
                        strlist.Add(siki.Substring(enzansi + 1));
                    }

                }

                #region チェック関連
                //数字リストに異物混入していないか判断
                foreach (string item in strlist)
                {
                    //アイテムが空じゃないか判断
                    if (String.IsNullOrEmpty(item))
                    {
                        //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                        //とりあえず後回し
                        return 0;
                    }
                    //数字に変換可能か
                    if (!int.TryParse(item, out tryres))
                    {
                        //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                        //とりあえず後回し
                        return 0;
                    }
                    //StringからIntに変換して保持
                    numlist.Add(tryres);
                }
                #endregion

                for (int i = 0; i < enzansilist.Count; i++)
                {
                    kari = enzansilist[i].ToString();
                    //演算子を見て計算する
                    switch (kari)
                    {
                        case "%":
                            numlist[i] = numlist[i] % numlist[i + 1];   //演算子を挟んだ数値で計算
                            numlist.RemoveAt(i + 1);                    //計算後不要になった数値を削除
                            enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                            i = -1;
                            break;

                        case "/":
                            numlist[i] = numlist[i] / numlist[i + 1];
                            numlist.RemoveAt(i + 1);                    //計算後不要になった数値を削除
                            enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                            i = -1;
                            break;

                        case "*":
                            numlist[i] = numlist[i] * numlist[i + 1];
                            numlist.RemoveAt(i + 1);                    //計算後不要になった数値を削除
                            enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                            i = -1;
                            break;

                        default:
                            break;
                    }
                }

                for (int i = 0; i < enzansilist.Count; i++)
                {
                    kari = enzansilist[i].ToString();
                    //演算子を見て計算する
                    switch (kari)
                    {
                        case "+":
                            numlist[i] = numlist[i] + numlist[i + 1];
                            numlist.RemoveAt(i + 1);                    //計算後不要になった数値を削除
                            enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                            i = -1;
                            break;

                        case "-":
                            numlist[i] = numlist[i] - numlist[i + 1];
                            numlist.RemoveAt(i + 1);                    //計算後不要になった数値を削除
                            enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                            i = -1;
                            break;

                        default:
                            break;
                    }
                }

                result = numlist[0];    //先頭に最終計算結果が入っている・・・はずｗ

                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 演算用プロシージャ
        /// </summary>
        /// <param name="siki"></param>
        /// 備考：()入りの計算に対応
        /// <returns></returns>
        private int CalcProcVer3(string siki)
        {
            try
            {
                //式の数字を保持する
                List<string> strlist = new List<string>();
                //保持した数字をint型にして再保持する
                List<int> numlist = new List<int>();
                //演算子を保持する
                List<string> enzansilist = new List<string>();
                string kari = String.Empty;
                string numsafe = String.Empty;
                //左右の（）の個数にずれがないか判断するためのカウント変数
                int leftkakkocount = 0;
                int rightkakkocount = 0;
                int enzansi = 0;
                int tryres = 0;
                int result = 0;

                //空の時は処理を抜ける
                if (String.IsNullOrEmpty(siki))
                {
                    return 0;
                }

                //式の長さ分ループ
                for (int i = 0; i < siki.Length; i++)
                {
                    //一文字ずつ取得していく
                    kari = siki.Substring(i, 1);
                    switch (kari)
                    {
                        case "(":
                            strlist.Add(numsafe);   //演算子までの数字をリストに保持する
                            enzansilist.Add(kari);  //演算子をリストに保持する。
                            leftkakkocount++;       //(の数をカウントアップ
                            numsafe = String.Empty; //保持していた数字を初期化
                            break;

                        case ")":
                            strlist.Add(numsafe);   //演算子までの数字をリストに保持する
                            enzansilist.Add(kari);  //演算子をリストに保持する。
                            rightkakkocount++;       //)の数をカウントアップ
                            numsafe = String.Empty; //保持していた数字を初期化
                            break;

                        case "+":
                            strlist.Add(numsafe);   //演算子までの数字をリストに保持する
                            enzansilist.Add(kari);  //演算子をリストに保持する。
                            numsafe = String.Empty; //保持していた数字を初期化
                            break;

                        case "-":
                            strlist.Add(numsafe);   //演算子までの数字をリストに保持する
                            enzansilist.Add(kari);  //演算子をリストに保持する。
                            numsafe = String.Empty; //保持していた数字を初期化
                            break;

                        case "*":
                            strlist.Add(numsafe);   //演算子までの数字をリストに保持する
                            enzansilist.Add(kari);  //演算子をリストに保持する。
                            numsafe = String.Empty; //保持していた数字を初期化
                            break;

                        case "/":
                            strlist.Add(numsafe);   //演算子までの数字をリストに保持する
                            enzansilist.Add(kari);  //演算子をリストに保持する。
                            numsafe = String.Empty; //保持していた数字を初期化
                            break;

                        case "%":
                            strlist.Add(numsafe);   //演算子までの数字をリストに保持する
                            enzansilist.Add(kari);  //演算子をリストに保持する。
                            numsafe = String.Empty; //保持していた数字を初期化
                            break;

                        //数値の間は変数に後付しながら保持する
                        default:
                            numsafe = numsafe + kari;
                            break;
                    }

                    //最後までループした場合最後の数値を取得する
                    if (i == siki.Length - 1)
                    {
                        strlist.Add(numsafe);
                    }

                }

                #region チェック関連

                //空白要素すべて削除
                strlist.RemoveAll(x => x == String.Empty);

                //左右の（）数があっているか判断
                if (leftkakkocount != rightkakkocount)
                {
                    ViewBag.ErrorMessage = "左右のかっこの数があっていません。";
                    return 0;
                }

                //数字リストに異物混入していないか判断
                foreach (string item in strlist)
                {
                    //数字に変換可能か
                    if (!int.TryParse(item, out tryres))
                    {
                        //メッセージボックス（アラート）使いたいけど、JavaScriptの力が必要。
                        //とりあえず後回し
                        ViewBag.ErrorMessage = "数字に変換できない文字が入力されています。";
                        return 0;
                    }
                    //StringからIntに変換して保持
                    numlist.Add(tryres);
                }

                #endregion

                #region ()処理前

                //左かっこ判断用
                for (int j = 0; j < enzansilist.Count; j++)
                {
                    //演算子を取得
                    kari = enzansilist[j].ToString();

                    //左かっこの場合のみ次処理に入る
                    if (kari == "(")
                    {
                        //左かっこから右かっこまで用
                        for (int i = j; i < enzansilist.Count; i++)
                        {
                            kari = enzansilist[i].ToString();

                            //右かっこの場合ループを抜ける
                            if (kari == ")")
                            {
                                break;
                            }

                            //演算子を見て計算する
                            switch (kari)
                            {
                                case "%":
                                    numlist[i - 1] = numlist[i - 1] % numlist[i];  //演算子を挟んだ数値で計算
                                    numlist.RemoveAt(i );                    //計算後不要になった数値を削除
                                    enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                                    i = j - 1;
                                    break;

                                case "/":
                                    numlist[i - 1] = numlist[i - 1] / numlist[i];
                                    numlist.RemoveAt(i );                    //計算後不要になった数値を削除
                                    enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                                    i = j - 1;
                                    break;

                                case "*":
                                    numlist[i - 1] = numlist[i - 1] * numlist[i];
                                    numlist.RemoveAt(i );                    //計算後不要になった数値を削除
                                    enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                                    i = j - 1;
                                    break;

                                default:
                                    break;
                            }
                        }

                        //左かっこから右かっこまで用
                        for (int i = j; i < enzansilist.Count; i++)
                        {
                            kari = enzansilist[i].ToString();

                            //右かっこの場合ループを抜ける
                            if (kari == ")")
                            {
                                break;
                            }

                                kari = enzansilist[i].ToString();
                                //演算子を見て計算する
                                switch (kari)
                                {
                                    case "+":
                                        numlist[i-1] = numlist[i-1] + numlist[i];
                                        numlist.RemoveAt(i);                    //計算後不要になった数値を削除
                                        enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                                        i = j - 1;
                                        break;

                                    case "-":
                                        numlist[i-1] = numlist[i-1] - numlist[i];
                                        numlist.RemoveAt(i);                    //計算後不要になった数値を削除
                                        enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                                        i = j - 1;
                                        break;

                                    default:
                                        break;
                                }

                        }

                        enzansilist.RemoveAt(j);    //不要な(を削除
                        enzansilist.RemoveAt(j);    //不要な)を削除

                    }

                }
               
                #endregion

                #region ()処理後
                for (int i = 0; i < enzansilist.Count; i++)
                {
                    kari = enzansilist[i].ToString();
                    //演算子を見て計算する
                    switch (kari)
                    {
                        case "%":
                            numlist[i] = numlist[i] % numlist[i + 1];   //演算子を挟んだ数値で計算
                            numlist.RemoveAt(i + 1);                    //計算後不要になった数値を削除
                            enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                            i = -1;
                            break;

                        case "/":
                            numlist[i] = numlist[i] / numlist[i + 1];
                            numlist.RemoveAt(i + 1);                    //計算後不要になった数値を削除
                            enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                            i = -1;
                            break;

                        case "*":
                            numlist[i] = numlist[i] * numlist[i + 1];
                            numlist.RemoveAt(i + 1);                    //計算後不要になった数値を削除
                            enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                            i = -1;
                            break;

                        default:
                            break;
                    }
                }

                for (int i = 0; i < enzansilist.Count; i++)
                {
                    kari = enzansilist[i].ToString();
                    //演算子を見て計算する
                    switch (kari)
                    {
                        case "+":
                            numlist[i] = numlist[i] + numlist[i + 1];
                            numlist.RemoveAt(i + 1);                    //計算後不要になった数値を削除
                            enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                            i = -1;
                            break;

                        case "-":
                            numlist[i] = numlist[i] - numlist[i + 1];
                            numlist.RemoveAt(i + 1);                    //計算後不要になった数値を削除
                            enzansilist.RemoveAt(i);                    //計算後不要になった演算子を削除
                            i = -1;
                            break;

                        default:
                            break;
                    }
                }
                #endregion

                result = numlist[0];    //先頭に最終計算結果が入っている・・・はずｗ

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