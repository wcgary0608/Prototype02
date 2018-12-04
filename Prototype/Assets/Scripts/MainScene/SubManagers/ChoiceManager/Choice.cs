using Assets.Scripts.MainScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Choice{



    private ChoiceTypeEnum _choiceType;

    public Choice(ChoiceTypeEnum type)
    {
        _choiceType = type;
    }

    public void InitializeChoice()
    {
        
    }

    public ChoiceTypeEnum GetChoiceType()
    {
        return _choiceType;
    }


}
