using Assets.Scripts.MainScene;
using System;
using UnityEngine;

public class MainSceneTreeNodeManager
{

    #region Singleton
    private static MainSceneTreeNodeManager _instance;
    public static MainSceneTreeNodeManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private MainSceneTreeNodeManager() { }

    #endregion

    private SceneStateController m_SceneController;

    //UIManagers

    private MainPartUI _uiMainPart;

    private MenuUI _uiMenu;

    private StatusMenuUI _uiStatusMenu;

    private InventoryMenuUI _uiInventoryMenu;

    private NeiGongMenuUI _uiNeiGongMenu;

    private CardMenuUI _uiCardMenu;

    private SocialMenuUI _uiSocialMenu;

    //GameManagers
    private InputManager _mInputManager;

    private PlayerManager _mPlayerManager;

    public MainSceneTreeNodeManager(SceneStateController controller)
    {
        m_SceneController = controller;
    }

    public void InitializeManagerCenter()
    {
        InitializeGameManagers();

        InitializeUIManagers();
    }

    public void Update()
    {
        _mInputManager.Update();
    }

    public void FixedUpdate()
    {
        _mInputManager.FixedUpdate();
    }

    private void InitializeGameManagers()
    {
        _mInputManager = new InputManager(this);

        _mPlayerManager = new PlayerManager(this);
    }

    private void InitializeUIManagers()
    {
        _uiMainPart = new MainPartUI(this);

        _uiMenu = new MenuUI(this);

        _uiStatusMenu = new StatusMenuUI(this);
        _uiStatusMenu.Initialize();
        _uiInventoryMenu = new InventoryMenuUI(this);
        _uiNeiGongMenu = new NeiGongMenuUI(this);
        _uiCardMenu = new CardMenuUI(this);
        _uiCardMenu.Initialize();
        _uiSocialMenu = new SocialMenuUI(this);
    }

    public bool DoAction(string key, out string outputParams, string inputParams = "")
    {
        outputParams = "";
        bool localSuccess = false;
        switch (key)
        {
            case DoActionKey.SwitchMenuUI:
                localSuccess = SwitchMenuUI(out outputParams);
                break;

            case DoActionKey.InitializeStatusMenuComponents:
                localSuccess = InitializeStatusMenuComponents(out outputParams);
                break;

            case DoActionKey.SwitchBuffDescription:
                localSuccess = SwitchBuffDescription(inputParams);
                break;

            default:
                break;
        }
        return localSuccess;
    }

    private bool SwitchBuffDescription(string buffKey)
    {
        bool isOn = _uiStatusMenu.IsBuffDescriptionOn();

        if (!isOn)
            _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenu.buffDescription, buffKey);

        _uiStatusMenu.SwitchBuffDescriptionPanel();

        return true;
    }

    public bool InitializeStatusMenuComponents(out string error)
    {
        error = "";

        //hp,mp
        int curHp = _mPlayerManager.GetCurHp();
        int maxHp = _mPlayerManager.GetMaxHp();
        string hpValueText = string.Format("{0} / {1}", curHp, maxHp);
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenu.hpValue, hpValueText);
        _uiStatusMenu.SetHpFillAmount(curHp, maxHp);

        int curMp = _mPlayerManager.GetCurMp();
        int maxMp = _mPlayerManager.GetMaxMp();
        string mpValueText = string.Format("{0} / {1}", curMp, maxMp);
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenu.mpValue, mpValueText);
        _uiStatusMenu.SetMpFillAmount(curMp, maxMp);

        //buffList

        //skills
        foreach(SkillType t in Enum.GetValues(typeof(SkillType)))
        {
            int tempSkillValue = _mPlayerManager.GetSkillValue(t);
            _uiStatusMenu.SetSkillTextForStatusMenu(t, tempSkillValue);
        }

        //basic attributes
        int geValue = _mPlayerManager.GetGEValue();
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenu.geValue, geValue.ToString());

        int fameValue = _mPlayerManager.GetFameValue();
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenu.fameValue, fameValue.ToString());

        int shenFaValue = _mPlayerManager.GetShenFaValue();
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenu.shenFaValue, shenFaValue.ToString());

        int luckValue = _mPlayerManager.GetLuckValue();
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenu.luckValue, luckValue.ToString());

        return true;
    }

    public bool OpenSpecificMenu(string menuKey)
    {
        CloseAllMenus();

        bool localSuccess = false;
        switch (menuKey)
        {
            case UIMenuKey.StatusMenu:
                localSuccess = _uiStatusMenu.ShowRootUI();
                return localSuccess;

            case UIMenuKey.InventoryMenu:
                localSuccess = _uiInventoryMenu.ShowRootUI();
                return localSuccess;

            case UIMenuKey.NeiGongMenu:
                localSuccess = _uiNeiGongMenu.ShowRootUI();
                return localSuccess;

            case UIMenuKey.CardMenu:
                localSuccess = _uiCardMenu.ShowRootUI();
                return localSuccess;

            case UIMenuKey.SocialMenu:
                localSuccess = _uiSocialMenu.ShowRootUI();
                return localSuccess;

            default:
                return localSuccess;
        }

    }

    private void CloseAllMenus()
    {
        _uiStatusMenu.HideRootUI();
        _uiInventoryMenu.HideRootUI();
        _uiNeiGongMenu.HideRootUI();
        _uiCardMenu.HideRootUI();
        _uiSocialMenu.HideRootUI();
    }

    private bool SwitchMenuUI(out string error)
    {
        error = "";
        if (_uiMenu == null)
        {
            error = "Fail to load menu UI. Menu UI is not initialized properly";
            return false;
        }

        if (_uiMenu.isVisible())
            _uiMenu.HideRootUI();
        else
            _uiMenu.ShowRootUI();

        return true;
    }
}