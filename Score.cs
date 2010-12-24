using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Xml.Serialization;

namespace NKG
{
    //********************************************************************************
    //【クラス】譜面
    //********************************************************************************
    [Serializable]
    public class Score
    {
        //********************************************************************************
        //【フィールド】
        //********************************************************************************
        //ノートのリスト
        protected List<Note> _notes;

        //********************************************************************************
        //【コンストラクタ】
        //********************************************************************************
        public Score()
        {
            try
            {
                //============================================================
                //【フィールドをインスタンス化する】
                //============================================================
                _notes = new List<Note>();
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
            }
        }

        //********************************************************************************
        //【プロパティ】ノートのリスト
        //********************************************************************************
        public List<Note> Notes
        {
            get
            {
                try
                {
                    return _notes;
                }
                catch (Exception ex)
                {
                    ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                    return null;
                }
            }
            set
            {
                try
                {
                    _notes = value;
                }
                catch (Exception ex)
                {
                    ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                }
            }
        }

        //********************************************************************************
        //【プロパティ】タイムタグテキストファイルから生成する
        //fileName：読み込むタイムタグテキストファイルの名前
        //********************************************************************************
        public static Score FromTimeTagTextFile(string fileName)
        {
            try
            {
                Score score = new Score();
                StreamReader reader = new StreamReader(fileName, Encoding.GetEncoding("Shift-JIS"));

                while (!reader.EndOfStream)
                {
                    //============================================================
                    //1行読み取る
                    //============================================================
                    string line = reader.ReadLine();

                    //============================================================
                    //読み込んだ行を"[xx:xx:xx]○○"でマッチする
                    //============================================================
                    Regex regex = new Regex("(\\[\\d{2}:\\d{2}:\\d{2}\\]).*");
                    Match match = regex.Match(line);

                    //============================================================
                    //マッチしたタイムタグを再生時間に変換する
                    //============================================================
                    PlayTime time = PlayTime.FromTimeTag(match.Captures[0].Value);

                    //============================================================
                    //再生時間からノートをインスタンス化する
                    //============================================================
                    Note note = new Note(time);

                    //============================================================
                    //ノートを譜面のノートリストに追加する
                    //============================================================
                    score.Notes.Add(note);
                }

                //============================================================
                //リーダーを閉じる
                //============================================================
                reader.Close();

                //============================================================
                //譜面を返す
                //============================================================
                return score;
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return null;
            }
        }

        //********************************************************************************
        //【プロパティ】XMLファイルからデシリアライズする
        //fileName：読み込むXMLファイルの名前
        //********************************************************************************
        public static Score Deserialize(string fileName)
        {
            try
            {
                FileStream stream = new FileStream(fileName, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(Score));
                Score score = (Score)serializer.Deserialize(stream);
                stream.Close();
                return score;
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return null;
            }
        }

        //********************************************************************************
        //【プロパティ】XMLファイルからシリアライズする
        //fileName：書き込むXMLファイルの名前
        //********************************************************************************
        public void Serialize(string fileName)
        {
            try
            {
                FileStream stream = new FileStream(fileName, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(Score));
                serializer.Serialize(stream, this);
                stream.Close();
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
            }
        }
    }
}
