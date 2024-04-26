using SecondEditionTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    
    //partial关键字，部分的。需要不断的增加功能的类，在类前面加partial
    //通过partial关键字，理论上可以对已有的类，进行无限的增加实例。
    public abstract partial class MonoBehaviourSimplify : MonoBehaviour
    {
        #region GameObjectSimplify
        /// <summary>
        /// 成员方法
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
        //对外调用的方法
        public void Delay(float seconds, Action onFinished)
        {
            StartCoroutine(DelayCoroutine(seconds, onFinished));
        }
        //Action是C#自定义的委托，就是动态方法。回调函数
        /*
         * namspace System
         * {
         *      public delegate void Action();
         *  }
         */
        //协程只能用private修饰
        private IEnumerator DelayCoroutine(float seconds, Action onFinished)
        {
            yield return new WaitForSeconds(seconds);
            onFinished();
        }
        #endregion

        #region Dispatcher
        /*
         *如何回收利用呢，答案是维护一个容器，比如List或者Queue、Stack栈等，也就是传说中的对象池
         * 由于我们的MsgRecord的作用仅仅是作为一个存储结构而已，而存储的顺序不是很重要，所以我们就用简单的Stack栈结构
         * 也就是栈，来作为MsgRecord对象池的容器
         */
        //声明一个列表
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
            //声明变量
            public string Name;
            public Action<object> OnMsgReceived;

            //由于这个对象池只给MsgRecord用，所以就在MsgRecord内部实现了
            private static readonly Stack<MsgRecord> mMsgRecordPool = new Stack<MsgRecord>();

            //Allocate是申请，也就是获取对象。
            //Allocate开辟内存的意思
            public static MsgRecord Allocate(string msgName, Action<object> onMsgReceived)
            {
                MsgRecord retMsgRecord = null;
                //三元运算符
                //Pop就是弹出栈的意思
                retMsgRecord = mMsgRecordPool.Count > 0 ? mMsgRecordPool.Pop() : new MsgRecord();
                retMsgRecord.Name = msgName;
                retMsgRecord.OnMsgReceived = onMsgReceived;
                return retMsgRecord;

            }
            //Recycle就是回收
            public void Recycle()
            {
                //数据重置
                Name = null;
                OnMsgReceived = null;
                mMsgRecordPool.Push(this);
            }
        }

        //实现注册
        protected void RegisterMsg(string msgName, Action<object> onMsgReceived)
        {
            MsgDispatcher.Register(msgName, onMsgReceived);
            //列表数据的增加
            mMsgRecorder.Add(MsgRecord.Allocate(msgName, onMsgReceived));
        }

        protected abstract void OnBeforeDestroy();
        //数据的注销
        private void OnDestroy()
        {
            OnBeforeDestroy();
            //遍历列表中数据
            foreach (var msgRecord in mMsgRecorder)
            {
                //注销数据
                MsgDispatcher.UnRegister(msgRecord.Name, msgRecord.OnMsgReceived);
                msgRecord.Recycle();
            }
            mMsgRecorder.Clear();
        }
        #endregion
    }
}
