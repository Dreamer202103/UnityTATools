using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SecondEditionTools
{
    public partial class MonoBehaviourSimplify
    {
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

        protected void UnRegisterMsg(string msgName,Action<object>onMsgReceived)
        {
            var selectedRecords = mMsgRecorder.FindAll(recorder => recorder.Name == msgName && recorder.OnMsgReceived == onMsgReceived);
            selectedRecords.ForEach(selectedRecords =>
            {
                MsgDispatcher.UnRegister(selectedRecords.Name, selectedRecords.OnMsgReceived);
                mMsgRecorder.Remove(selectedRecords);
            });

            selectedRecords.Clear();
        }

        protected void SendMsg(string msgName,object data)
        {
            MsgDispatcher.Send(msgName, data);
        }
    }
    public class UnifyAPIStyle : MonoBehaviourSimplify
    {
        protected override void OnBeforeDestroy()
        {

        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/SecondEdition/14.统一 API 风格", false, 14)]

        private static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("MsgReceived").AddComponent<UnifyAPIStyle>();
        }
#endif
        private void Awake()
        {
            RegisterMsg("OK", data =>
            {
                Debug.Log(data);
                UnRegisterMsg("OK");
            });
        }

        private void Start()
        {
            SendMsg("OK", "hello");
            SendMsg("OK", "hello");
        }
    }
}
