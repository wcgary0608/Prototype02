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

    public void InitializeStaticData()
    {
        InitializeBuffDictionary();

        string data = "";
        InitializePlayerStatusData(data);
    }

    private void InitializeBuffDictionary()
    {
        _dicBuff = new Dictionary<string, Buff>();
    }

    private void InitializePlayerStatusData(string rawData)
    {
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

}
