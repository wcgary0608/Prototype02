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

    private Button _btnCloseAllocationPanel;

    private Button _btnAddGroup;

    private Button _btnDeleteGroup;

    private GameObject _oCurGroupContent;

    private TextMeshProUGUI _tTotalCardCount;

    private TextMeshProUGUI _tCurGroupName;

    private GameObject _oAllCardContent;

    public CardMenuUI(MainSceneTreeNodeManager center) : base(center)
    {
        
    }

    public override void Initialize()
    {
        GetUIComponents();
        HideRootUI();
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
        var curCardsList = UnityTool.FindChildGameObject(_oAllocationPanel, MainUIComponentCollection.CurCardsList);
        var curCardsViewport = UnityTool.FindChildGameObject(curCardsList, MainUIComponentCollection.Viewport);
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
        _oCurGroupContent = UnityTool.FindChildGameObject(curCardsViewport, MainUIComponentCollection.Content);

        _tTotalCardCount = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.TotalCardCount);
        _tCurGroupName = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.CurGroupName);

        _oAllCardContent = UnityTool.FindChildGameObject(allCardViewport, MainUIComponentCollection.Content);
    }

    private void InitializeUIValue()
    {

    }

}
