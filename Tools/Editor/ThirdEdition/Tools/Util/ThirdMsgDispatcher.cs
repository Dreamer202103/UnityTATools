using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    public class ThirdMsgDispatcher : MonoBehaviour
    {
        static Dictionary<string, Action<object>> mRegisteredMsgs = new Dictionary<string, Action<object>>();
        //注册事件功能
        public static void Register(string msgName, Action<object> onMsgReceived)
        {
            if (!mRegisteredMsgs.ContainsKey(msgName))
            {
                //_ => { }代表是空的Action _下滑线代表的是object。=> { }代表的是回调onMsgRecived空的
                //一个委托可以有多个回调
                mRegisteredMsgs.Add(msgName, _ => { });
            }
            mRegisteredMsgs[msgName] += onMsgReceived;
        }

        //实现注销功能
        public static void UnRegisterAll(string msgName)
        {
            //字典的去除成员
            mRegisteredMsgs.Remove(msgName);
        }

        public static void UnRegister(string msgName, Action<object> onMsgRecived)
        {
            if (mRegisteredMsgs.ContainsKey(msgName))
            {
                mRegisteredMsgs[msgName] -= onMsgRecived;
            }
        }

        //实现发送功能
        public static void Send(string msgName, object data)
        {
            if (mRegisteredMsgs.ContainsKey(msgName))
            {
                mRegisteredMsgs[msgName](data);
            }
        }
    }
}
