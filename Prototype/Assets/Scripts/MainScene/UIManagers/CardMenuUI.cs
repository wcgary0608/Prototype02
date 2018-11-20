using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardMenuUI : IUserInterface
{
    private Button _btnAllocate;
        
    private Button _btnCompose;

    private GameObject _oAllocationPanel;

    private GameObject _oCardGroupContent;

    private TextMeshProUGUI _tCurGroupCount;

    private Button _btnReturn;

    private Button _btnAddGroup;

    private Button _btnDeleteGroup;

    private GameObject _oCurGroupContent;

    private TextMeshProUGUI _tTotalCardCount;

    private TextMeshProUGUI _tCurGroupName;

    private GameObject _oAllCardContent;

    public CardMenuUI(MainSceneTreeNodeManager center) : base(center)
    {
        GetUIComponents();
        HideRootUI();
    }

    public override void Initialize()
    {
        base.Initialize();
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
        //Temporary Variables
        var MenuUI = UITool.FindUIGameObject("MenuUI");
        var cardGroupList = UnityTool.FindChildGameObject(_oAllocationPanel, "cardGroupList");
        var cardGroupViewport = UnityTool.FindChildGameObject(cardGroupList, "Viewport");
        var curGroupList = UnityTool.FindChildGameObject(_oAllocationPanel, "curGroupList");
        var curGroupViewport = UnityTool.FindChildGameObject(curGroupList, "Viewport");
        var allCardList = UnityTool.FindChildGameObject(m_RootUI, "allCardList");
        var allCardViewport = UnityTool.FindChildGameObject(allCardList, "Viewport");


        //UI Components
        m_RootUI = UnityTool.FindChildGameObject(MenuUI, "CardMenu");

        _btnAllocate = UITool.GetUIComponent<Button>(m_RootUI, "allocateBtn");
        Debug.Log(_btnAllocate.name);
        _btnCompose = UITool.GetUIComponent<Button>(m_RootUI, "composeBtn");

        _oAllocationPanel = UnityTool.FindChildGameObject(m_RootUI, "allocateCardPanel");
        _oCardGroupContent = UnityTool.FindChildGameObject(cardGroupViewport, "Content");
        _tCurGroupCount = UITool.GetUIComponent<TextMeshProUGUI>(_oAllocationPanel, "curGroupCount");
        _btnReturn = UITool.GetUIComponent<Button>(_oAllocationPanel, "returnBtn");
        _btnAddGroup = UITool.GetUIComponent<Button>(_oAllocationPanel, "addGroupBtn");
        _btnDeleteGroup = UITool.GetUIComponent<Button>(_oAllocationPanel, "deleteGroupBtn");
        _oCurGroupContent = UnityTool.FindChildGameObject(curGroupViewport, "Content");

        _tTotalCardCount = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, "totalCardCount");
        _tCurGroupName = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, "curGroupName");

        _oAllCardContent = UnityTool.FindChildGameObject(allCardViewport, "Content");

    }
}
