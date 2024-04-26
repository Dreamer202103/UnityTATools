using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondEditionTools
{
    public partial class MathUtil
    {
        //���͵ķ���
        //�ṹ�еĲ��ֻ�ȫ�����Ϳ����Ȳ����ж��壬������ʱ��ȥ����
        //�������߼��ϵĸ��ã���ô���;��ǽṹ�ϵĸ���
        //params�ؼ��ֵ���˼�����������ǿɱ��
        public static T GetRandomValueFrom<T>(params T[] values)
        {
            return values[UnityEngine.Random.Range(0, values.Length)];
        }
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/SecondEdition/9.�����ɸ����ֵ��ȡ��һ��ֵ",false,9)]
#endif
        private static void MenuClicked1()
        {
            var randomAge = GetRandomValueFrom(new float[] { 0.5f, 2, 3 });
            Debug.Log(randomAge);
        }
    }
}
