using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondEditionTools
{
    //消息机制是解决两个脚本之间的访问的问题
    public class MsgDispatcher : MonoBehaviour
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

        public static void UnRegister(string msgName,Action<object> onMsgRecived)
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
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/SecondEdition/12.简易的消息机制", false, 12)]
#endif
        private static void MenuClicked()
        {
            //Lambda的引用
            Action<object> OnMsgReceived = data => { Debug.LogFormat("消息1：{0}", data); };
            //注册
            Register("消息1", OnMsgReceived);
            Register("消息1", OnMsgReceived);
            //发送
            Send("消息1", "Hello World");
            //注销
            UnRegister("消息1", OnMsgReceived);
            //发送
            Send("消息1", "Hello");
        }
        /*
        static void OnMsgReceived(object data)
        {
            Debug.LogFormat("消息1：{0}", data);
        }
        */
    }
}

