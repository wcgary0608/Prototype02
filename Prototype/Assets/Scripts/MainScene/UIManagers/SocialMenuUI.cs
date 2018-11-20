using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.MainScene;

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

    private TextMeshProUGUI _tNpcDescription;

    private TextMeshProUGUI _tNpcSideStatus;
      
    private TextMeshProUGUI _tNpcGroupName;

    private TextMeshProUGUI _tFriendshipValue;

    private GameObject _oNeiGongContent;

    private GameObject _oCardContent;

    private GameObject _oInfoContent;

    public SocialMenuUI(MainSceneTreeNodeManager center) : base(center)
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
        var MenuUI = UITool.FindUIGameObject(MainUIComponentCollection.MenuUI);
        m_RootUI = UnityTool.FindChildGameObject(MenuUI, MainUIComponentCollection.SocialMenu);
        _oNpcDetailPanel = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.NpcDetailPanel);
        //Temporary Variables

        var npcList = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.NpcList);
        var npcViewport = UnityTool.FindChildGameObject(npcList, MainUIComponentCollection.Viewport);

        var neiGongList = UnityTool.FindChildGameObject(_oNpcDetailPanel, MainUIComponentCollection.NeiGongList);
        var neiGongViewport = UnityTool.FindChildGameObject(neiGongList, MainUIComponentCollection.Viewport);
        var cardList = UnityTool.FindChildGameObject(_oNpcDetailPanel, MainUIComponentCollection.CardList);
        var cardViewport = UnityTool.FindChildGameObject(cardList, MainUIComponentCollection.Viewport);
        var infoList = UnityTool.FindChildGameObject(_oNpcDetailPanel, MainUIComponentCollection.InfoList);
        var infoViewport = UnityTool.FindChildGameObject(infoList, MainUIComponentCollection.Viewport);


        //UI Components
        

        _btnAll = UITool.GetUIComponent<Button>(m_RootUI, MainUIComponentCollection.AllNpcBtn);
        _btnFriend = UITool.GetUIComponent<Button>(m_RootUI, MainUIComponentCollection.FriendBtn);
        _btnNormal = UITool.GetUIComponent<Button>(m_RootUI, MainUIComponentCollection.NormalBtn);
        _btnEnermy = UITool.GetUIComponent<Button>(m_RootUI, MainUIComponentCollection.EnermyBtn);

        _oNpcContent = UnityTool.FindChildGameObject(npcViewport, MainUIComponentCollection.Content);

        
        _imgCharacter = UITool.GetUIComponent<Image>(_oNpcDetailPanel, MainUIComponentCollection.CharacterImage);
        _btnReturnToRoot = UITool.GetUIComponent<Button>(_oNpcDetailPanel, MainUIComponentCollection.ReturnToRootBtn);
        _tNpcDescription = UITool.GetUIComponent<TextMeshProUGUI>(_oNpcDetailPanel, MainUIComponentCollection.NpcDescription);
        _tNpcSideStatus = UITool.GetUIComponent<TextMeshProUGUI>(_oNpcDetailPanel, MainUIComponentCollection.NpcSideStatus);
        _tNpcGroupName = UITool.GetUIComponent<TextMeshProUGUI>(_oNpcDetailPanel, MainUIComponentCollection.NpcGroupName);
        _tFriendshipValue = UITool.GetUIComponent<TextMeshProUGUI>(_oNpcDetailPanel, MainUIComponentCollection.FriendShipValue);

        _oNeiGongContent = UnityTool.FindChildGameObject(neiGongViewport, MainUIComponentCollection.Content);
        _oCardContent = UnityTool.FindChildGameObject(cardViewport, MainUIComponentCollection.Content);
        _oInfoContent = UnityTool.FindChildGameObject(infoViewport, MainUIComponentCollection.Content);
        Debug.Log(_oNeiGongContent.name);
    }

}
