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

    private Dictionary<string, Buff> _dicBuff;

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
        _dicBuff = new Dictionary<string, Buff>();
        //Load buff data

        //Generate Test buff Data
        _dicBuff.Add("buff01" ,new Buff("buff01", "神行", "每消耗10点行动力，额外获得1点行动力。", BuffType.buff));

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

    private List<string> InitializeTestBuffList()
    {
        _listPlayerBuff = new List<string>();

        return _listPlayerBuff;
    }

}
