using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondEditionTools
{
    //��Ϣ�����ǽ�������ű�֮��ķ��ʵ�����
    public class MsgDispatcher : MonoBehaviour
    {
        static Dictionary<string, Action<object>> mRegisteredMsgs = new Dictionary<string, Action<object>>();
        //ע���¼�����
        public static void Register(string msgName, Action<object> onMsgReceived)
        {
            if (!mRegisteredMsgs.ContainsKey(msgName))
            {
                //_ => { }�����ǿյ�Action _�»��ߴ������object��=> { }������ǻص�onMsgRecived�յ�
                //һ��ί�п����ж���ص�
                mRegisteredMsgs.Add(msgName, _ => { });
            }
            mRegisteredMsgs[msgName] += onMsgReceived;
        }

        //ʵ��ע������
        public static void UnRegisterAll(string msgName)
        {
            //�ֵ��ȥ����Ա
            mRegisteredMsgs.Remove(msgName);
        }

        public static void UnRegister(string msgName,Action<object> onMsgRecived)
        {
            if (mRegisteredMsgs.ContainsKey(msgName))
            {
                mRegisteredMsgs[msgName] -= onMsgRecived;
            }
        }

        //ʵ�ַ��͹���
        public static void Send(string msgName, object data)
        {
            if (mRegisteredMsgs.ContainsKey(msgName))
            {
                mRegisteredMsgs[msgName](data);
            }  
        }
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/SecondEdition/12.���׵���Ϣ����", false, 12)]
#endif
        private static void MenuClicked()
        {
            //Lambda������
            Action<object> OnMsgReceived = data => { Debug.LogFormat("��Ϣ1��{0}", data); };
            //ע��
            Register("��Ϣ1", OnMsgReceived);
            Register("��Ϣ1", OnMsgReceived);
            //����
            Send("��Ϣ1", "Hello World");
            //ע��
            UnRegister("��Ϣ1", OnMsgReceived);
            //����
            Send("��Ϣ1", "Hello");
        }
        /*
        static void OnMsgReceived(object data)
        {
            Debug.LogFormat("��Ϣ1��{0}", data);
        }
        */
    }
}

