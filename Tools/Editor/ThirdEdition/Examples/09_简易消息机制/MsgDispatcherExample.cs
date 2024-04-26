using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    public class MsgDispatcherExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/ThirdEdition/Example/9.���׵���Ϣ����", false, 9)]
#endif
        private static void MenuClicked()
        {
            //Lambda������
            Action<object> OnMsgReceived = data => { Debug.LogFormat("��Ϣ1��{0}", data); };
            //ȫ����գ�ȷ��������Ч
            ThirdMsgDispatcher.UnRegisterAll("��Ϣ1");
            //ע��
            ThirdMsgDispatcher.Register("��Ϣ1", OnMsgReceived);
            ThirdMsgDispatcher.Register("��Ϣ1", OnMsgReceived);
            //����
            ThirdMsgDispatcher.Send("��Ϣ1", "Hello World");
            //ע��
            ThirdMsgDispatcher.UnRegister("��Ϣ1", OnMsgReceived);
            //����
            ThirdMsgDispatcher.Send("��Ϣ1", "Hello");
        }
        /*
        static void OnMsgReceived(object data)
        {
            Debug.LogFormat("��Ϣ1��{0}", data);
        }
        */
    }
}
