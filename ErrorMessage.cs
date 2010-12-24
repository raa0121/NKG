using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace NKG
{
    //********************************************************************************
    //【クラス】エラーメッセージを表示するクラス
    //********************************************************************************
    public class ErrorMessage
    {
        //********************************************************************************
        //【クラス】エラーメッセージを表示する
        //********************************************************************************
        public static void Show(Exception ex, Assembly assembly, MethodBase method)
        {
            //============================================================
            //アセンブリのタイトルを取得する
            //============================================================
            AssemblyTitleAttribute titleAttribute =
                (AssemblyTitleAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute));
            string title = titleAttribute.Title;

            //============================================================
            //バージョンを取得する
            //============================================================
            string version = assembly.GetName().Version.ToString();

            //============================================================
            //エラーが発声したクラス名を取得する
            //============================================================
            string className = method.ReflectedType.FullName;

            //============================================================
            //エラーが発声した関数名を取得する
            //============================================================
            string functionName = method.Name;

            //============================================================
            //エラーメッセージを表示する
            //============================================================
            MessageBox.Show(
                "エラーが発声しました。" + Environment.NewLine +
                "アセンブリ名：" + title + Environment.NewLine +
                "バージョン：" + version + Environment.NewLine +
                "クラス名：" + className + Environment.NewLine +
                "関数名：" + functionName + Environment.NewLine +
                "エラー内容：" + ex.Message);

        }
    }
}
