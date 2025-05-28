using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
    public int id;
    public int num;
}
public class Person
{
    public string name;
    public int age;
    public float attackPower;
    public float defensePower;
    public List<Item> itemList;

    //记录数据唯一性的标识
    public string keyName;

    public void SaveDate(string keyName)
    {
        this.keyName = keyName;

        PlayerPrefs.SetString(keyName + "_name", name);
        PlayerPrefs.SetInt(keyName + "_age", age);
        PlayerPrefs.SetFloat(keyName +  "_attackPower", attackPower);
        PlayerPrefs.SetFloat(keyName + "_defensePower", defensePower);

        PlayerPrefs.Save();
    }

    public void LoadDate(string keyName)
    {
        name = PlayerPrefs.GetString(keyName + "_name", "未命名");
        age = PlayerPrefs.GetInt(keyName + "_age", 20);
        attackPower = PlayerPrefs.GetFloat(keyName + "_attackPower", 10f);
        defensePower = PlayerPrefs.GetFloat(keyName + "_defensePower", 10f);
    }
}
public class Lesson1_Exercise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Person person = new Person();
        person.LoadDate("player1");
        print(person.name);
        print(person.age);
        print(person.attackPower);
        print(person.defensePower);

        person.name = "张三";
        person.age = 22;
        person.attackPower = 22f;
        person.defensePower = 33f;
        person.SaveDate("player1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
