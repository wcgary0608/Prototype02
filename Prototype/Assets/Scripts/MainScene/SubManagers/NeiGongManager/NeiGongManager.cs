using System.Collections.Generic;
using UnityEngine;

public class NeiGongManager : IGameManager
{

    public int ForcePointValue { get; set; }

    private Dictionary<string, NeiGong> _dicAllNeiGong = new Dictionary<string, NeiGong>();
    public Dictionary<string, NeiGong> DicAllNeiGong
    {
        get { return _dicAllNeiGong; }
    }

    public string SelectedNeiGongId { get; set; }

    public int CurChapterIndex { get; set; }



    public NeiGongManager(MainSceneTreeNodeManager center) : base(center)
    {
        
    }

    public override void Initialize()
    {
        ForcePointValue = 50;
        InitializeAllNeiGong();
       
    }

    public override void Release()
    {
    }

    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
    }

    public void InitializeAllNeiGong()
    {
        NeiGongData.Initialize();
        List<string> listNeiGong = new List<string>() {"n1", "n2" };

        foreach(string key in listNeiGong)
        {
            string[] data = NeiGongData.DicNeiGongData[key];
            NeiGong temp = new NeiGong(data);
            _dicAllNeiGong.Add(key, temp);
        }

        SelectedNeiGongId = listNeiGong[0];

    }

    public NeiGong GetSpecificNeiGong(string id)
    {
        return _dicAllNeiGong[id];
    }


}