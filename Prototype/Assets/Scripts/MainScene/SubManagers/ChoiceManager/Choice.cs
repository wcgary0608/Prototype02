using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChoiceTypeEnum
{
    move, skill, life, heal, battle, social,
    fix, special
}

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
