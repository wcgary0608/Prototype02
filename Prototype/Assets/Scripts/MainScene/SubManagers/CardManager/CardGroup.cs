using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGroup {

    private Dictionary<Card, GameObject> _dicGroupCards = new Dictionary<Card, GameObject>();
    public Dictionary<Card, GameObject> DicGroupCards
    {
        get { return _dicGroupCards; }
    }

    private string _groupName;
    public string GroupName
    {
        get { return _groupName; }
        set
        {
            //正则表达式检测：中文/英文/数字
            _groupName = value;
        }
    }

    public GameObject GroupDetailInstance { get; set; }

    public GameObject GroupCardsContent { get; set; }

    public CardGroup(string name)
    {
        _groupName = name;
    }

    public void InitializeCardGroup()
    {
        
    }

    public void SetCardGroupInstance(GameObject groupInstance)
    {
        GroupDetailInstance = groupInstance;
        var Viewport = UnityTool.FindChildGameObject(GroupDetailInstance, "Viewport");
        GroupCardsContent = UnityTool.FindChildGameObject(Viewport, "Content");
    }

    public void OnGroupSelected()
    {
        
    }

    public bool RemoveCardFromGroup(Card card)
    {
        if (_dicGroupCards.ContainsKey(card))
        {
            GameObject.Destroy(_dicGroupCards[card]);
            _dicGroupCards.Remove(card);
            return true;
        }

        return false;
    }



}
