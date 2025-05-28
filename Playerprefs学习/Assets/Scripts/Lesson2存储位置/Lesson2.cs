using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

/// <summary>
/// �������а�
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
/// ���а��б�
/// </summary>
public class RankListInfo
{
    public List<RankInfo> rankInfo;
    //Ψһkey��ʶ
    public string keyName;

    /// <summary>
    /// RankListInfo ��Ĺ��캯�������� LoatDate()
    /// ����ζ��ÿ�δ��� RankListInfo ����ʱ�������Զ����Դ� PlayerPrefs �������а����ݡ�
    /// </summary>
    public RankListInfo()
    {
        LoadDate();
    }

    /// <summary>
    /// ���һ��
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
        //�������а�����
        PlayerPrefs.SetInt("rankListNum", rankInfo.Count);
        for (int i = 0; i < rankInfo.Count; i++)
        {
            //��ÿһ�н��б���
            RankInfo info = rankInfo[i];
            PlayerPrefs.SetString("playerName" + i, info.playerName);
            PlayerPrefs.SetInt("playerScore" + i, info.playerScore);
            PlayerPrefs.SetFloat("playerTime" + i, info.playerTime);

            PlayerPrefs.Save();
        }
    }

    private void LoadDate()
    {
        //��ȡ����
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
            print("����"+ rankList.rankInfo[i].playerName);
            print("����" + rankList.rankInfo[i].playerScore);
            print("ʱ��" + rankList.rankInfo[i].playerTime);
        }

        rankList.Add("����ܲ", 99, 10f);
        rankList.SaveDate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
