using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

namespace NKG
{
    //********************************************************************************
    //【構造体】再生時間
    //********************************************************************************
    public struct PlayTime
    {
        //********************************************************************************
        //【フィールド】
        //********************************************************************************
        //秒に換算した値
        private double _value;
        //再生時間ゼロ
        public static PlayTime Zero = new PlayTime(0.0);
        //空の再生時間
        public static PlayTime Empty = new PlayTime(double.NaN);

        //********************************************************************************
        //【コンストラクタ】
        //********************************************************************************
        public PlayTime(double seconds)
        {
            try
            {
                //============================================================
                //【フィールドに値を設定する】
                //============================================================
                _value = seconds;
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                _value = 0.0;
            }
        }

        //********************************************************************************
        //【プロパティ】空の再生時間かどうか
        //********************************************************************************
        public bool IsEmpty
        {
            get
            {
                try
                {
                    //============================================================
                    //値がNaNかどうかをそのまま返す
                    //============================================================
                    return double.IsNaN(_value);
                }
                catch (Exception ex)
                {
                    ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                    return false;
                }
            }
        }

        //********************************************************************************
        //【メソッド】タイムタグ文字列から変換する
        //********************************************************************************
        public static PlayTime FromTimeTag(string timeTag)
        {
            try
            {
                //============================================================
                //"[xx:xx:xx]"でマッチする
                //============================================================
                Regex regex = new Regex("^\\[(\\d{2}):(\\d{2}):(\\d{2})\\]$");
                Match match = regex.Match(timeTag);

                //============================================================
                //マッチしなかった場合、空の再生時間を返す
                //============================================================
                if (!match.Success)
                {
                    return Empty;
                }

                //============================================================
                //各単位の値を取得する
                //============================================================
                double minutes, seconds, centiSeconds;
                minutes = int.Parse(match.Captures[0].Value);
                seconds = int.Parse(match.Captures[1].Value);
                centiSeconds = int.Parse(match.Captures[2].Value);

                //============================================================
                //各単位を合算した再生時間を返す
                //============================================================
                return new PlayTime(minutes * 60 + seconds + centiSeconds / 100.0);
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return Empty;
            }
        }

        //********************************************************************************
        //【メソッド】タイムタグ文字列に変換する
        //********************************************************************************
        public string ToTimeTag()
        {
            try
            {
                int minutes, seconds, centiSeconds;
                minutes = (int)(_value / 60);
                seconds = (int)((_value % 60) / 1);
                centiSeconds = (int)(((_value * 100) % 100) / 1);

                return "[" + minutes + ":" + seconds + ":" + centiSeconds + "]";
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return string.Empty;
            }
        }

        //********************************************************************************
        //【二項演算子】+
        //********************************************************************************
        public static PlayTime operator +(PlayTime playTime, TimeSpan timeSpan)
        {
            try
            {
                return new PlayTime(playTime._value + timeSpan.Seconds);
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return Empty;
            }
        }

        //********************************************************************************
        //【二項演算子】-
        //********************************************************************************
        public static PlayTime operator -(PlayTime playTime, TimeSpan timeSpan)
        {
            try
            {
                return new PlayTime(playTime._value - timeSpan.Seconds);
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return Empty;
            }
        }

        //********************************************************************************
        //【二項演算子】-
        //********************************************************************************
        public static TimeSpan operator -(PlayTime playTime1, PlayTime playTime2)
        {
            try
            {
                return new TimeSpan(playTime1._value - playTime2._value);
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return TimeSpan.Zero;
            }
        }

        //********************************************************************************
        //【比較演算子】==
        //********************************************************************************
        public static bool operator ==(PlayTime playTime1, PlayTime playTime2)
        {
            try
            {
                return playTime1._value == playTime2._value;
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return false;
            }
        }

        //********************************************************************************
        //【比較演算子】!=
        //********************************************************************************
        public static bool operator !=(PlayTime playTime1, PlayTime playTime2)
        {
            try
            {
                return playTime1._value != playTime2._value;
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return false;
            }
        }

        //********************************************************************************
        //【比較演算子】<
        //********************************************************************************
        public static bool operator <(PlayTime playTime1, PlayTime playTime2)
        {
            try
            {
                return playTime1._value < playTime2._value;
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return false;
            }
        }

        //********************************************************************************
        //【比較演算子】<=
        //********************************************************************************
        public static bool operator <=(PlayTime playTime1, PlayTime playTime2)
        {
            try
            {
                return playTime1._value <= playTime2._value;
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return false;
            }
        }

        //********************************************************************************
        //【比較演算子】>
        //********************************************************************************
        public static bool operator >(PlayTime playTime1, PlayTime playTime2)
        {
            try
            {
                return playTime1._value > playTime2._value;
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return false;
            }
        }

        //********************************************************************************
        //【比較演算子】>=
        //********************************************************************************
        public static bool operator >=(PlayTime playTime1, PlayTime playTime2)
        {
            try
            {
                return playTime1._value >= playTime2._value;
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return false;
            }
        }

        //********************************************************************************
        //【メソッド】等価かどうか比較する
        //********************************************************************************
        public override bool Equals(object obj)
        {
            try
            {
                return base.Equals(obj);
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return false;
            }
        }

        //********************************************************************************
        //【メソッド】ハッシュコードを取得する
        //********************************************************************************
        public override int GetHashCode()
        {
            try
            {
                return base.GetHashCode();
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return 0;
            }
        }
    }
}
