using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.MainScene;

public enum TextInStatusMenu
{
    hpValue, mpValue, buffDescription, 
    playerName,
    moveProb, skillProb, lifeProb, healProb, battleProb, socialProb,
    geValue, fameValue, shenFaValue, luckValue,
    weaponName, accessoryName
}

public class StatusMenuUI : IUserInterface
{
    //Basic status panel components
    private Image _imgHpFill;
    private TextMeshProUGUI _tHpValue;
    private Image _imgMpFill;
    private TextMeshProUGUI _tMpValue;
    private GameObject _oBuffContent;
    private GameObject _oBuffDescriptionPanel;
    private TextMeshProUGUI _tBuffDescription;
    private GameObject _pfbBuffInstance;
    private bool _isBuffDescriptionOn = false;

    //Skill Panel Components
    private TextMeshProUGUI _tFishingSkill;
    private TextMeshProUGUI _tHuntingSkill;
    private TextMeshProUGUI _tMedicineSkill;
    private TextMeshProUGUI _tCookingSkill;
    private TextMeshProUGUI _tMusicSkill;
    private TextMeshProUGUI _tChessSkill;
    private TextMeshProUGUI _tWriteSkill;
    private TextMeshProUGUI _tDrawSkill;

    //Basic Information UI Coponents
    private TextMeshProUGUI _tPlayerName;

    private TextMeshProUGUI _tCharacteristic;
    private GameObject _oGiftContent;

    // Choices Probabilities UI Components
    private TextMeshProUGUI _tMoveProb;
    private TextMeshProUGUI _tSkillProb;
    private TextMeshProUGUI _tLifeProb;
    private TextMeshProUGUI _tHealProb;
    private TextMeshProUGUI _tBattleProb;
    private TextMeshProUGUI _tSocialProb;

    //Player Attributes UI Components
    private TextMeshProUGUI _tGEValue;
    private TextMeshProUGUI _tFameValue;
    private TextMeshProUGUI _tShenFaValue;
    private TextMeshProUGUI _tLuckValue;

    // Equipment UI Components
    private TextMeshProUGUI _tWeaponName;

    private TextMeshProUGUI _tAccessoryName;

    public StatusMenuUI(MainSceneTreeNodeManager center) : base(center)
    {
        
    }

