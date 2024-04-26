using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondEditionTools
{
    public abstract partial class MonoBehaviourSimplifyL
    {
        List<MsgRecordL> mMsgRecorderL = new List<MsgRecordL>();

        /*List方法
         * List 列表。只能缓存一个数值。我们只好创建一个结构来存储我们的消息名和对应的委托。这个结构是一个类叫做MsgRecord
         * 是一个数据结构的类
         * 存储string类型和Action委托的数据
         * 结构是一个类叫做MsgRecord
         * 构造器
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
             * 这样会造成一个性能问题，主要就是有new时候寻址造成的
             * 我们要做的就是减少new的发生次数
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
            //Lambda表达式
            RegisterMsgL("Do1", _ => { });
            RegisterMsgL("Do2", _ => { });
            RegisterMsgL("Do3", _ => { });
        }

        private void DoSomething(object data)
        {

        }
    }
}
