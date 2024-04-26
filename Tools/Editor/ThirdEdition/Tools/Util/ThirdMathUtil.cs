using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ThirdEditionTools
{

    //partial关键字，部分的。需要不断的增加功能的类，在类前面加partial
    //通过partial关键字，理论上可以对已有的类，进行无限的增加实例。
    public partial class ThirdMathUtil
    {
        public static bool ThirdPercent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }
        //泛型的方法
        //结构中的部分或全部类型可以先不进行定义，到调用时再去定义
        //方法是逻辑上的复用，那么泛型就是结构上的复用
        //params关键字的意思是修饰数据是可变的
        public static T ThirdGetRandomValueFrom<T>(params T[] values)
        {
            return values[UnityEngine.Random.Range(0, values.Length)];
        }
    }

    
}
