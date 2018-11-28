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

            case DoActionKey.ShowAvailableChoices:
                localSuccess = ShowAvailableChoices();
                break;

            default:
                break;
        }
        return localSuccess;
    }

    public bool MakeChoice(ChoiceInstance instance)
    {
        _mChoiceManager.MakeChoice(instance);
        //Show target Event

        return true;
    }

    private bool ShowAvailableChoices()
    {
        _mChoiceManager.ShowAvailableChoices();
        return true;
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
        PlayerAttribute player = _mPlayerManager.PlayerAttribute;
        //hp,mp
        int curHp = player.CurHp;
        float hpFillAmount = player.HpFillAmount;
        _uiMainPart.SetTextForMainPart(TextInMainPartEnum.hpValue, curHp.ToString());
        _uiMainPart.SetHpFillAmount(hpFillAmount);

        int curMp = player.CurMp;
        float mpFillAmount = player.MpFillAmount;
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
        PlayerAttribute player = _mPlayerManager.PlayerAttribute;

        //hp,mp
        int curHp = player.CurHp;
        int maxHp = player.MaxHp;
        string hpValueText = string.Format("{0} / {1}", curHp, maxHp);
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.hpValue, hpValueText);
        float hpFillAmount = player.HpFillAmount;
        _uiStatusMenu.SetHpFillAmount(hpFillAmount);

        int curMp = player.CurMp;
        int maxMp = player.MaxMp;
        string mpValueText = string.Format("{0} / {1}", curMp, maxMp);
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.mpValue, mpValueText);
        float mpFillAmount = player.MpFillAmount;
        _uiStatusMenu.SetMpFillAmount(mpFillAmount);

        //buffList
        List<Buff> buffList = player.ListBuff;
        foreach(Buff buff in buffList)
        {
            _uiStatusMenu.InstantiateBuffInstance(buff);
        }
        

        //skills
        foreach(SkillTypeEnum t in Enum.GetValues(typeof(SkillTypeEnum)))
        {
            int tempSkillValue = player.GetSkillValue(t);
            _uiStatusMenu.SetSkillTextForStatusMenu(t, tempSkillValue);
        }

        //basic attributes
        int geValue = player.GEValue;
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.geValue, geValue.ToString());

        int fameValue = player.FameValue;
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.fameValue, fameValue.ToString());

        int shenFaValue = player.ShenFaValue;
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.shenFaValue, shenFaValue.ToString());

        int luckValue = player.LuckValue;
        _uiStatusMenu.SetTextForStatusMenu(TextInStatusMenuEnum.luckValue, luckValue.ToString());

        //Player name & gift
        string playerName = player.PlayerName;
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