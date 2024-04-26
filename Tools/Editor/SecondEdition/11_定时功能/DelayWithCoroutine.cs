using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondEditionTools
{
    //partial�ؼ��֣����ֵġ���Ҫ���ϵ����ӹ��ܵ��࣬����ǰ���partial
    //ͨ��partial�ؼ��֣������Ͽ��Զ����е��࣬�������޵�����ʵ����
    public partial class MonoBehaviourSimplify
    {
        //������õķ���
        public void Delay(float seconds,Action onFinished)
        {
            StartCoroutine(DelayCoroutine(seconds,onFinished));
        }
        //Action��C#�Զ����ί�У����Ƕ�̬�������ص�����
        /*
         * namspace System
         * {
         *      public delegate void Action();
         *  }
         */
        //Э��ֻ����private����
        private IEnumerator DelayCoroutine(float seconds,Action onFinished)
        {
            yield return new WaitForSeconds(seconds);
            onFinished();
        }
    }
    public class DelayWithCoroutine : MonoBehaviourSimplify
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/SecondEdition/11.��ʱ����",false,11)]
        private static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject().AddComponent<DelayWithCoroutine>();
        }

        protected override void OnBeforeDestroy()
        {
            
        }
#endif
        // Start is called before the first frame update
        void Start()
        {
            //lambbda���ʽ ()=>{} �൱��ʵ����һ����û�����ֵķ���

            Delay(5.0f, () =>
            {
                Debug.Log("5 s ֮��");
                Hide();
            });
        }
    }
}
