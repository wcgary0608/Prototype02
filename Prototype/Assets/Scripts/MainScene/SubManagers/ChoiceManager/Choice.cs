using Assets.Scripts.MainScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Choice{

    public string ChoiceName;

    public ChoiceTypeEnum ChoiceType;

    public string ChoiceDescription;

    public int ActionValueCost;

    public string ChoiceLocation;

    public Choice(ChoiceTypeEnum type)
    {
        ChoiceType = type;
    }

    public void InitializeChoice()
    {
        
    }



}
