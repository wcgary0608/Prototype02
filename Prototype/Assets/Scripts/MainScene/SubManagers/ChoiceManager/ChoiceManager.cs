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

    private List<Choice> _listAvailableChoices;


    public ChoiceManager(MainSceneTreeNodeManager center) : base(center)
    {
    }

    public override void Initialize()
    {
        GetRelatedGameObjects();
        LoadPrefabs();

        _curChoice = new Choice();
        _curChoice.InitializeChoice(ChoiceTypeEnum.move);
        GenerateStartChoice();
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

    private void GenerateStartChoice()
    {
        switch (_curChoice.GetChoiceType())
        {
            case ChoiceTypeEnum.move:
                GameObject choice = GameObject.Instantiate(_pfbMoveChoice, _oChoicesPanel.transform);
                break;

            default:
                break;
        }
    }

}