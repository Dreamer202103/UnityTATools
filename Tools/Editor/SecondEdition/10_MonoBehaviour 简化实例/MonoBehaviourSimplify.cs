using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondEditionTools
{
    //partial关键字，部分的。需要不断的增加功能的类，在类前面加partial
    //通过partial关键字，理论上可以对已有的类，进行无限的增加实例。
    public partial class MonoBehaviourSimplify : MonoBehaviour
    {
        /// <summary>
        /// 成员方法
        /// </summary>
        public void Show()
        {
            GameObjectSimplify.Show(gameObject);
        }
        public void Hide()
        {
            GameObjectSimplify.Hide(gameObject);
        }
        public void Identity()
        {
            TransformSimplify.Identity(transform);
        }
    }
    public class Hide : MonoBehaviourSimplify
    {
        private void Awake()
        {
            Hide();
        }
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/SecondEdition/10.MonoBehaviour 简化",false,10)]
#endif
        private static void MenuClicked()
        {
            //这段代码是对引擎是运行状态
            //UnityEditor.EditorApplication让脚本自动运行的API
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject().AddComponent<Hide>();
        }

        protected override void OnBeforeDestroy()
        {
            
        }
    }
}
