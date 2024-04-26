using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    public class ThirdMsgDispatcher : MonoBehaviour
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

        public static void UnRegister(string msgName, Action<object> onMsgRecived)
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
    }
}
