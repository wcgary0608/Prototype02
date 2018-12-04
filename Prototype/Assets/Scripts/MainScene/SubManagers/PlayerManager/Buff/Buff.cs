using Assets.Scripts.MainScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff{

    private string _buffKey;

    private string _buffName;

    private string _buffDescription;

    private BuffTypeEnum _buffType;

    private IBuffStrategy _buffStrategy;

    private GameObject _oBuffInstance;


    public Buff(BuffData data)
    {
        _buffKey = data.buffKey;
        _buffName = data.buffName;
        _buffDescription = data.buffDescription;
        _buffType = data.buffType;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string GetBuffKey()
    {
        return _buffKey;
    }

    public string GetBuffName()
    {
        return _buffName;
    }

    public string GetBuffDescription()
    {
        return _buffDescription;
    }

    public BuffTypeEnum GetBuffType()
    {
        return _buffType;
    }

    public GameObject GetBuffInstanceObj()
    {
        return _oBuffInstance;
    }

    public void SetBuffInstanceObj(GameObject obj)
    {
        _oBuffInstance = obj;
    }
    

}
