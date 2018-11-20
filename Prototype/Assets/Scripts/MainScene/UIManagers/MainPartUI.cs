using Assets.Scripts.MainScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainPartUI : IUserInterface
{
    private GameObject obj_statusBar;

    private GameObject obj_timeWheel;

    private GameObject obj_locationBar;

    private TextMeshProUGUI t_hpValue;

    private TextMeshProUGUI t_mpValue;

    private TextMeshProUGUI t_actionValue;

    private TextMeshProUGUI t_monthValue;

    private TextMeshProUGUI t_locationName;

    private Image i_hpFill;

    private Image i_mpFill;

    public MainPartUI(MainSceneTreeNodeManager center) : base(center)
    {
        Initialize();
    }

    public override void Initialize()
    {
        GetUIComponents();

        InitializeUIValue();
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

    private void InitializeUIValue()
    {
    }

    private void GetUIComponents()
    {
        m_RootUI = UITool.FindUIGameObject(MainUIComponentCollection.MainPartUI);

        obj_statusBar = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.StatusBar);

        obj_timeWheel = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.TimeWheel);

        obj_locationBar = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.LocationBar);

        i_hpFill = UITool.GetUIComponent<Image>(m_RootUI, MainUIComponentCollection.HpFill);

        i_mpFill = UITool.GetUIComponent<Image>(m_RootUI, MainUIComponentCollection.MpFill);

        t_hpValue = UITool.GetUIComponent<TextMeshProUGUI>(obj_statusBar, MainUIComponentCollection.HpValue);

        t_mpValue = UITool.GetUIComponent<TextMeshProUGUI>(obj_statusBar, MainUIComponentCollection.MpValue);

        t_actionValue = UITool.GetUIComponent<TextMeshProUGUI>(obj_timeWheel, MainUIComponentCollection.ActionValue);

        t_monthValue = UITool.GetUIComponent<TextMeshProUGUI>(obj_timeWheel, MainUIComponentCollection.MonthValue);

        t_locationName = UITool.GetUIComponent<TextMeshProUGUI>(obj_locationBar, MainUIComponentCollection.LocationName);
    }
}