using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace SecondEditionTools
{
    public abstract partial class MonoBehaviourSimplify
    {
        /*
         *如何回收利用呢，答案是维护一个容器，比如List或者Queue、Stack栈等，也就是传说中的对象池
         * 由于我们的MsgRecord的作用仅仅是作为一个存储结构而已，而存储的顺序不是很重要，所以我们就用简单的Stack栈结构
         * 也就是栈，来作为MsgRecord对象池的容器
         */
        //声明一个列表
        List<MsgRecord> mMsgRecorder = new List<MsgRecord>();

        private class MsgRecord
        {
            //声明变量
            public string Name;
            public Action<object> OnMsgReceived;

            //由于这个对象池只给MsgRecord用，所以就在MsgRecord内部实现了
            private static readonly Stack<MsgRecord> mMsgRecordPool = new Stack<MsgRecord>();

            //Allocate是申请，也就是获取对象。
            //Allocate开辟内存的意思
            public static MsgRecord Allocate(string msgName,Action<object> onMsgReceived)
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
        protected void RegisterMsg(string msgName, Action<object>onMsgReceived)
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

    }
    public class StackFunction : MonoBehaviourSimplify
    {
        //protected修饰词的权限是 子类可以去访问，外部不能访问，为继承产生的修饰词
        protected override void OnBeforeDestroy()
        {
            
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/SecondEdition/13.消息机制集成到MonoBehaviourSimplify", false,13)]

        private static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("MsgReceived").AddComponent<StackFunction>();
        }
#endif
        private void Awake()
        {
            RegisterMsg("Do", DoSomething);
            //Lambda表达式
            RegisterMsg("Do1", _ => { });
            RegisterMsg("Do2", _ => { });
            RegisterMsg("Do3", _ => { });
        }

        //协程
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
