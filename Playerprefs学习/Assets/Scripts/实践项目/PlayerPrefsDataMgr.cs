using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPrefsDataMgr
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

        #region �õ������ֶ�
        Type dataType = data.GetType();
        //�õ������ֶ�
        FieldInfo[] infos = dataType.GetFields();
        //for (int i = 0; i < infos.Length; i++)
        //{
        //    Debug.Log(infos[i]);
        //}
        #endregion
        #region �Զ���key������д洢
        //�Զ���Key = keyName_��������_�ֶ�����_������
        #endregion
        #region �����洢
        string saveKeyName;
        FieldInfo info;
        for (int i = 0; i < infos.Length; i++)
        {
            //ͨ��FieldInfo����ȡ�ֶ����ͺ��ֶε�����
            //�ֶε����͵����� info.FieldType.Name
            //�ֶε����� info.Name
            info = infos[i];
            saveKeyName = keyName + "_" + dataType.Name + "_" + info.FieldType.Name + "_" + info.Name;

            //��ȡ�ֶζ�Ӧ��ֵ
            object fieldValue = info.GetValue(data);

            Save(fieldValue, saveKeyName);

        }
        #endregion
    }

    /// <summary>
    /// ͨ��playerPrefs���洢 ͨ�ô洢���ڸ���
    /// </summary>
    /// <param name="value"></param>
    /// <param name="keyName"></param>
    private void Save(object value, string keyName)
    {
        Type valueType = value.GetType();

        if (valueType == typeof(int))
        {
            Debug.Log("�洢Int" + keyName);
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (valueType == typeof(float))
        {
            Debug.Log("�洢Int" + keyName);
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if (valueType == typeof(string))
        {
            Debug.Log("�洢Int" + keyName);
            PlayerPrefs.SetString(keyName, (string)value);
        }
        else if (valueType == typeof(bool))
        {
            Debug.Log("�洢Int" + keyName);
            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        }
        //����ж� �������������
        //ͨ������ �ж� ���ӹ�ϵ
        //���൱�����ж� �ֶ��ǲ���IList������
        //�����ǽ�List<int>תΪ���int���洢
        else if (typeof(IList).IsAssignableFrom(valueType))
        {
            Debug.Log("�洢List" + keyName);
            //����װ����
            //��ȫ�Ľ�valueת��λIList����
            IList list = value as IList;

            //�洢����
            PlayerPrefs.SetInt(keyName, list.Count);
            int index = 0;
            foreach (object obj in list)
            {
                //�洢��ֵ
                Save(obj, keyName + "_" + index);
                ++index;
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(valueType))
        {
            Debug.Log("�洢Dictionary" + keyName);
            IDictionary dict = value as IDictionary;

            PlayerPrefs.SetInt(keyName, dict.Count);

            int index = 0;
            foreach (object key in dict.Keys)
            {
                Save(key, keyName + "_key_" + index);
                Save(dict[key], keyName + "_value_" + index);
                ++index;
            }
        }
        //�����������Ͷ����� ���ܾ����Զ�����������
        else
        {
            SaveData(value, keyName);
        }
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
