using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SocialMenuUI : IUserInterface
{
    private Button _btnAll;

    private Button _btnFriend;

    private Button _btnNormal;

    private Button _btnEnermy;

    private GameObject _oNpcContent;

    //NPC Detail Panel
    private GameObject _oNpcDetailPanel;

    private Image _imgCharacter;

    private Button _btnReturnToRoot;

    private TextMeshProUGUI _tDescription;

    private TextMeshProUGUI _tSideStatus;
      
    private TextMeshProUGUI _tGroupName;

    private TextMeshProUGUI _tFriendshipValue;

    private GameObject _oNeiGongContent;

    private GameObject _oCardContent;

    private GameObject _oInfoContent;

    public SocialMenuUI(MainSceneTreeNodeManager center) : base(center)
    {
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
        var npcList = UnityTool.FindChildGameObject(m_RootUI, "npcList");
        var npcViewport = UnityTool.FindChildGameObject(m_RootUI, "Viewport");

        var neiGongList = UnityTool.FindChildGameObject(_oNpcDetailPanel, "neiGongList");
        var neiGongViewport = UnityTool.FindChildGameObject(neiGongList, "Viewport");
        var cardList = UnityTool.FindChildGameObject(_oNpcDetailPanel, "cardList");
        var cardViewport = UnityTool.FindChildGameObject(cardList, "Viewport");
        var infoList = UnityTool.FindChildGameObject(_oNpcDetailPanel, "infoList");
        var infoViewport = UnityTool.FindChildGameObject(infoList, "Viewport");


        //UI Components
        m_RootUI = UnityTool.FindChildGameObject(MenuUI, "SocialMenu");

        _btnAll = UITool.GetUIComponent<Button>(m_RootUI, "allBtn");
        _btnFriend = UITool.GetUIComponent<Button>(m_RootUI, "friendBtn");
        _btnNormal = UITool.GetUIComponent<Button>(m_RootUI, "normalBtn");
        _btnEnermy = UITool.GetUIComponent<Button>(m_RootUI, "enermyBtn");

        _oNpcContent = UnityTool.FindChildGameObject(npcViewport, "Content");

        _oNpcDetailPanel = UnityTool.FindChildGameObject(m_RootUI, "npcDetailPanel");
        _imgCharacter = UITool.GetUIComponent<Image>(_oNpcDetailPanel, "characterImage");
        _btnReturnToRoot = UITool.GetUIComponent<Button>(_oNpcDetailPanel, "returnToRootBtn");
        _tDescription = UITool.GetUIComponent<TextMeshProUGUI>(_oNpcDetailPanel, "description");
        _tSideStatus = UITool.GetUIComponent<TextMeshProUGUI>(_oNpcDetailPanel, "sideStatus");
        _tGroupName = UITool.GetUIComponent<TextMeshProUGUI>(_oNpcDetailPanel, "groupName");
        _tFriendshipValue = UITool.GetUIComponent<TextMeshProUGUI>(_oNpcDetailPanel, "friendshipValue");

        _oNeiGongContent = UnityTool.FindChildGameObject(neiGongViewport, "Content");
        _oCardContent = UnityTool.FindChildGameObject(cardViewport, "Content");
        _oInfoContent = UnityTool.FindChildGameObject(infoViewport, "Content");

    }

}
