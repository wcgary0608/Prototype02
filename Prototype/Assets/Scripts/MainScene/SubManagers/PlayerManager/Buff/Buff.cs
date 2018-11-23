using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BuffType
{
    buff,debuff
}

public class Buff{

    private string _buffKey;

    private string _buffName;

    private string _buffDescription;

    private BuffType _buffType;

    private IBuffStrategy _buffStrategy;



    public Buff(string buffKey, string buffName, string buffDescription, BuffType buffType)
    {
        _buffKey = buffKey;
        _buffName = buffName;
        _buffDescription = buffDescription;
        _buffType = buffType;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   

    

}
