using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDataMgr : MonoBehaviour
{
    //����ģʽ
    //������̬ ��̬˽�г�Ա���� ��̬������Ա���ԣ���Ա������
    //˽�й��캯��

    /// <summary>
    /// ���ݹ����� ͳһ�������ݵĴ洢�Ķ�ȡ
    /// </summary>
    private static PlayerPrefsDataMgr instance = new PlayerPrefsDataMgr();

    public static PlayerPrefsDataMgr Instance
    {
        get
        {
            return instance;
        }
    }

    private PlayerPrefsDataMgr()
    {

    }

    /// <summary>
    /// �洢����
    /// </summary>
    /// <param name="data">���ݶ���</param>
    /// <param name="keyName">����Ψһkey</param>
    public void SaveData(object data, string keyName)
    {
        //����Ҫͨ��Type�õ��������ݶ�������е��ֶ�
        //Ȼ����PlayerPrefs�����д洢
        
    }

    public object LoadData(Type type, string keyName)
    {
        //����object�������ʹ��Type����
        //��ҪĿ���ǽ�Լһ�д��루���ⲿ��
        //����������Ҫ��ȡһ��player���͵����������object��ͱ������ⲿnewһ��������
        //������Type����ֻ�ô���һ��Typetypeof��Player��Ȼ�������ڲ���̬����һ��������㷵�س���

        //�����㴫������ͺ�keyName
        //������洢����ʱ key��ƴ�ӹ������������ݵĻ�ȡ��ֵ���س�ȥ


        return null;
    }
}
