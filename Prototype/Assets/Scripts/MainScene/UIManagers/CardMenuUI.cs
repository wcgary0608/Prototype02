using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.MainScene;

public class CardMenuUI : IUserInterface
{
    private Button _btnAllocateCard;
        
    private Button _btnComposeCard;

    private GameObject _oAllocationPanel;

    private GameObject _oCardGroupContent;

    private TextMeshProUGUI _tCurGroupCount;
    public string CurGroupCount
    {
        set { _tCurGroupCount.SetText(value); }
    }

    private GameObject _oCardGroupDetail;

    private Button _btnCloseAllocationPanel;

    private Button _btnAddGroup;

    private Button _btnDeleteGroup;

    private TextMeshProUGUI _tTotalCardCount;
    public string TotalCardCount
    {
        set { _tTotalCardCount.SetText(value); }
    }

    private TextMeshProUGUI _tCurGroupName;
    public string CurGroupName
    {
        set { _tCurGroupName.SetText(value); }
    }

    private GameObject _oAllCardContent;

    private GameObject _pfbCardInstance;

    private GameObject _pfbCardGroupDetailInstance;

    private GameObject _pfbGroupCardInstance;

    public CardMenuUI(MainSceneTreeNodeManager center) : base(center)
    {
        
    }

    public override void Initialize()
    {
        GetUIComponents();
        LoadPrefabs();
        HideRootUI();

        string outputParams = "";
        if(!_managerCenter.DoAction(DoActionKey.InitializeCardMenuComponents, out outputParams))
        {
            //log error
        }

    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void GetUIComponents()
    {
        var MenuUI = UITool.FindUIGameObject(MainUIComponentCollection.MenuUI);
        _oRootUI = UnityTool.FindChildGameObject(MenuUI, MainUIComponentCollection.CardMenu);
        _oAllocationPanel = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.AllocateCardPanel);
        //Temporary Variables

        var cardGroupList = UnityTool.FindChildGameObject(_oAllocationPanel, MainUIComponentCollection.CardGroupList);
        var cardGroupViewport = UnityTool.FindChildGameObject(cardGroupList, MainUIComponentCollection.Viewport);
        

        var allCardList = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.AllCardList);
        var allCardViewport = UnityTool.FindChildGameObject(allCardList, MainUIComponentCollection.Viewport);


        //UI Components
        

        _btnAllocateCard = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.AllocateCardBtn);
        _btnComposeCard = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.ComposeCardBtn);

        
        _oCardGroupContent = UnityTool.FindChildGameObject(cardGroupViewport, MainUIComponentCollection.Content);
        _tCurGroupCount = UITool.GetUIComponent<TextMeshProUGUI>(_oAllocationPanel, MainUIComponentCollection.CurGroupCount);
        _btnCloseAllocationPanel = UITool.GetUIComponent<Button>(_oAllocationPanel, MainUIComponentCollection.CloseAllocationPanelBtn);
        _btnAddGroup = UITool.GetUIComponent<Button>(_oAllocationPanel, MainUIComponentCollection.AddGroupBtn);
        _btnDeleteGroup = UITool.GetUIComponent<Button>(_oAllocationPanel, MainUIComponentCollection.DeleteGroupBtn);
        _oCardGroupDetail = UnityTool.FindChildGameObject(_oAllocationPanel, MainUIComponentCollection.CardGroupDetail);

        _tTotalCardCount = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.TotalCardCount);
        _tCurGroupName = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.CurGroupName);

        _oAllCardContent = UnityTool.FindChildGameObject(allCardViewport, MainUIComponentCollection.Content);
    }

    private void LoadPrefabs()
    {
        _pfbCardInstance = Resources.Load<GameObject>("Prefabs/UI/CardMenu/CardInstance");
        _pfbCardGroupDetailInstance = Resources.Load<GameObject>("Prefabs/UI/CardMenu/CardGroupDetailInstance");
        _pfbGroupCardInstance = Resources.Load<GameObject>("Prefabs/UI/CardMenu/GroupCardInstance");
    }

    public void InitializeAllCardsInstance(List<Card> listAllCard)
    {
        foreach(Card c in listAllCard)
        {
            GameObject cardInstance = GameObject.Instantiate(_pfbCardInstance, _oAllCardContent.transform);
            cardInstance.GetComponent<CardInstance>().InitializeCardInstance(c, _managerCenter);
        }
    }

    public void InitializeCardGroupDetailInstance(List<CardGroup> listGroup)
    {
        foreach(CardGroup cg in listGroup)
        {
            GameObject groupInstance = GameObject.Instantiate(_pfbCardGroupDetailInstance, _oCardGroupDetail.transform);
            cg.SetCardGroupInstance(groupInstance);

            //数据导入Group包含的Card
            List<Card> listCards = new List<Card>();
            InitializeCardGroup(cg, listCards);
            groupInstance.SetActive(false);
        }
    }

    public void InitializeCardGroup(CardGroup cardGroup, List<Card> listCards)
    {
        foreach(Card c in listCards)
        {
            GameObject groupCardInstance = GameObject.Instantiate(_pfbGroupCardInstance, cardGroup.GroupCardsContent.transform);
            groupCardInstance.GetComponent<GroupCardInstance>().InitializeGroupCardInstance(c);

            cardGroup.DicGroupCards.Add(c, groupCardInstance);
        }
    }

    public void AddCardInstanceToGroup(Card card, CardGroup cardGroup)
    {
        GameObject groupCardInstance = GameObject.Instantiate(_pfbGroupCardInstance, cardGroup.GroupCardsContent.transform);
        groupCardInstance.GetComponent<GroupCardInstance>().InitializeGroupCardInstance(card);
        cardGroup.DicGroupCards.Add(card, groupCardInstance);
    }


}
