using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.MainScene
{
    public enum InventoryCategoryEnum
    {
        AllItem,
        Drug,
        Equipment,
        Sundry
    }

    public enum TextInStatusMenuEnum
    {
        hpValue, mpValue, buffDescription,
        playerName,
        moveProb, skillProb, lifeProb, healProb, battleProb, socialProb,
        geValue, fameValue, shenFaValue, luckValue,
        weaponName, accessoryName
    }

    public enum ChoiceInstanceStatusEnum
    {
        current, available
    }

    public enum ChoiceTypeEnum
    {
        move, skill, life, heal, battle, social,
        fix, special
    }

    public enum BuffTypeEnum
    {
        buff, debuff
    }

    public enum SkillTypeEnum
    {
        fishing, hunting, medicine, cooking,
        music, chess, write, draw
    }

    public enum TextInMainPartEnum
    {
        hpValue, mpValue, actionValue, month, locationName
    }
}
