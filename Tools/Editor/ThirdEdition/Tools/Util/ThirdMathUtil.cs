using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ThirdEditionTools
{

    //partial�ؼ��֣����ֵġ���Ҫ���ϵ����ӹ��ܵ��࣬����ǰ���partial
    //ͨ��partial�ؼ��֣������Ͽ��Զ����е��࣬�������޵�����ʵ����
    public partial class ThirdMathUtil
    {
        public static bool ThirdPercent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }
        //���͵ķ���
        //�ṹ�еĲ��ֻ�ȫ�����Ϳ����Ȳ����ж��壬������ʱ��ȥ����
        //�������߼��ϵĸ��ã���ô���;��ǽṹ�ϵĸ���
        //params�ؼ��ֵ���˼�����������ǿɱ��
        public static T ThirdGetRandomValueFrom<T>(params T[] values)
        {
            return values[UnityEngine.Random.Range(0, values.Length)];
        }
    }

    
}
