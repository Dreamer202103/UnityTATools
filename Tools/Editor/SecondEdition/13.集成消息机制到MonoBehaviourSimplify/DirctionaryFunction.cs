using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondEditionTools
{
    //写一个抽象的类，抽象的类是用abstract来修饰
    //抽象类方法在使用的时候就不能自己创建出来实例了
    public abstract partial class MonoBehaviourSimplifyD
    {
        /*字典的声明
         *字典的声明，注册消息的存放位置
         *使用字典就要保证字典中的Key是唯一的
         *而我们很可能在一个脚本中对一个关键字注册多次。这样用字典这个数据结构就不合理了
         *字典适合做一些查询的工作。而List并不支持键值对
          */
        Dictionary<string, Action<object>> mMsgRegisterRecorderD = new Dictionary<string, Action<object>>();

        //Action<object> onMsgReceived是一个委托的
        protected void RegisterMsgD(string msgName,Action<object> onMsgReceived)
        {
            //注册信息
            MsgDispatcher.Register(msgName, onMsgReceived);
            //字典添加信息
            mMsgRegisterRecorderD.Add(msgName, onMsgReceived);
        }
        //声明一个抽象的方法、
        //添加了这个抽象方法的目的就是提醒子类不要覆写OnDestroy
        /*
         * 我们通过分析可以得出，使用MonoBehaviourSimplify的两种情况
         * 一种是：在写脚本之前就想好了这个脚本要继承MonoBehaviourSimplify，但是继承之后，编译会报错，因为有一种
         * 抽象方法必须实现，也就是OnBeforeDestroy。那么实现这个，用户就会知道设计MonoBehaviourSimplify的人，是推荐
         * 用OnBeforeDestroy来做卸载逻辑的，并不推荐用OnDestroy。
         * 
         * 第二种：脚本本来就有了，但是在中途想要换成继承MonoBehaviourSimplify，继承了之后，同样报错，
         * 报错了之后MonoBehaviourSimplify推荐用OnBeforeDestroy来做卸载逻辑，这时候如果以前的脚本已经有了
         * OnDestroy逻辑，用户就会把OnDestory的逻辑迁移到OnBeforeDestroy里。
         */
        protected abstract void OnBeforeDestroy();
        private void OnDestroy()
        {
            OnBeforeDestroy();
            //遍历字典里面的数据
            foreach (var keyValuePair in mMsgRegisterRecorderD)
            {
                MsgDispatcher.UnRegister(keyValuePair.Key, keyValuePair.Value);
            }
            //字典
            mMsgRegisterRecorderD.Clear();
        }
    }

    public class DirctionaryFunction : MonoBehaviourSimplifyD
    {
        protected override void OnBeforeDestroy()
        {
        }
        private void Awake()
        {
            RegisterMsgD("Do", DoSomething);
            //Lambda表达式
            RegisterMsgD("Do1", _ => { });
            RegisterMsgD("Do2", _ => { });
            RegisterMsgD("Do3", _ => { });
        }

        private void DoSomething(object data)
        {

        }


    }
}
