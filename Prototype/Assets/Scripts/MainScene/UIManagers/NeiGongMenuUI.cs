using Assets.Scripts.MainScene;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NeiGongMenuUI : IUserInterface
{
    private GameObject _oTitleListContent;

    private ToggleGroup _titleToggleGroup;

    private TextMeshProUGUI _tName;

    private TextMeshProUGUI _tQuality;

    private TextMeshProUGUI _tDescription;

    private GameObject _oChapterContent;

    private List<ChapterInstance> _listChapterInstance = new List<ChapterInstance>();
    public List<ChapterInstance> ListChapterInstance
    {
        get { return _listChapterInstance; }
    }

    private GameObject _oConditionContent;

    private bool _isAllConditionPass = false;

    private GameObject _oAwardContent;

    private Button _btnPractice;

    public TextMeshProUGUI TForcePoints { get; set; }

    private GameObject _pfbNeiGongTitleInstance;

    private GameObject _pfbNeiGongConditionInstance;

    private Dictionary<string, GameObject> _dicTileInstance = new Dictionary<string, GameObject>();

   


    public NeiGongMenuUI(MainSceneTreeNodeManager center) : base(center)
    {
        

    }

    public override void Initialize()
    {
        GetUIComponents();
        HideRootUI();
        LoadPrefabs();

        _btnPractice.onClick.AddListener(OnPracticeBtnClick);

        string outputParams = "";
        if (!_managerCenter.DoAction(DoActionKey.InitializeNeiGongMenuComponents, out outputParams))
        {
            //log error
        }
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
            _btnPractice.interactable = _isAllConditionPass;

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void GetUIComponents()
    {
        var MenuUI = UITool.FindUIGameObject(MainUIComponentCollection.MenuUI);
        _oRootUI = UnityTool.FindChildGameObject(MenuUI, MainUIComponentCollection.NeiGongMenu);

        //temporary variables
        
        var list = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.List);
        var listViewport = UnityTool.FindChildGameObject(list, MainUIComponentCollection.Viewport);
        var chapterList = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.ChapterList);
        var chapterViewport = UnityTool.FindChildGameObject(chapterList, MainUIComponentCollection.Viewport);
        var conditionList = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.ConditionList);
        var conditionViewport = UnityTool.FindChildGameObject(conditionList, MainUIComponentCollection.Viewport);
        var awardList = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.AwardList);
        var awardViewport = UnityTool.FindChildGameObject(awardList, MainUIComponentCollection.Viewport);

        //UI Components

        _titleToggleGroup = UITool.GetUIComponent<ToggleGroup>(_oRootUI, MainUIComponentCollection.List);
        _oTitleListContent = UnityTool.FindChildGameObject(listViewport, MainUIComponentCollection.Content);
        _tName = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.Name);
        _tQuality = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.Quality);
        _tDescription = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.Description);
        _oChapterContent = UnityTool.FindChildGameObject(chapterViewport, MainUIComponentCollection.Content);
        ChapterInstance[] chapterInstanceArray = _oChapterContent.GetComponentsInChildren<ChapterInstance>();
        foreach(ChapterInstance instance in chapterInstanceArray)
        {
            _listChapterInstance.Add(instance);
        }
        _oConditionContent = UnityTool.FindChildGameObject(conditionViewport, MainUIComponentCollection.Content);
        _oAwardContent = UnityTool.FindChildGameObject(awardViewport, MainUIComponentCollection.Content);
        _btnPractice = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.PracticeBtn);
        TForcePoints = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.ForcePoints);
    }

    private void LoadPrefabs()
    {
        _pfbNeiGongTitleInstance = Resources.Load<GameObject>("Prefabs/UI/NeiGongMenu/NeiGongTitleInstance");
        _pfbNeiGongConditionInstance = Resources.Load<GameObject>("Prefabs/UI/NeiGongMenu/ConditionInstance");
    }

    public void InitializeTitleList(Dictionary<string, NeiGong> dicNeiGong, string selectedNG)
    {

        foreach(string key in dicNeiGong.Keys)
        {
            NeiGong ng = dicNeiGong[key];
            GameObject instance = GameObject.Instantiate(_pfbNeiGongTitleInstance, _oTitleListContent.transform);
            NeiGongTitleInstance script = instance.GetComponent<NeiGongTitleInstance>();
            script.InitializeInstance(ng, _managerCenter, _titleToggleGroup);
            
            _dicTileInstance.Add(key, instance);
        }

        GameObject defaultInstance = _dicTileInstance[selectedNG];
        defaultInstance.GetComponent<NeiGongTitleInstance>().SetToggleOn();
  
    }

    public void UpdateNeiGongDetail(NeiGong ng)
    {
        _tName.SetText(ng.Name);
        _tQuality.SetText(ng.Quality + "品");
        _tDescription.SetText(ng.Description);

        Dictionary<int, NeiGongChapter> dicChapter = ng.DicChapters;

        ClearCAPanel();
        SetAllChapterInstanceToDefault();

        foreach(int i in ng.ListActiveChapterIndex)
        {
            ChapterInstance instanceScript = _listChapterInstance[i];
            
            instanceScript.ActivateChapter();

            //章节已修炼完成
            if (ng.ListCompleteChapterIndex.Contains(i))
            {
                instanceScript.ChapterComplete();
            }
            else
            {
                //章节未修炼
                NeiGongChapter chapter = dicChapter[i];
                string chapterName = chapter.ChapterName;
                instanceScript.InitializeInstance(chapterName, _managerCenter);

            }

        }

    }
    
    public void SetAllChapterInstanceToDefault()
    {
        foreach(ChapterInstance script in _listChapterInstance)
        {
            script.SetToDefault();
        }
    }

    public void UpdateCAPanel(NeiGongChapter chapter)
    {
        bool passFlag = true;

        foreach(string[] condition in chapter.ListChapterConditions)
        {
            bool isConditionPass = _managerCenter.CheckNeiGongCondition(condition);
            if (passFlag)
            {
                passFlag = isConditionPass;
            }
            string conditionText = GenerateConditionText(condition);
            GameObject instance = GameObject.Instantiate(_pfbNeiGongConditionInstance, _oConditionContent.transform);
            instance.GetComponent<ConditionInstance>().InitializeInstance(conditionText, isConditionPass);
        }

        _isAllConditionPass = passFlag;
    }

    private string GenerateConditionText(string[] condition)
    {
        string key = condition[0];
        string value = condition[1];
        string text = "";
        switch (key)
        {
            case "HpCost":
                text = "气血 -" + value;
                break;

            case "ExpCost":
                text = "功力点 -" + value;
                break;

            case "ShenFaCost":
                text = "身法 -" + value;
                break;

            case "SpotRequire":
                text = "特殊地点";
                break;

            default:
                text = "无";
                break;
        }
        return text;
    }

    public void ClearCAPanel()
    {
        _isAllConditionPass = false;

        ConditionInstance[] temp = _oConditionContent.transform.GetComponentsInChildren<ConditionInstance>();
        foreach(ConditionInstance c in temp)
        {
            GameObject.Destroy(c.gameObject);
        }
    }

    public void OnPracticeBtnClick()
    {
        string outputParams = "";
        if(!_managerCenter.DoAction(DoActionKey.PracticeNeiGong, out outputParams))
        {
            //log error
        }
        ChapterComplete();
    }

    public void ChapterComplete()
    {
        ClearCAPanel();
    }

    public GameObject GetNeiGongTitleInstance(string key)
    {
        return _dicTileInstance[key];
    }
}