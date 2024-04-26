using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondEditionTools
{
    //partial关键字，部分的。需要不断的增加功能的类，在类前面加partial
    //通过partial关键字，理论上可以对已有的类，进行无限的增加实例。
    public partial class MonoBehaviourSimplify
    {
        //对外调用的方法
        public void Delay(float seconds,Action onFinished)
        {
            StartCoroutine(DelayCoroutine(seconds,onFinished));
        }
        //Action是C#自定义的委托，就是动态方法。回调函数
        /*
         * namspace System
         * {
         *      public delegate void Action();
         *  }
         */
        //协程只能用private修饰
        private IEnumerator DelayCoroutine(float seconds,Action onFinished)
        {
            yield return new WaitForSeconds(seconds);
            onFinished();
        }
    }
    public class DelayWithCoroutine : MonoBehaviourSimplify
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/SecondEdition/11.定时功能",false,11)]
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
            //lambbda表达式 ()=>{} 相当于实现里一个额没有名字的方法

            Delay(5.0f, () =>
            {
                Debug.Log("5 s 之后");
                Hide();
            });
        }
    }
}
