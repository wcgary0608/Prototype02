using Assets.Scripts.MainScene;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Text;

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
    private InventoryManager _mInventoryManager;

    private CardManager _mCardManager;

    private NeiGongManager _mNeiGongManager;

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

        _uiNeiGongMenu.Update();
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

        _mInventoryManager = new InventoryManager(this);
        _mInventoryManager.Initialize();
        
        _mCardManager = new CardManager(this);
        _mCardManager.Initialize();

        _mNeiGongManager = new NeiGongManager(this);
        _mNeiGongManager.Initialize();

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
        _uiNeiGongMenu.Initialize();

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

            case DoActionKey.InvDropButtonOnClick:
                localSuccess = InvDropButtonOnClick();
                break;
                
            case DoActionKey.InitializeCardMenuComponents:
                localSuccess = InitializeCardMenuComponents(out outputParams);
                break;

            case DoActionKey.InvUseButtonOnClick:
                localSuccess = InvUseButtonOnClick();
                break;
                
            case DoActionKey.InitializeNeiGongMenuComponents:
                localSuccess = InitializeNeiGongMenuComponents(out outputParams);
                break;

            case DoActionKey.InvSetChosenItem:
                localSuccess = InvSetChosenItem(inputParams);
                break;
                
            case DoActionKey.UpdateNeiGongDetail:
                localSuccess = UpdateNeiGongDetail(inputParams);
                break;

            case DoActionKey.InvGetItemList:
                localSuccess = InvGetItemList(out outputParams);
                break;
                
            case DoActionKey.UpdateNeiGongCAPanel:
                localSuccess = UpdateNeiGongCAPanel(inputParams);
                break;

            case DoActionKey.ClearCAPanel:
                localSuccess = ClearCAPanel(out outputParams);
                break;

            case DoActionKey.PracticeNeiGong:
                localSuccess = PracticeNeiGong();
                break;

            default:
                break;
        }
        return localSuccess;
    }

    public bool ShowChoiceDescrptionPanel(Choice choice)
    {
        _mChoiceManager.ShowChoiceDescriptionPanel(choice);
        return true;
    }

    public bool HideChoiceDescriptionPanel()
    {
        _mChoiceManager.HideChoiceDescriptionPanel();
        return true;
    }

    public bool PracticeNeiGong()
    {
        
        NeiGong ng = _mNeiGongManager.GetSpecificNeiGong(_mNeiGongManager.SelectedNeiGongId);
        int chapterIndex = _mNeiGongManager.CurChapterIndex;
        NeiGongChapter chapter = ng.DicChapters[chapterIndex];

        //扣减相应条件所需的数值

        //将chapter状态改为已修炼
        if (!ng.ListCompleteChapterIndex.Contains(chapterIndex))
        {
            ng.ListCompleteChapterIndex.Add(chapterIndex);
        }
        chapter.IsComplete = true;
        _uiNeiGongMenu.ListChapterInstance[chapterIndex].ChapterComplete();
        
        //更新title显示的功法修炼等级
        GameObject titleInstance = _uiNeiGongMenu.GetNeiGongTitleInstance(_mNeiGongManager.SelectedNeiGongId);
        titleInstance.GetComponent<NeiGongTitleInstance>().UpdateLevelValue();


        return true;
    }

    //----------------TBD: Add to DoAction-----------------//
    public bool CheckNeiGongCondition(string[] condition)
    {
        bool isConditionPass = false;
        string key = condition[0];

        switch (key)
        {
            case "HpCost":
                int hpValue;
                int.TryParse(condition[1], out hpValue);
                if(_mPlayerManager.PlayerAttribute.CurHp > hpValue)
                {
                    isConditionPass = true;
                }
                break;

            case "ExpCost":
                int expValue;
                int.TryParse(condition[1], out expValue);
                if(_mNeiGongManager.ForcePointValue >= expValue)
                {
                    isConditionPass = true;
                }
                break;

            case "ShenFaCost":
                int shenFaValue;
                int.TryParse(condition[1], out shenFaValue);
                if(_mPlayerManager.PlayerAttribute.ShenFaValue - 1> shenFaValue)
                {
                    isConditionPass = true;
                }
                break;

            case "SpotRequire":
                //check player cur location
                isConditionPass = true;
                break;

            default:
                break;
        }
        return isConditionPass;
    }

    public bool UpdateNeiGongCAPanel(string indexString)
    {
        int index;
        int.TryParse(indexString, out index);
        _mNeiGongManager.CurChapterIndex = index;
        NeiGong ng = _mNeiGongManager.GetSpecificNeiGong(_mNeiGongManager.SelectedNeiGongId);
        NeiGongChapter chapter = ng.DicChapters[index];
        _uiNeiGongMenu.UpdateCAPanel(chapter);

        return true;
    }

    public bool ClearCAPanel(out string error)
    {
        error = "";
        _mNeiGongManager.CurChapterIndex = -1;
        _uiNeiGongMenu.ClearCAPanel();
        return true;
    }

    public bool UpdateNeiGongDetail(string selectedId)
    {
        NeiGong ng = _mNeiGongManager.GetSpecificNeiGong(selectedId);
        _mNeiGongManager.SelectedNeiGongId = selectedId;

        _uiNeiGongMenu.UpdateNeiGongDetail(ng);
        return true;
    }

    public bool InitializeNeiGongMenuComponents(out string error)
    {
        error = "";

        int forcePoint = _mNeiGongManager.ForcePointValue;
        _uiNeiGongMenu.TForcePoints.SetText(forcePoint.ToString());

        Dictionary<string, NeiGong> dicAllNeiGong = _mNeiGongManager.DicAllNeiGong;
        string curId = _mNeiGongManager.SelectedNeiGongId;
       
        _uiNeiGongMenu.InitializeTitleList(dicAllNeiGong, curId);
        return true;
    }

    public bool AddCardToCurGroup(Card card)
    {
        CardGroup curGroup = _mCardManager.CurCardGroup;
        _uiCardMenu.AddCardInstanceToGroup(card, curGroup);
        return true;
    }

    public bool RemoveCardFromCurGroup(Card card)
    {
        CardGroup curGroup = _mCardManager.CurCardGroup;
        bool isSuccess = curGroup.RemoveCardFromGroup(card);
        return isSuccess;
    }

    public bool InitializeCardMenuComponents(out string error)
    {
        error = "";
        List<Card> listAllCard = _mCardManager.ListAllCards;
        int allCardCount = listAllCard.Count;
        List<CardGroup> listCardGroup = _mCardManager.ListCardGroups;
        CardGroup curGroup = _mCardManager.CurCardGroup;

        _uiCardMenu.TotalCardCount = allCardCount.ToString();
        _uiCardMenu.CurGroupName = curGroup.GroupName;
        _uiCardMenu.InitializeAllCardsInstance(listAllCard);
        _uiCardMenu.InitializeCardGroupDetailInstance(listCardGroup);
        curGroup.GroupDetailInstance.SetActive(true);

        return true;

    }

    private bool InvGetItemList(out string Ids)
    {
        Ids = String.Empty;
        ICollection<int> IdCollection = _mInventoryManager.GetItemIds();
        if (IdCollection == null || IdCollection.Count <= 0)
        {
            return false;
        }

        StringBuilder sb = new StringBuilder();
        foreach (int i in IdCollection)
        {
            sb.Append(i.ToString());
            sb.Append("^");
        }
        Ids = sb.ToString();
        return true;
    }


    private bool InvSetChosenItem(string itemId) {
        int Id = int.MinValue;
        if (!int.TryParse(itemId, out Id))
        {
            return false;
        }
        return _mInventoryManager.SetChosenItem(Id);
    }

    private bool InvUseButtonOnClick()
    {
        return _mInventoryManager.UseChosenItem();
    }

    private bool InvDropButtonOnClick()
    {
        return _mInventoryManager.RemoveChosenItem();
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
        error = string.Empty;
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