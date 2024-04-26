using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    public class MsgDispatcherExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/ThirdEdition/Example/9.简易的消息机制", false, 9)]
#endif
        private static void MenuClicked()
        {
            //Lambda的引用
            Action<object> OnMsgReceived = data => { Debug.LogFormat("消息1：{0}", data); };
            //全部清空，确保测试有效
            ThirdMsgDispatcher.UnRegisterAll("消息1");
            //注册
            ThirdMsgDispatcher.Register("消息1", OnMsgReceived);
            ThirdMsgDispatcher.Register("消息1", OnMsgReceived);
            //发送
            ThirdMsgDispatcher.Send("消息1", "Hello World");
            //注销
            ThirdMsgDispatcher.UnRegister("消息1", OnMsgReceived);
            //发送
            ThirdMsgDispatcher.Send("消息1", "Hello");
        }
        /*
        static void OnMsgReceived(object data)
        {
            Debug.LogFormat("消息1：{0}", data);
        }
        */
    }
}
