using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPrefsDataMgr
{
    //单例模式
    //两个静态 静态私有成员变量 静态公共成员属性（成员方法）
    //私有构造函数

    /// <summary>
    /// 数据管理类 统一管理数据的存储的读取
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
    /// 存储数据
    /// </summary>
    /// <param name="data">数据对象</param>
    /// <param name="keyName">数据唯一key</param>
    public void SaveData(object data, string keyName)
    {
        //就是要通过Type得到传入数据对象的所有的字段
        //然后结合PlayerPrefs来进行存储

        #region 得到所有字段
        Type dataType = data.GetType();
        //得到所有字段
        FieldInfo[] infos = dataType.GetFields();
        //for (int i = 0; i < infos.Length; i++)
        //{
        //    Debug.Log(infos[i]);
        //}
        #endregion
        #region 自定义key规则进行存储
        //自定义Key = keyName_数据类型_字段类型_变量名
        #endregion
        #region 遍历存储
        string saveKeyName;
        FieldInfo info;
        for (int i = 0; i < infos.Length; i++)
        {
            //通过FieldInfo来获取字段类型和字段的名字
            //字段的类型的名字 info.FieldType.Name
            //字段的名字 info.Name
            info = infos[i];
            saveKeyName = keyName + "_" + dataType.Name + "_" + info.FieldType.Name + "_" + info.Name;

            //获取字段对应的值
            object fieldValue = info.GetValue(data);

            Save(fieldValue, saveKeyName);

        }
        #endregion
    }

    /// <summary>
    /// 通过playerPrefs来存储 通用存储便于复用
    /// </summary>
    /// <param name="value"></param>
    /// <param name="keyName"></param>
    private void Save(object value, string keyName)
    {
        Type valueType = value.GetType();

        if (valueType == typeof(int))
        {
            Debug.Log("存储Int" + keyName);
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (valueType == typeof(float))
        {
            Debug.Log("存储Int" + keyName);
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if (valueType == typeof(string))
        {
            Debug.Log("存储Int" + keyName);
            PlayerPrefs.SetString(keyName, (string)value);
        }
        else if (valueType == typeof(bool))
        {
            Debug.Log("存储Int" + keyName);
            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        }
        //如何判断 泛型类的类型呢
        //通过反射 判断 父子关系
        //这相当于是判断 字段是不是IList的子类
        //本质是将List<int>转为多个int来存储
        else if (typeof(IList).IsAssignableFrom(valueType))
        {
            Debug.Log("存储List" + keyName);
            //父类装子类
            //安全的将value转换位IList类型
            IList list = value as IList;

            //存储数量
            PlayerPrefs.SetInt(keyName, list.Count);
            int index = 0;
            foreach (object obj in list)
            {
                //存储数值
                Save(obj, keyName + "_" + index);
                ++index;
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(valueType))
        {
            Debug.Log("存储Dictionary" + keyName);
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
        //基础数据类型都不是 可能就是自定义数据类型
        else
        {
            SaveData(value, keyName);
        }
    }

    public object LoadData(Type type, string keyName)
    {
        //不用object对象传入而使用Type传入
        //主要目的是节约一行代码（在外部）
        //假设现在你要读取一个player类型的数据如果是object你就必须在外部new一个对象传入
        //现在有Type的你只用传入一个Typetypeof（Player）然后我在内部动态创建一个对象给你返回出来

        //根据你传入的类型和keyName
        //依据你存储数据时 key的拼接规则来进行数据的获取赋值返回出去


        return null;
    }
}
