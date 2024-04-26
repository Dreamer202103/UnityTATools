using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondEditionTools
{
    public abstract partial class MonoBehaviourSimplifyL
    {
        List<MsgRecordL> mMsgRecorderL = new List<MsgRecordL>();

        /*List����
         * List �б�ֻ�ܻ���һ����ֵ������ֻ�ô���һ���ṹ���洢���ǵ���Ϣ���Ͷ�Ӧ��ί�С�����ṹ��һ�������MsgRecord
         * ��һ�����ݽṹ����
         * �洢string���ͺ�Actionί�е�����
         * �ṹ��һ�������MsgRecord
         * ������
         */
        private class MsgRecordL
        {
            public string Name;
            public Action<object> OnMsgReceived;
        }

        protected void RegisterMsgL(string msgName,Action<object>onMsgReceived)
        {
            MsgDispatcher.Register(msgName, onMsgReceived);
            /*
             * ���������һ���������⣬��Ҫ������newʱ��Ѱַ��ɵ�
             * ����Ҫ���ľ��Ǽ���new�ķ�������
             */
            mMsgRecorderL.Add(new MsgRecordL
            {
                Name = msgName,
                OnMsgReceived = onMsgReceived
            });
        }
        protected abstract void OnBeforeDestroyL();
        private void OnDestroyL()
        {
            OnBeforeDestroyL();
            foreach(var msgrecord in mMsgRecorderL)
            {
                MsgDispatcher.UnRegister(msgrecord.Name, msgrecord.OnMsgReceived);
            }
            mMsgRecorderL.Clear();
        }
    }
    public class ListFunction : MonoBehaviourSimplifyL
    {
        protected override void OnBeforeDestroyL()
        {
            
        }

        private void Awake()
        {
            RegisterMsgL("Do", DoSomething);
            //Lambda���ʽ
            RegisterMsgL("Do1", _ => { });
            RegisterMsgL("Do2", _ => { });
            RegisterMsgL("Do3", _ => { });
        }

        private void DoSomething(object data)
        {

        }
    }
}
