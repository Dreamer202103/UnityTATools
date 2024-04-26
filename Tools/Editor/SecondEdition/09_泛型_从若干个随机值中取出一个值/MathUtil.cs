using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondEditionTools
{
    public partial class MathUtil
    {
        //泛型的方法
        //结构中的部分或全部类型可以先不进行定义，到调用时再去定义
        //方法是逻辑上的复用，那么泛型就是结构上的复用
        //params关键字的意思是修饰数据是可变的
        public static T GetRandomValueFrom<T>(params T[] values)
        {
            return values[UnityEngine.Random.Range(0, values.Length)];
        }
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/SecondEdition/9.从若干个随机值中取出一个值",false,9)]
#endif
        private static void MenuClicked1()
        {
            var randomAge = GetRandomValueFrom(new float[] { 0.5f, 2, 3 });
            Debug.Log(randomAge);
        }
    }
}
