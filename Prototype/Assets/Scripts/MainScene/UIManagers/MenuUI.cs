using Assets.Scripts.MainScene;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : IUserInterface
{
    private GameObject _oMenuChoices;

    private Button _btnStatausMenu;

    private Button _btnInventoryMenu;

    private Button _btnNeiGongMenu;

    private Button _btnCardMenu;

    private Button _btnSocialMenu;
    

    public MenuUI(MainSceneTreeNodeManager center) : base(center)
    {
        Initialize();
    }

    public override void Initialize()
    {
        GetUIComponents();
        InitializeComponents();
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
        _oRootUI = UITool.FindUIGameObject(MainUIComponentCollection.MenuUI);

        _oMenuChoices = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.MenuChoices);

        _btnStatausMenu = UITool.GetUIComponent<Button>(_oMenuChoices, MainUIComponentCollection.StatusMenuBtn);
        _btnInventoryMenu = UITool.GetUIComponent<Button>(_oMenuChoices, MainUIComponentCollection.InventoryMenuBtn);
        _btnNeiGongMenu = UITool.GetUIComponent<Button>(_oMenuChoices, MainUIComponentCollection.NeiGongMenuBtn);
        _btnCardMenu = UITool.GetUIComponent<Button>(_oMenuChoices, MainUIComponentCollection.CardMenuBtn);
        _btnSocialMenu = UITool.GetUIComponent<Button>(_oMenuChoices, MainUIComponentCollection.SocialMenuBtn);
    }

    private void InitializeComponents()
    {
        _btnStatausMenu.onClick.AddListener(() => { _managerCenter.OpenSpecificMenu(UIMenuKey.StatusMenu); });
        _btnInventoryMenu.onClick.AddListener(() => { _managerCenter.OpenSpecificMenu(UIMenuKey.InventoryMenu); });
        _btnNeiGongMenu.onClick.AddListener(() => { _managerCenter.OpenSpecificMenu(UIMenuKey.NeiGongMenu); });
        _btnCardMenu.onClick.AddListener(() => { _managerCenter.OpenSpecificMenu(UIMenuKey.CardMenu); });
        _btnSocialMenu.onClick.AddListener(() => { _managerCenter.OpenSpecificMenu(UIMenuKey.SocialMenu); });
    }
}