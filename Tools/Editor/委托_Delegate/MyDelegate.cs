using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MyDelegate0
{

//�û���������
//ί�����͵�������ί�п����������棬Ҳ�����������������
//ί�еĹؼ���delegate
public delegate void MyDel();
public class MyDelegate : MonoBehaviour
{
    //�������͵�
    private int a;
    private string b;
    private float c;
    private ClassA classA;
    //ί�������洢һ��������������
    //����ί�б���
    private MyDel d1;
    private MyDel d2;
    private MyDel d3;

    //�������оͿ������нű�
    [ContextMenu("���ÿ������")]
    // Start is called before the first frame update
    void Start()
    {
        classA = new ClassA();
        //ί�еĳ�ʼ��
        d1 = new MyDel(Function02);
        d2 = Function01;
        //ί���ǿ����üӷ���ϵ�
        d3 = d1 + d2;
        //ί���ڵ���ʱ��Ҫ�ж�һ��ί���Ƿ�Ϊ��
        if (d3 != null)
        {
            //ί�еĵ���
            d3();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void Function01()
    {
        Debug.Log("ί��Function01");
    }

    void Function02()
    {
        Debug.Log("ί��Function02");
    }

    void Function03(string s)
    {

    }
}
public class ClassA
{

}

}
