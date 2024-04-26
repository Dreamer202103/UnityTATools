using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    //protected���δʵ�Ȩ���� �������ȥ���ʣ��ⲿ���ܷ��ʣ�Ϊ�̳в��������δ�
    //ö�ٵĹؼ���    enum
    //ö�پ�����������ʾ״̬�ģ����統ǰ�Ļ����ǿ�������
    //ö�ٵ�����
    public enum EnviromentMode
    {
        Developing,
        Test,
        Production,
    }
    //��MainManagerд��һ��������
    //����ؼ����� abstract
    public abstract class MainManager : MonoBehaviour
    {
        //����ö��
        //Mode�ǳ�Ա����
        public EnviromentMode Mode;

        //mSharedMode��mModeSetted�Ǿ�̬����
        private static EnviromentMode mSharedMode;
        private static bool mModeSetted = false;

        //��̬�����ͳ�Ա����������
        //��ʵ�ýǶ���˵�����Ҫ���ʾ�̬������������Ҫͨ������ȥ���ʡ�
        //����Ա����������Ҫͨ������ȥ���ʡ�
        //����;�Ƕ���˵����̬����������Ƕ�������Ŀ�����û����Ǽ�¼�ȵȣ�����һ�㾲̬����Ҳ����ȫ�ֱ���
        //����Ա���������Ǽ�¼�������״̬
        // Start is called before the first frame update 
        void Start()
        { 
            //ֻ�ܸ�ֵһ��
            if(!mModeSetted)
            {
                mSharedMode = Mode;
                mModeSetted = true;
            }
            //�߼����
            //switch��� 
            switch (mSharedMode)
            {
                case EnviromentMode.Developing:
                    //�����߼�
                    LaunchInDevelopingMode();
                    break;
                case EnviromentMode.Test:
                    //�����߼�
                    LaunchInTestMode();
                    break;
                case EnviromentMode.Production:
                    LaunchInProductionMode();
                    break;
            }
        }

        //protected���δʵ�Ȩ���� �������ȥ���ʣ��ⲿ���ܷ��ʣ�Ϊ�̳в��������δ�
        protected abstract void LaunchInDevelopingMode();
        protected abstract void LaunchInTestMode();
        protected abstract void LaunchInProductionMode();
    }
}
