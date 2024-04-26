using SecondEditionTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    public class DelayWithCoroutineExample : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/ThirdEdition/Example/8.��ʱ����", false, 8)]
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
