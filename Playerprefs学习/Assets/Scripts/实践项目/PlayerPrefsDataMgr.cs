using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDataMgr : MonoBehaviour
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
