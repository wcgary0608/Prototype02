using Assets.Scripts.MainScene;
using System;
using UnityEngine;
using System.Collections.Generic;

public class MainSceneTreeNodeManager
{

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

    private WorldManager _mWorldManager;

    private ChoiceManager _mChoiceManager;

    public MainSceneTreeNodeManager(SceneStateController controller)
    {
        m_SceneController = controller;
    }

    public void InitializeManagerCenter()
    {
        StaticData.Instance.InitializeStaticData();

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
        _mPlayerManager.Initialize();

        _mWorldManager = new WorldManager(this);
        _mWorldManager.Initialize();

        _mChoiceManager = new ChoiceManager(this);
        _mChoiceManager.Initialize();

    }

    private void InitializeUIManagers()
    {
        _uiMainPart = new MainPartUI(this);
        _uiMainPart.Initialize();

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

            case DoActionKey.InitializeMainPartComponents:
                localSuccess = InitializeMainPartComponents(out outputParams);
                break;

            default:
                break;
        }
        return localSuccess;
    }

    private bool SwitchBuffDescription(string buffDescription)
    {
        bool isOn = _uiStatusMenu.IsBuffDescriptionOn();

        if (!isOn)
            _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.buffDescription, buffDescription);

        _uiStatusMenu.SwitchBuffDescriptionPanel();

        return true;
    }

    public bool InitializeMainPartComponents(out string error)
    {
        error = "";

        //hp,mp
        int curHp = _mPlayerManager.GetCurHp();
        float hpFillAmount = _mPlayerManager.GetHpFillAmount();
        _uiMainPart.SetTextForMainPart(TextInMainPartEnum.hpValue, curHp.ToString());
        _uiMainPart.SetHpFillAmount(hpFillAmount);

        int curMp = _mPlayerManager.GetCurMp();
        float mpFillAmount = _mPlayerManager.GetMpFillAmount();
        _uiMainPart.SetTextForMainPart(TextInMainPartEnum.mpValue, curMp.ToString());
        _uiMainPart.SetMpFillAmount(mpFillAmount);

        //actionValue
        int actionValue = _mWorldManager.GetCurActionValue();
        _uiMainPart.SetTextForMainPart(TextInMainPartEnum.actionValue, actionValue.ToString());

        //locationName
        string locationName = _mWorldManager.GetLocationName();
        _uiMainPart.SetTextForMainPart(TextInMainPartEnum.locationName, locationName);

        return true;
    }

    public bool InitializeStatusMenuComponents(out string error)
    {
        error = "";

        //hp,mp
        int curHp = _mPlayerManager.GetCurHp();
        int maxHp = _mPlayerManager.GetMaxHp();
        string hpValueText = string.Format("{0} / {1}", curHp, maxHp);
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.hpValue, hpValueText);
        float hpFillAmount = _mPlayerManager.GetHpFillAmount();
        _uiStatusMenu.SetHpFillAmount(hpFillAmount);

        int curMp = _mPlayerManager.GetCurMp();
        int maxMp = _mPlayerManager.GetMaxMp();
        string mpValueText = string.Format("{0} / {1}", curMp, maxMp);
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.mpValue, mpValueText);
        float mpFillAmount = _mPlayerManager.GetMpFillAmount();
        _uiStatusMenu.SetMpFillAmount(mpFillAmount);

        //buffList
        List<Buff> buffList = _mPlayerManager.GetBuffList();
        foreach(Buff buff in buffList)
        {
            _uiStatusMenu.InstantiateBuffInstance(buff);
        }
        

        //skills
        foreach(SkillTypeEnum t in Enum.GetValues(typeof(SkillTypeEnum)))
        {
            int tempSkillValue = _mPlayerManager.GetSkillValue(t);
            _uiStatusMenu.SetSkillTextForStatusMenu(t, tempSkillValue);
        }

        //basic attributes
        int geValue = _mPlayerManager.GetGEValue();
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.geValue, geValue.ToString());

        int fameValue = _mPlayerManager.GetFameValue();
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.fameValue, fameValue.ToString());

        int shenFaValue = _mPlayerManager.GetShenFaValue();
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.shenFaValue, shenFaValue.ToString());

        int luckValue = _mPlayerManager.GetLuckValue();
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.luckValue, luckValue.ToString());

        //Player name & gift
        string playerName = _mPlayerManager.GetPlayerName();
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.playerName, playerName);
       

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