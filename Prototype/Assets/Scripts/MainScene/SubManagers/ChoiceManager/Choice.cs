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

    public void InitializeChoice(ChoiceTypeEnum type)
    {
        _choiceType = type;
    }

    public ChoiceTypeEnum GetChoiceType()
    {
        return _choiceType;
    }


}
