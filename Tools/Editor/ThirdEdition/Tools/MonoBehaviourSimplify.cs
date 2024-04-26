using SecondEditionTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    
    //partial�ؼ��֣����ֵġ���Ҫ���ϵ����ӹ��ܵ��࣬����ǰ���partial
    //ͨ��partial�ؼ��֣������Ͽ��Զ����е��࣬�������޵�����ʵ����
    public abstract partial class MonoBehaviourSimplify : MonoBehaviour
    {
        #region GameObjectSimplify
        /// <summary>
        /// ��Ա����
        /// </summary>
        public void Show()
        {
            ThirdGameObjectSimplify.Show(gameObject);
        }
        public void Hide()
        {
            ThirdGameObjectSimplify.Hide(gameObject);
        }
        #endregion

        #region TransformSimplify
        public void Identity()
        {
            ThirdTransformSimplify.ThirdIdentity(transform);
        }
        #endregion

        #region Delay
        //������õķ���
        public void Delay(float seconds, Action onFinished)
        {
            StartCoroutine(DelayCoroutine(seconds, onFinished));
        }
        //Action��C#�Զ����ί�У����Ƕ�̬�������ص�����
        /*
         * namspace System
         * {
         *      public delegate void Action();
         *  }
         */
        //Э��ֻ����private����
        private IEnumerator DelayCoroutine(float seconds, Action onFinished)
        {
            yield return new WaitForSeconds(seconds);
            onFinished();
        }
        #endregion

        #region Dispatcher
        /*
         *��λ��������أ�����ά��һ������������List����Queue��Stackջ�ȣ�Ҳ���Ǵ�˵�еĶ����
         * �������ǵ�MsgRecord�����ý�������Ϊһ���洢�ṹ���ѣ����洢��˳���Ǻ���Ҫ���������Ǿ��ü򵥵�Stackջ�ṹ
         * Ҳ����ջ������ΪMsgRecord����ص�����
         */
        //����һ���б�
        List<MsgRecord> mMsgRecorder = new List<MsgRecord>();

        protected void UnRegisterMsg(string msgName)
        {
            var selectedRecords = mMsgRecorder.FindAll(recorder => recorder.Name == msgName);
            selectedRecords.ForEach(selectedRecords =>
            {
                MsgDispatcher.UnRegister(selectedRecords.Name, selectedRecords.OnMsgReceived);
                mMsgRecorder.Remove(selectedRecords);
            });

            selectedRecords.Clear();
        }

        protected void UnRegisterMsg(string msgName, Action<object> onMsgReceived)
        {
            var selectedRecords = mMsgRecorder.FindAll(recorder => recorder.Name == msgName && recorder.OnMsgReceived == onMsgReceived);
            selectedRecords.ForEach(selectedRecords =>
            {
                MsgDispatcher.UnRegister(selectedRecords.Name, selectedRecords.OnMsgReceived);
                mMsgRecorder.Remove(selectedRecords);
            });

            selectedRecords.Clear();
        }

        protected void SendMsg(string msgName, object data)
        {
            MsgDispatcher.Send(msgName, data);
        }

        private class MsgRecord
        {
            //��������
            public string Name;
            public Action<object> OnMsgReceived;

            //������������ֻ��MsgRecord�ã����Ծ���MsgRecord�ڲ�ʵ����
            private static readonly Stack<MsgRecord> mMsgRecordPool = new Stack<MsgRecord>();

            //Allocate�����룬Ҳ���ǻ�ȡ����
            //Allocate�����ڴ����˼
            public static MsgRecord Allocate(string msgName, Action<object> onMsgReceived)
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
        protected void RegisterMsg(string msgName, Action<object> onMsgReceived)
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
        #endregion
    }
}
