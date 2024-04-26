using SecondEditionTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    public class ToolsExample : MonoBehaviourSimplify
    {
        

#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/ThirdEdition/Example/10.框架实例", false, 10)]

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

            RegisterMsg("OK", data =>
            {
                Debug.Log(data);
                UnRegisterMsg("OK");
            });
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

        protected override void OnBeforeDestroy()
        {
            
        }
    }
}
