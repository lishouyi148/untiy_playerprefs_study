using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

/// <summary>
/// 单条排行榜
/// </summary>
public class RankInfo
{
    public string playerName;
    public int playerScore;
    public float playerTime;

    public RankInfo(string name, int score, float time)
    {
        playerName = name;
        playerScore = score;
        playerTime = time;
    }
}

/// <summary>
/// 排行榜列表
/// </summary>
public class RankListInfo
{
    public List<RankInfo> rankInfo;
    //唯一key标识
    public string keyName;

    /// <summary>
    /// RankListInfo 类的构造函数调用了 LoatDate()
    /// 这意味着每次创建 RankListInfo 对象时，都会自动尝试从 PlayerPrefs 加载排行榜数据。
    /// </summary>
    public RankListInfo()
    {
        LoadDate();
    }

    /// <summary>
    /// 添加一条
    /// </summary>
    /// <param name="name"></param>
    /// <param name="score"></param>
    /// <param name="time"></param>
    public void Add(string name, int score, float time)
    {
        rankInfo.Add(new RankInfo(name, score, time));
    }
    public void SaveDate()
    {
        //保存排行榜行数
        PlayerPrefs.SetInt("rankListNum", rankInfo.Count);
        for (int i = 0; i < rankInfo.Count; i++)
        {
            //对每一列进行保存
            RankInfo info = rankInfo[i];
            PlayerPrefs.SetString("playerName" + i, info.playerName);
            PlayerPrefs.SetInt("playerScore" + i, info.playerScore);
            PlayerPrefs.SetFloat("playerTime" + i, info.playerTime);

            PlayerPrefs.Save();
        }
    }

    private void LoadDate()
    {
        //读取行数
        int num = PlayerPrefs.GetInt("rankListNum", 0);
        rankInfo = new List<RankInfo>();
        for(int i = 0;i < num; i++)
        {
            RankInfo info = new RankInfo(PlayerPrefs.GetString("playerName" + i),
                                         PlayerPrefs.GetInt("playerScore" + i),
                                         PlayerPrefs.GetFloat("playerTime" + i));

            rankInfo.Add(info);
        }
    }
}

public class Lesson2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RankListInfo rankList = new RankListInfo();
        print(rankList.rankInfo.Count);

        for(int i = 0; i< rankList.rankInfo.Count;i++)
        {
            print("姓名"+ rankList.rankInfo[i].playerName);
            print("分数" + rankList.rankInfo[i].playerScore);
            print("时间" + rankList.rankInfo[i].playerTime);
        }

        rankList.Add("李守懿", 99, 10f);
        rankList.SaveDate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
