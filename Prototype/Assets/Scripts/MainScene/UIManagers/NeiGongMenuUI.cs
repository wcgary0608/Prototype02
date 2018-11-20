using Assets.Scripts.MainScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NeiGongMenuUI : IUserInterface
{
    private GameObject obj_listContent;

    private TextMeshProUGUI t_name;

    private TextMeshProUGUI t_quality;

    private TextMeshProUGUI t_description;

    private GameObject obj_chapterContent;

    private GameObject obj_conditionContent;

    private GameObject obj_awardContent;

    private Button btn_practice;

    private TextMeshProUGUI t_forcePoints;

    public NeiGongMenuUI(MainSceneTreeNodeManager center) : base(center)
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
        //temporary variables
        var MenuUI = UITool.FindUIGameObject(MainUIComponentCollection.MenuUI);
        var list = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.List);
        var listViewport = UnityTool.FindChildGameObject(list, MainUIComponentCollection.Viewport);
        var chapterList = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.ChapterList);
        var chapterViewport = UnityTool.FindChildGameObject(chapterList, MainUIComponentCollection.Viewport);
        var conditionList = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.ConditionList);
        var conditionViewport = UnityTool.FindChildGameObject(conditionList, MainUIComponentCollection.Viewport);
        var awardList = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.AwardList);
        var awardViewport = UnityTool.FindChildGameObject(awardList, MainUIComponentCollection.Viewport);

        //UI Components
        m_RootUI = UnityTool.FindChildGameObject(MenuUI, MainUIComponentCollection.NeiGongMenu);
        obj_listContent = UnityTool.FindChildGameObject(listViewport, MainUIComponentCollection.Content);
        t_name = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.Name);
        t_quality = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.Quality);
        t_description = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.Description);
        obj_chapterContent = UnityTool.FindChildGameObject(chapterViewport, MainUIComponentCollection.Content);
        obj_conditionContent = UnityTool.FindChildGameObject(conditionViewport, MainUIComponentCollection.Content);
        obj_awardContent = UnityTool.FindChildGameObject(awardViewport, MainUIComponentCollection.Content);
        btn_practice = UITool.GetUIComponent<Button>(m_RootUI, MainUIComponentCollection.PracticeBtn);
        t_forcePoints = UITool.GetUIComponent<TextMeshProUGUI>(m_RootUI, MainUIComponentCollection.ForcePoints);
    }
}