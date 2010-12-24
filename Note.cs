using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace NKG
{
    //********************************************************************************
    //【クラス】ノート
    //********************************************************************************
    [Serializable]
    public class Note
    {
        //********************************************************************************
        //【フィールド】
        //********************************************************************************
        //再生時間
        protected PlayTime _time;
        //入力キー
        protected InputKey _key;

        //********************************************************************************
        //【コンストラクタ】
        //time：再生時間
        //********************************************************************************
        public Note(PlayTime time)
        {
            try
            {
                //============================================================
                //【フィールドに値を設定する】
                //============================================================
                _time = time;
                _key = new InputKey(0);
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
            }
        }

        //********************************************************************************
        //【コンストラクタ】
        //time：再生時間
        //inputKey：入力キー
        //********************************************************************************
        public Note(PlayTime time, InputKey key)
        {
            try
            {
                //============================================================
                //【フィールドに値を設定する】
                //============================================================
                _time = time;
                _key = key;
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
            }
        }

        //********************************************************************************
        //【プロパティ】再生時間
        //********************************************************************************
        public PlayTime Time
        {
            get
            {
                try
                {
                    return _time;
                }
                catch (Exception ex)
                {
                    ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                    return PlayTime.Empty;
                }
            }
            set
            {
                try
                {
                    _time = value;
                }
                catch (Exception ex)
                {
                    ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                }
            }
        }

        //********************************************************************************
        //【プロパティ】入力キー
        //********************************************************************************
        public InputKey Key
        {
            get
            {
                try
                {
                    return _key;
                }
                catch (Exception ex)
                {
                    ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                    return new InputKey(0);
                }
            }
            set
            {
                try
                {
                    _key = value;
                }
                catch (Exception ex)
                {
                    ErrorMessage.Show(ex, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
                }
            }
        }
    }
}
