using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondEditionTools
{
    //partial�ؼ��֣����ֵġ���Ҫ���ϵ����ӹ��ܵ��࣬����ǰ���partial
    //ͨ��partial�ؼ��֣������Ͽ��Զ����е��࣬�������޵�����ʵ����
    public partial class MonoBehaviourSimplify : MonoBehaviour
    {
        /// <summary>
        /// ��Ա����
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
        [UnityEditor.MenuItem("Tools/SecondEdition/10.MonoBehaviour ��",false,10)]
#endif
        private static void MenuClicked()
        {
            //��δ����Ƕ�����������״̬
            //UnityEditor.EditorApplication�ýű��Զ����е�API
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject().AddComponent<Hide>();
        }

        protected override void OnBeforeDestroy()
        {
            
        }
    }
}
