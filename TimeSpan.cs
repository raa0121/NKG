using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace NKG
{
    //********************************************************************************
    //【構造体】時間間隔
    //********************************************************************************
    [Serializable]
    public struct TimeSpan
    {
        //********************************************************************************
        //【フィールド】
        //********************************************************************************
        //秒に換算した値
        private double _value;
        //再生時間ゼロ
        public static TimeSpan Zero = new TimeSpan(0.0);

        //********************************************************************************
        //【コンストラクタ】
        //seconds：秒に換算した値
        //********************************************************************************
        public TimeSpan(double seconds)
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
        //【プロパティ】秒に換算した値
        //********************************************************************************
        public double Seconds
        {
            get
            {
                try
                {
                    //============================================================
                    //フィールドの値をそのまま返す
                    //============================================================
                    return _value;
                }
                catch (Exception ex)
                {
                    ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                    return double.NaN;
                }
            }
        }

        //********************************************************************************
        //【単項演算子】+
        //********************************************************************************
        public static TimeSpan operator +(TimeSpan timeSpan)
        {
            try
            {
                return new TimeSpan(+timeSpan._value);
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return Zero;
            }
        }

        //********************************************************************************
        //【単項演算子】-
        //********************************************************************************
        public static TimeSpan operator -(TimeSpan timeSpan)
        {
            try
            {
                return new TimeSpan(-timeSpan._value);
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return Zero;
            }
        }

        //********************************************************************************
        //【二項演算子】+
        //********************************************************************************
        public static TimeSpan operator +(TimeSpan timeSpan1, TimeSpan timeSpan2)
        {
            try
            {
                return new TimeSpan(timeSpan1._value + timeSpan2._value);
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return Zero;
            }
        }

        //********************************************************************************
        //【二項演算子】-
        //********************************************************************************
        public static TimeSpan operator -(TimeSpan timeSpan1, TimeSpan timeSpan2)
        {
            try
            {
                return new TimeSpan(timeSpan1._value - timeSpan2._value);
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                return Zero;
            }
        }

        //********************************************************************************
        //【比較演算子】==
        //********************************************************************************
        public static bool operator ==(TimeSpan timeSpan1, TimeSpan timeSpan2)
        {
            try
            {
                return timeSpan1._value == timeSpan2._value;
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
        public static bool operator !=(TimeSpan timeSpan1, TimeSpan timeSpan2)
        {
            try
            {
                return timeSpan1._value != timeSpan2._value;
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
        public static bool operator <(TimeSpan timeSpan1, TimeSpan timeSpan2)
        {
            try
            {
                return timeSpan1._value < timeSpan2._value;
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
        public static bool operator <=(TimeSpan timeSpan1, TimeSpan timeSpan2)
        {
            try
            {
                return timeSpan1._value <= timeSpan2._value;
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
        public static bool operator >(TimeSpan timeSpan1, TimeSpan timeSpan2)
        {
            try
            {
                return timeSpan1._value > timeSpan2._value;
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
        public static bool operator >=(TimeSpan timeSpan1, TimeSpan timeSpan2)
        {
            try
            {
                return timeSpan1._value >= timeSpan2._value;
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
