using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public int age = 10;
    public string name = "未命名";
    public float height = 177.5f;
    public bool sex = true;

    public List<int> list = new List<int>() { 1, 2, 3, 4 };

    public Dictionary<int, string> dic = new Dictionary<int, string>()
    {
        { 1,"123"},
        { 2,"234"}
    };

    public ItemInfo itemInfo = new ItemInfo(3, 99);

    public List<ItemInfo> itemList = new List<ItemInfo>() {
        new ItemInfo(1, 10),
        new ItemInfo(2, 20),
    };

    public Dictionary<int, ItemInfo> itemDic = new Dictionary<int, ItemInfo>()
    {
        { 3, new ItemInfo(3, 22)},
        { 4, new ItemInfo(4, 33)},
    };
}

public class ItemInfo
{
    public int id;
    public int num;

    public ItemInfo()
    {

    }

    public ItemInfo(int id, int num)
    {
        this.id = id;
        this.num = num;
    }
}


public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo p = new PlayerInfo();
        //需要把这个数据对象的信息 存储到硬盘
        PlayerPrefsDataMgr.Instance.SaveData(p, "Player1");

        //读取数据
        PlayerInfo p2 = PlayerPrefsDataMgr.Instance.LoadData(typeof(PlayerInfo), "Player1") as PlayerInfo;
        if (p2 == null)
        {
            Debug.LogError("p2 is null! Check LoadData method.");
        }
        else
        {
            Debug.Log($"p2.age: {p2.age}");
            Debug.Log($"p2.name: {p2.name}");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
