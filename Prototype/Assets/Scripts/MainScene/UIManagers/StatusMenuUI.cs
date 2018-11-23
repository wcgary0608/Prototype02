using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.MainScene;

public class StatusMenuUI : IUserInterface
{
    //Basic status panel components
    private Image _imgHpFill;

    private TextMeshProUGUI _tHpValue;
    private Image _imgMpFill;
    private TextMeshProUGUI t_mpValue;
    private GameObject _oBuffContent;
    private GameObject _oBuffDescriptionPanel;
    private TextMeshProUGUI _tBuffDescription;
    private GameObject _pfbBuffInstance;

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
    private TextMeshProUGUI t_weaponName;

    private TextMeshProUGUI t_accessoryName;

    public StatusMenuUI(MainSceneTreeNodeManager center) : base(center)
    {
        Initialize();
    }

    public override void Initialize()
    {
        GetUIComponents();
        LoadPrefabs();
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
        t_mpValue = UITool.GetUIComponent<TextMeshProUGUI>(mpBar, MainUIComponentCollection.MpValue);

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

        t_weaponName = UITool.GetUIComponent<TextMeshProUGUI>(weapon, MainUIComponentCollection.Text);
        t_accessoryName = UITool.GetUIComponent<TextMeshProUGUI>(accessory, MainUIComponentCollection.Text);
    }

    private void LoadPrefabs()
    {
        _pfbBuffInstance = Resources.Load<GameObject>("Prefabs/UI/StatusMenu/BuffInstance");
    }

}