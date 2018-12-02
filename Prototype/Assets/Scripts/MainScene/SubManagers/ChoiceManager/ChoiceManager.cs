using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.MainScene;

public enum ChoiceInstanceStatusEnum
{
    current, available
}

public class ChoiceManager : IGameManager
{

    private GameObject _oChoicesPanel;

    private GameObject _oPastChoices;

    private GameObject _oAvailableChoices;

    private GameObject _pfbMoveChoice;

    private GameObject _pfbSkillChoice;

    private GameObject _pfbLifeChoice;

    private GameObject _pfbHealChoice;

    private GameObject _pfbBattleChoice;

    private GameObject _pfbSocialChoice;

    private string _choicePrefabPath = "Prefabs/Choices/";

    private Choice _curChoice;

    private ChoiceInstance _curChoiceInstance;

    private List<Choice> _listAvailableChoices = new List<Choice>();

    private Vector2 _originPoint = Vector2.zero;

    private float _radius = 2.5f;


    public ChoiceManager(MainSceneTreeNodeManager center) : base(center)
    {
    }

    public override void Initialize()
    {
        GetRelatedGameObjects();
        LoadPrefabs();

        _curChoice = new Choice(ChoiceTypeEnum.move);   
        _curChoiceInstance = GenerateChoiceInstance(_curChoice, _originPoint, ChoiceInstanceStatusEnum.current).GetComponent<ChoiceInstance>();
    }

    public override void Release()
    {
    }

    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
    }

    private void GetRelatedGameObjects()
    {
        var MainPart = UnityTool.FindGameObject("MainPart");
        _oChoicesPanel = UnityTool.FindChildGameObject(MainPart, "ChoicesPanel");
        _oPastChoices = UnityTool.FindChildGameObject(_oChoicesPanel, "PastChoices");
        _oAvailableChoices = UnityTool.FindChildGameObject(_oChoicesPanel, "AvailableChoices");
    }

    private void LoadPrefabs()
    {
        _pfbMoveChoice = Resources.Load<GameObject>(_choicePrefabPath + "MoveChoice");
        _pfbSkillChoice = Resources.Load<GameObject>(_choicePrefabPath + "SkillChoice");
        _pfbLifeChoice = Resources.Load<GameObject>(_choicePrefabPath + "LifeChoice");
        _pfbHealChoice = Resources.Load<GameObject>(_choicePrefabPath + "HealChoice");
        _pfbBattleChoice = Resources.Load<GameObject>(_choicePrefabPath + "BattleChoice");
        _pfbSocialChoice = Resources.Load<GameObject>(_choicePrefabPath + "SocialChoice");

    }

    public void MakeChoice(ChoiceInstance instance)
    {
        instance.gameObject.transform.SetParent(_oChoicesPanel.transform);
        instance.gameObject.SetActive(false);
        
        ChoiceInstance[] availableChoices = _oAvailableChoices.GetComponentsInChildren<ChoiceInstance>();
        foreach(ChoiceInstance c in availableChoices)
        {
            GameObject.Destroy(c.gameObject);
        }

        _curChoiceInstance.gameObject.transform.SetParent(_oPastChoices.transform);
        _curChoiceInstance.SetInstanceToPast();

        Vector3 curPastPos = _oPastChoices.transform.position;
        _oPastChoices.transform.position = new Vector3(curPastPos.x - 4.5f, curPastPos.y, curPastPos.z);

        instance.transform.position = _originPoint;
        _curChoiceInstance = instance;
        _curChoice = instance.Choice;
        instance.gameObject.SetActive(true);

        //clear availabelChoicesList
        _listAvailableChoices.Clear();

    }

    public void ShowAvailableChoices()
    {
        UpdateAvailableChoices();

        GenerateAvailableChoiceInstance();
    }

    private Vector2 ComputeInstanceCoordinate(float angle)
    {
        var x = _originPoint.x + _radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        var y = _originPoint.y + _radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector2(x, y);
    }

    private void GenerateAvailableChoiceInstance()
    {
        //生成随机的可选择项实例

        int count = _listAvailableChoices.Count;

        if(count > 0)
        {
            for(int i = 1; i <= count; i++)
            {
                Vector2 tempVector = ComputeInstanceCoordinate(i * 360f / count);
                Choice tempChoice = _listAvailableChoices[i - 1];
                GenerateChoiceInstance(tempChoice, tempVector, ChoiceInstanceStatusEnum.available);
            }
        }

    }

    private void UpdateAvailableChoices()
    {
        //For Test Use
        _listAvailableChoices.Add(new Choice(ChoiceTypeEnum.skill));
        _listAvailableChoices.Add(new Choice(ChoiceTypeEnum.heal));
        _listAvailableChoices.Add(new Choice(ChoiceTypeEnum.move));
    }

    private GameObject GenerateChoiceInstance(Choice choice, Vector2 choiceLoc, ChoiceInstanceStatusEnum choiceStatus)
    {
        GameObject tempChoice = null;
        GameObject container = null;
        bool isCurTarget = false;

        switch (choiceStatus)
        {
            case ChoiceInstanceStatusEnum.current:
                container = _oChoicesPanel;
                isCurTarget = true;
                break;

            case ChoiceInstanceStatusEnum.available:
                container = _oAvailableChoices;
                isCurTarget = false;
                break;

            default:
                break;

        }

        switch (choice.ChoiceType)
        {
            case ChoiceTypeEnum.move:
                tempChoice = GameObject.Instantiate(_pfbMoveChoice, container.transform);
                break;

            case ChoiceTypeEnum.skill:
                tempChoice = GameObject.Instantiate(_pfbSkillChoice, container.transform);
                break;

            case ChoiceTypeEnum.life:
                tempChoice = GameObject.Instantiate(_pfbLifeChoice, container.transform);
                break;

            case ChoiceTypeEnum.heal:
                tempChoice = GameObject.Instantiate(_pfbHealChoice, container.transform);
                break;

            case ChoiceTypeEnum.battle:
                tempChoice = GameObject.Instantiate(_pfbBattleChoice, container.transform);
                break;

            case ChoiceTypeEnum.social:
                tempChoice = GameObject.Instantiate(_pfbSocialChoice, container.transform);
                break;

            default:
                break;
        }

        if (tempChoice != null)
        {
            tempChoice.transform.position = choiceLoc;
            tempChoice.GetComponent<ChoiceInstance>().InitializeInstance(choice, _managerCenter, isCurTarget);
        }

        return tempChoice;

    }

}