using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MyDelegate0
{

//用户定义类型
//委托类型的声明，委托可以在类里面，也可以在类的外面声明
//委托的关键字delegate
public delegate void MyDel();
public class MyDelegate : MonoBehaviour
{
    //声明整型的
    private int a;
    private string b;
    private float c;
    private ClassA classA;
    //委托用来存储一个或多个方法的类
    //声明委托变量
    private MyDel d1;
    private MyDel d2;
    private MyDel d3;

    //不用运行就可以运行脚本
    [ContextMenu("调用快捷命令")]
    // Start is called before the first frame update
    void Start()
    {
        classA = new ClassA();
        //委托的初始化
        d1 = new MyDel(Function02);
        d2 = Function01;
        //委托是可以用加法组合的
        d3 = d1 + d2;
        //委托在调用时，要判断一下委托是否为空
        if (d3 != null)
        {
            //委托的调用
            d3();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void Function01()
    {
        Debug.Log("委托Function01");
    }

    void Function02()
    {
        Debug.Log("委托Function02");
    }

    void Function03(string s)
    {

    }
}
public class ClassA
{

}

}
