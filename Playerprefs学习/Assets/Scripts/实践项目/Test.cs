using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerInfo
{
    public int age = 22;
    public string name = "¿Ó ÿ‹≤";
    public float height = 170.1f;
    public Gender sex = Gender.Male;

    public List<int> list = new List<int>() {1, 2, 4, 5};
    public enum Gender
    {
        Male, 
        Female  
    }
}
public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo palyer = new PlayerInfo();

        PlayerPrefsDataMgr.Instance.SaveData(palyer, "player1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
