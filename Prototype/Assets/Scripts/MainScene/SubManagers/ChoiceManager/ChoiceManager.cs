using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.MainScene;

public class ChoiceManager : IGameManager
{

    private GameObject _oChoicesPanel;

    private GameObject _oPastChoices;

    private GameObject _pfbMoveChoice;

    private GameObject _pfbSkillChoice;

    private GameObject _pfbLifeChoice;

    private GameObject _pfbHealChoice;

    private GameObject _pfbBattleChoice;

    private GameObject _pfbSocialChoice;

    private string _choicePrefabPath = "Prefabs/Choices/";

    private Choice _curChoice;

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
        GenerateChoiceInstance(_curChoice, _originPoint);
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
                GenerateChoiceInstance(tempChoice, tempVector);
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

    private void GenerateChoiceInstance(Choice choice, Vector2 choiceLoc)
    {
        GameObject tempChoice = null;
        switch (choice.GetChoiceType())
        {
            case ChoiceTypeEnum.move:
                tempChoice = GameObject.Instantiate(_pfbMoveChoice, _oChoicesPanel.transform);
                break;

            case ChoiceTypeEnum.skill:
                tempChoice = GameObject.Instantiate(_pfbSkillChoice, _oChoicesPanel.transform);
                break;

            case ChoiceTypeEnum.life:
                tempChoice = GameObject.Instantiate(_pfbLifeChoice, _oChoicesPanel.transform);
                break;

            case ChoiceTypeEnum.heal:
                tempChoice = GameObject.Instantiate(_pfbHealChoice, _oChoicesPanel.transform);
                break;

            case ChoiceTypeEnum.battle:
                tempChoice = GameObject.Instantiate(_pfbBattleChoice, _oChoicesPanel.transform);
                break;

            case ChoiceTypeEnum.social:
                tempChoice = GameObject.Instantiate(_pfbSocialChoice, _oChoicesPanel.transform);
                break;

            default:
                break;
        }

        if (tempChoice != null)
        {
            tempChoice.transform.position = choiceLoc;
            tempChoice.GetComponent<ChoiceInstance>().InitializeInstance(choice, _managerCenter);
        }
            

    }

}