    public override void Initialize()
    {
        GetUIComponents();
        LoadPrefabs();

        string outputParams = "";
        if (!m_ManagerCenter.DoAction(DoActionKey.InitializeStatusMenuComponents, out outputParams))
        {
            Debug.Log("fail to set value for StatusMenuUI");
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
        var obj_MenuUI = UITool.FindUIGameObject(MainUIComponentCollection.MenuUI);
        m_RootUI = UnityTool.FindChildGameObject(obj_MenuUI, MainUIComponentCollection.StatusMenu);

        ///temporary variables
        
        var hpBar = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.HpBar);
        var mpBar = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.MpBar);
        var buffList = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.BuffList);
        var buffViewport = UnityTool.FindChildGameObject(buffList, MainUIComponentCollection.Viewport);
        var skillsPanel = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.SkillsPanel);
        var giftList = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.GiftList);
        var giftViewport = UnityTool.FindChildGameObject(giftList, MainUIComponentCollection.Viewport);
        var choicePanel = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.ChoicePanel);
        var weapon = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.Weapon);
        var accessory = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.Accessory);

        ///UI Components     

        _imgHpFill = UITool.GetUIComponent<Image>(hpBar, MainUIComponentCollection.FillImg);
        _tHpValue = UITool.GetUIComponent<TextMeshProUGUI>(hpBar, MainUIComponentCollection.HpValue);

        _imgMpFill = UITool.GetUIComponent<Image>(mpBar, MainUIComponentCollection.FillImg);
        _tMpValue = UITool.GetUIComponent<TextMeshProUGUI>(mpBar, MainUIComponentCollection.MpValue);

        _oBuffContent = UnityTool.FindChildGameObject(buffViewport, MainUIComponentCollection.Content);
        _oBuffDescriptionPanel = UnityTool.FindChildGameObject(buffList, MainUIComponentCollection.BuffDescriptionPanel);
        _tBuffDescription = UITool.GetUIComponent<TextMeshProUGUI>(_oBuffDescriptionPanel, MainUIComponentCollection.Text);

        _tFishingSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Fishing);
        _tHuntingSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Hunting);
        _tMedicineSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Medicine);
        _tCookingSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Cooking);
        _tMusicSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Music);
        _tChessSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Chess);
        _tWriteSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Write);
        _tDrawSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Draw);

        _tPlayerName = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.PlayerName);
        _tCharacteristic = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.Characteristic);
        _oGiftContent = UnityTool.FindChildGameObject(giftViewport, MainUIComponentCollection.Content);

        _tMoveProb = UITool.GetUIComponent<TextMeshProUGUI>(choicePanel, MainUIComponentCollection.Move);
        _tSkillProb = UITool.GetUIComponent<TextMeshProUGUI>(choicePanel, MainUIComponentCollection.Skill);
        _tLifeProb = UITool.GetUIComponent<TextMeshProUGUI>(choicePanel, MainUIComponentCollection.Life);
        _tHealProb = UITool.GetUIComponent<TextMeshProUGUI>(choicePanel, MainUIComponentCollection.Heal);
        _tBattleProb = UITool.GetUIComponent<TextMeshProUGUI>(choicePanel, MainUIComponentCollection.Battle);
        _tSocialProb = UITool.GetUIComponent<TextMeshProUGUI>(choicePanel, MainUIComponentCollection.Social);

        _tGEValue = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.GEValue);
        _tFameValue = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.Fame);
        _tShenFaValue = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.ShenFa);
        _tLuckValue = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.Luck);

        _tWeaponName = UITool.GetUIComponent<TextMeshProUGUI>(weapon, MainUIComponentCollection.Text);
        _tAccessoryName = UITool.GetUIComponent<TextMeshProUGUI>(accessory, MainUIComponentCollection.Text);
    }

    private void LoadPrefabs()
    {
        _pfbBuffInstance = Resources.Load<GameObject>("Prefabs/UI/StatusMenu/BuffInstance");
    }

    public bool IsBuffDescriptionOn()
    {
        return _isBuffDescriptionOn;
    }

    public void SwitchBuffDescriptionPanel()
    {
        _oBuffDescriptionPanel.SetActive(!_isBuffDescriptionOn);
    }

    public bool SetTextForStatusMenu(TextInStatusMenu textKey, string newText)
    {
        switch (textKey)
        {
            case TextInStatusMenu.hpValue:
                _tHpValue.SetText(newText);
                return true;

            case TextInStatusMenu.mpValue:
                _tMpValue.SetText(newText);
                return true;

            case TextInStatusMenu.buffDescription:
                _tBuffDescription.SetText(newText);
                return true;

            case TextInStatusMenu.playerName:
                _tPlayerName.SetText(newText);
                return true;

            case TextInStatusMenu.moveProb:
                _tMoveProb.SetText(newText);
                return true;

            case TextInStatusMenu.skillProb:
                _tSkillProb.SetText(newText);
                return true;

            case TextInStatusMenu.lifeProb:
                _tLifeProb.SetText(newText);
                return true;

            case TextInStatusMenu.healProb:
                _tHealProb.SetText(newText);
                return true;

            case TextInStatusMenu.battleProb:
                _tBattleProb.SetText(newText);
                return true;

            case TextInStatusMenu.socialProb:
                _tSocialProb.SetText(newText);
                return true;

            case TextInStatusMenu.geValue:
                _tGEValue.SetText(newText);
                return true;

            case TextInStatusMenu.fameValue:
                _tFameValue.SetText(newText);
                return true;

            case TextInStatusMenu.shenFaValue:
                _tShenFaValue.SetText(newText);
                return true;

            case TextInStatusMenu.luckValue:
                _tLuckValue.SetText(newText);
                return true;

            case TextInStatusMenu.weaponName:
                _tWeaponName.SetText(newText);
                return true;

            case TextInStatusMenu.accessoryName:
                _tAccessoryName.SetText(newText);
                return true;

            default:
                Debug.Log("no such Text in StatusMenu: " + textKey.ToString());
                return false;
        }
    }

    public bool SetSkillTextForStatusMenu(SkillType skillKey, int skillValue)
    {
        string newText = skillValue.ToString();

        switch (skillKey)
        {
            case SkillType.fishing:
                _tFishingSkill.SetText(newText);
                return true;

            case SkillType.hunting:
                _tHuntingSkill.SetText(newText);
                return true;

            case SkillType.medicine:
                _tMedicineSkill.SetText(newText);
                return true;

            case SkillType.cooking:
                _tCookingSkill.SetText(newText);
                return true;

            case SkillType.music:
                _tMusicSkill.SetText(newText);
                return true;

            case SkillType.chess:
                _tChessSkill.SetText(newText);
                return true;

            case SkillType.write:
                _tWriteSkill.SetText(newText);
                return true;

            case SkillType.draw:
                _tDrawSkill.SetText(newText);
                return true;

            default:
                Debug.Log("no such skill type");
                return false;
        }
    }
 
    public void SetHpFillAmount(int curHp, int maxHp)
    {

        float fillAmount = (float)curHp / maxHp;
        _imgHpFill.fillAmount = fillAmount;
 
    }

    public void SetMpFillAmount(int curMp, int maxMp)
    {
        if (maxMp == 0)
        {
            _imgMpFill.fillAmount = 0;
            return;
        }
            
        float fillAmount = (float)curMp / maxMp;
        _imgMpFill.fillAmount = fillAmount;
    }



}