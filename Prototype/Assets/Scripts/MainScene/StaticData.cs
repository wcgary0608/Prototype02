using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData {

    #region Singleton
    private static StaticData _instance;
    public static StaticData Instance
    {
        get
        {
            if (_instance == null)
                _instance = new StaticData();
            return _instance;
        }
    }
    private StaticData() { }
    #endregion

    private Dictionary<string, BuffData> _dicBuffData;

    private List<string> _listPlayerStatusData;

    private List<string> _listPlayerBuff;

    public void InitializeStaticData()
    {
        InitializeBuffDictionary();

        string data = "";
        InitializePlayerStatusData(data);
    }

    private void InitializeBuffDictionary()
    {
        _dicBuffData = new Dictionary<string, BuffData>();
        //Load buff data

        //Generate Test buff Data
        _dicBuffData.Add("buff01" ,new BuffData("buff01", "神行", "神行\n每消耗10点行动力，额外获得1点行动力", BuffTypeEnum.buff));
        _dicBuffData.Add("buff02", new BuffData("buff02", "大周天", "大周天\n每消耗2点行动力，恢复1点内力", BuffTypeEnum.buff));
        _dicBuffData.Add("buff03", new BuffData("buff03", "中毒", "中毒\n每消耗2点行动力，损失1点气血", BuffTypeEnum.debuff));

    }

    private void InitializePlayerStatusData(string rawData)
    {
        InitializeTestBuffList();

        _listPlayerStatusData = new List<string>();

        if (rawData == "")
            GenerateDefaultPlayerStatus();
        else
            //Load Player data from json file
            return;

    }

    private void GenerateDefaultPlayerStatus()
    {

    }

    public List<string> InitializeTestBuffList()
    {
        _listPlayerBuff = new List<string>();

        _listPlayerBuff.Add("buff01");
        _listPlayerBuff.Add("buff02");
        _listPlayerBuff.Add("buff03");

        return _listPlayerBuff;
    }

    public BuffData GetBuffDataFromDic(string buffKey)
    {
        if (_dicBuffData.ContainsKey(buffKey))
            return _dicBuffData[buffKey];
        else
            Debug.Log("Invalid buffKey: " + buffKey);
            return null;
    }

}

public class BuffData
{
    public string buffKey;

    public string buffName;

    public string buffDescription;

    public BuffTypeEnum buffType;

    public BuffData(string key, string name, string description, BuffTypeEnum type)
    {
        buffKey = key;
        buffName = name;
        buffDescription = description;
        buffType = type;
    }
}