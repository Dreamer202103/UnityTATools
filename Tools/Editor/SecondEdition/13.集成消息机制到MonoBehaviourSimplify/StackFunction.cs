using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace SecondEditionTools
{
    public abstract partial class MonoBehaviourSimplify
    {
        /*
         *��λ��������أ�����ά��һ������������List����Queue��Stackջ�ȣ�Ҳ���Ǵ�˵�еĶ����
         * �������ǵ�MsgRecord�����ý�������Ϊһ���洢�ṹ���ѣ����洢��˳���Ǻ���Ҫ���������Ǿ��ü򵥵�Stackջ�ṹ
         * Ҳ����ջ������ΪMsgRecord����ص�����
         */
        //����һ���б�
        List<MsgRecord> mMsgRecorder = new List<MsgRecord>();

        private class MsgRecord
        {
            //��������
            public string Name;
            public Action<object> OnMsgReceived;

            //������������ֻ��MsgRecord�ã����Ծ���MsgRecord�ڲ�ʵ����
            private static readonly Stack<MsgRecord> mMsgRecordPool = new Stack<MsgRecord>();

            //Allocate�����룬Ҳ���ǻ�ȡ����
            //Allocate�����ڴ����˼
            public static MsgRecord Allocate(string msgName,Action<object> onMsgReceived)
            {
                MsgRecord retMsgRecord = null;
                //��Ԫ�����
                //Pop���ǵ���ջ����˼
                retMsgRecord = mMsgRecordPool.Count > 0 ? mMsgRecordPool.Pop() : new MsgRecord();
                retMsgRecord.Name = msgName;
                retMsgRecord.OnMsgReceived = onMsgReceived;
                return retMsgRecord;

            }
            //Recycle���ǻ���
            public void Recycle()
            {
                //��������
                Name = null;
                OnMsgReceived = null;
                mMsgRecordPool.Push(this);
            }
        }

        //ʵ��ע��
        protected void RegisterMsg(string msgName, Action<object>onMsgReceived)
        {
            MsgDispatcher.Register(msgName, onMsgReceived);
            //�б����ݵ�����
            mMsgRecorder.Add(MsgRecord.Allocate(msgName, onMsgReceived));
        }
           
        protected abstract void OnBeforeDestroy();
        //���ݵ�ע��
        private void OnDestroy()
        {
            OnBeforeDestroy();
            //�����б�������
            foreach (var msgRecord in mMsgRecorder)
            {
                //ע������
                MsgDispatcher.UnRegister(msgRecord.Name, msgRecord.OnMsgReceived);
                msgRecord.Recycle();
            }
            mMsgRecorder.Clear();
        }

    }
    public class StackFunction : MonoBehaviourSimplify
    {
        //protected���δʵ�Ȩ���� �������ȥ���ʣ��ⲿ���ܷ��ʣ�Ϊ�̳в��������δ�
        protected override void OnBeforeDestroy()
        {
            
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/SecondEdition/13.��Ϣ���Ƽ��ɵ�MonoBehaviourSimplify", false,13)]

        private static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("MsgReceived").AddComponent<StackFunction>();
        }
#endif
        private void Awake()
        {
            RegisterMsg("Do", DoSomething);
            //Lambda���ʽ
            RegisterMsg("Do1", _ => { });
            RegisterMsg("Do2", _ => { });
            RegisterMsg("Do3", _ => { });
        }

        //Э��
        private IEnumerator Start()
        {
            MsgDispatcher.Send("Do", "Hello");
            yield return new WaitForSeconds(1.0f);
            MsgDispatcher.Send("Do", "Hello");
        }

        private void DoSomething(object data)
        {
            Debug.LogFormat("Received Do msg:{0}", data);
        }
    }
}
