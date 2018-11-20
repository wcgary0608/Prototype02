using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.MainScene;

public class StatusMenuUI : IUserInterface
{
    //Basic status panel components
    private Image i_hpFill;

    private TextMeshProUGUI t_hpValue;
    private Image i_mpFill;
    private TextMeshProUGUI t_mpValue;
    private GameObject obj_buffContent;

    //Skill Panel Components
    private TextMeshProUGUI t_fishingSkill;

    private TextMeshProUGUI t_huntingSkill;
    private TextMeshProUGUI t_medicineSkill;
    private TextMeshProUGUI t_cookingSkill;
    private TextMeshProUGUI t_musicSkill;
    private TextMeshProUGUI t_chessSkill;
    private TextMeshProUGUI t_writeSkill;
    private TextMeshProUGUI t_drawSkill;

    //Basic Information UI Coponents
    private TextMeshProUGUI t_playerName;

    private TextMeshProUGUI t_characteristic;
    private GameObject obj_giftContent;

    // Choices Probabilities UI Components
    private TextMeshProUGUI t_moveProb;

    private TextMeshProUGUI t_skillProb;
    private TextMeshProUGUI t_lifeProb;
    private TextMeshProUGUI t_healProb;
    private TextMeshProUGUI t_battleProb;
    private TextMeshProUGUI t_socialProb;

    //Player Attributes UI Components
    private TextMeshProUGUI t_GEValue;

    private TextMeshProUGUI t_fameValue;
    private TextMeshProUGUI t_shenFaValue;
    private TextMeshProUGUI t_luckValue;

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
        ///temporary variables
        var obj_MenuUI = UITool.FindUIGameObject(MainUIComponentCollection.MenuUI);
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
        m_RootUI = UnityTool.FindChildGameObject(obj_MenuUI, MainUIComponentCollection.StatusMenu);

        i_hpFill = UITool.GetUIComponent<Image>(hpBar, MainUIComponentCollection.FillImg);
        t_hpValue = UITool.GetUIComponent<TextMeshProUGUI>(hpBar, MainUIComponentCollection.HpValue);

        i_mpFill = UITool.GetUIComponent<Image>(mpBar, MainUIComponentCollection.FillImg);
        t_mpValue = UITool.GetUIComponent<TextMeshProUGUI>(mpBar, MainUIComponentCollection.MpValue);

        obj_buffContent = UnityTool.FindChildGameObject(buffViewport, MainUIComponentCollection.Content);

        t_fishingSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Fishing);
        t_huntingSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Hunting);
        t_medicineSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Medicine);
        t_cookingSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Cooking);
        t_musicSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Music);
        t_chessSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Chess);
        t_writeSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Write);
        t_drawSkill = UITool.GetUIComponent<TextMeshProUGUI>(skillsPanel, MainUIComponentCollection.Draw);

        t_playerName = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.PlayerName);
        t_characteristic = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.Characteristic);
        obj_giftContent = UnityTool.FindChildGameObject(giftViewport, MainUIComponentCollection.Content);

        t_moveProb = UITool.GetUIComponent<TextMeshProUGUI>(choicePanel, MainUIComponentCollection.Move);
        t_skillProb = UITool.GetUIComponent<TextMeshProUGUI>(choicePanel, MainUIComponentCollection.Skill);
        t_lifeProb = UITool.GetUIComponent<TextMeshProUGUI>(choicePanel, MainUIComponentCollection.Life);
        t_healProb = UITool.GetUIComponent<TextMeshProUGUI>(choicePanel, MainUIComponentCollection.Heal);
        t_battleProb = UITool.GetUIComponent<TextMeshProUGUI>(choicePanel, MainUIComponentCollection.Battle);
        t_socialProb = UITool.GetUIComponent<TextMeshProUGUI>(choicePanel, MainUIComponentCollection.Social);

        t_GEValue = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.GEValue);
        t_fameValue = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.Fame);
        t_shenFaValue = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.ShenFa);
        t_luckValue = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.Luck);

        t_weaponName = UITool.GetUIComponent<TextMeshProUGUI>(weapon, MainUIComponentCollection.Text);
        t_accessoryName = UITool.GetUIComponent<TextMeshProUGUI>(accessory, MainUIComponentCollection.Text);
    }
}