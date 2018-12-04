using System.Collections.Generic;
using UnityEngine;

public class CardManager : IGameManager
{

    private List<Card> _listAllCards = new List<Card>();
    public List<Card> ListAllCards
    {
        get { return _listAllCards; }
    }

    private List<CardGroup> _listCardGroups = new List<CardGroup>();
    public List<CardGroup> ListCardGroups
    {
        get { return _listCardGroups; }
    }

    public CardGroup CurCardGroup { get; set; }





    public CardManager(MainSceneTreeNodeManager center) : base(center)
    {
    }

    public override void Initialize()
    {
        InitializeAllCardList();
        InitializeGroupList();
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

    private void InitializeAllCardList()
    {
        _listAllCards.Add(new Card("亢龙有悔", CardTypeEnum.attakP, 3, 0, 2, 0));
        _listAllCards.Add(new Card("战龙在野", CardTypeEnum.attakPM, 2, 0, 3, 1));
        _listAllCards.Add(new Card("金钟罩", CardTypeEnum.defendPM, 0, 4, 3, 2));
        _listAllCards.Add(new Card("铁布衫", CardTypeEnum.defendP, 0, 2, 2, 0));
    }

    private void InitializeGroupList()
    {
        
        _listCardGroups.Add(new CardGroup("测试卡组"));
        CurCardGroup = _listCardGroups[0];
    }

}