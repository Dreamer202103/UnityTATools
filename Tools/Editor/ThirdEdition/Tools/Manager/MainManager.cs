using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    //protected修饰词的权限是 子类可以去访问，外部不能访问，为继承产生的修饰词
    //枚举的关键词    enum
    //枚举经常是用来表示状态的，比如当前的环境是开发环境
    //枚举的声明
    public enum EnviromentMode
    {
        Developing,
        Test,
        Production,
    }
    //把MainManager写成一个抽象类
    //抽象关键词语 abstract
    public abstract class MainManager : MonoBehaviour
    {
        //声明枚举
        //Mode是成员变量
        public EnviromentMode Mode;

        //mSharedMode和mModeSetted是静态变量
        private static EnviromentMode mSharedMode;
        private static bool mModeSetted = false;

        //静态变量和成员变量的区别
        //从实用角度来说，如果要访问静态变量，我们需要通过类名去访问。
        //而成员变量，则需要通过对象去访问。
        //从用途角度来说，静态变量更多的是对整个项目做配置或者是记录等等，所以一般静态变量也叫做全局变量
        //而成员变量，则是记录对象本身的状态
        // Start is called before the first frame update 
        void Start()
        { 
            //只能赋值一次
            if(!mModeSetted)
            {
                mSharedMode = Mode;
                mModeSetted = true;
            }
            //逻辑语句
            //switch语句 
            switch (mSharedMode)
            {
                case EnviromentMode.Developing:
                    //测试逻辑
                    LaunchInDevelopingMode();
                    break;
                case EnviromentMode.Test:
                    //正常逻辑
                    LaunchInTestMode();
                    break;
                case EnviromentMode.Production:
                    LaunchInProductionMode();
                    break;
            }
        }

        //protected修饰词的权限是 子类可以去访问，外部不能访问，为继承产生的修饰词
        protected abstract void LaunchInDevelopingMode();
        protected abstract void LaunchInTestMode();
        protected abstract void LaunchInProductionMode();
    }
}
