using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondEditionTools
{
    //дһ��������࣬�����������abstract������
    //�����෽����ʹ�õ�ʱ��Ͳ����Լ���������ʵ����
    public abstract partial class MonoBehaviourSimplifyD
    {
        /*�ֵ������
         *�ֵ��������ע����Ϣ�Ĵ��λ��
         *ʹ���ֵ��Ҫ��֤�ֵ��е�Key��Ψһ��
         *�����Ǻܿ�����һ���ű��ж�һ���ؼ���ע���Ρ��������ֵ�������ݽṹ�Ͳ�������
         *�ֵ��ʺ���һЩ��ѯ�Ĺ�������List����֧�ּ�ֵ��
          */
        Dictionary<string, Action<object>> mMsgRegisterRecorderD = new Dictionary<string, Action<object>>();

        //Action<object> onMsgReceived��һ��ί�е�
        protected void RegisterMsgD(string msgName,Action<object> onMsgReceived)
        {
            //ע����Ϣ
            MsgDispatcher.Register(msgName, onMsgReceived);
            //�ֵ������Ϣ
            mMsgRegisterRecorderD.Add(msgName, onMsgReceived);
        }
        //����һ������ķ�����
        //�����������󷽷���Ŀ�ľ����������಻Ҫ��дOnDestroy
        /*
         * ����ͨ���������Եó���ʹ��MonoBehaviourSimplify���������
         * һ���ǣ���д�ű�֮ǰ�����������ű�Ҫ�̳�MonoBehaviourSimplify�����Ǽ̳�֮�󣬱���ᱨ����Ϊ��һ��
         * ���󷽷�����ʵ�֣�Ҳ����OnBeforeDestroy����ôʵ��������û��ͻ�֪�����MonoBehaviourSimplify���ˣ����Ƽ�
         * ��OnBeforeDestroy����ж���߼��ģ������Ƽ���OnDestroy��
         * 
         * �ڶ��֣��ű����������ˣ���������;��Ҫ���ɼ̳�MonoBehaviourSimplify���̳���֮��ͬ������
         * ������֮��MonoBehaviourSimplify�Ƽ���OnBeforeDestroy����ж���߼�����ʱ�������ǰ�Ľű��Ѿ�����
         * OnDestroy�߼����û��ͻ��OnDestory���߼�Ǩ�Ƶ�OnBeforeDestroy�
         */
        protected abstract void OnBeforeDestroy();
        private void OnDestroy()
        {
            OnBeforeDestroy();
            //�����ֵ����������
            foreach (var keyValuePair in mMsgRegisterRecorderD)
            {
                MsgDispatcher.UnRegister(keyValuePair.Key, keyValuePair.Value);
            }
            //�ֵ�
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
            //Lambda���ʽ
            RegisterMsgD("Do1", _ => { });
            RegisterMsgD("Do2", _ => { });
            RegisterMsgD("Do3", _ => { });
        }

        private void DoSomething(object data)
        {

        }


    }
}
