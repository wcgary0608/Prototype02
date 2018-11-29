using UnityEngine;
using Assets.Scripts.MainScene;

/// <summary>
/// TBD:
/// Map / Time
/// </summary>

public class WorldManager : IGameManager
{
    //Time Variables
    private int _curActionValue;

    private int _baseActionValue = 36;

    private int _extraActionValue = 0;

    private int _monthValue = 1;

    private int _yearValue = 1;

    //Map Vairables
    private string _CurLocation = "琅寰福地";

    public WorldManager(MainSceneTreeNodeManager center) : base(center)
    {
    }

    public override void Initialize()
    {
        _curActionValue = _baseActionValue + _extraActionValue;

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

    public void SetCurActionValue(int value)
    {
        if (value > 0)
            _curActionValue = value;
    }

    public int GetCurActionValue()
    {
        return _curActionValue;
    }

    public void ChangeCurActionValue(int changeValue)
    {
        int tempActionValue = _curActionValue + changeValue;

        if(tempActionValue <= 0)
        {
            tempActionValue = Mathf.Abs(tempActionValue);
            int defaultValue = GetDefaultActionValue();

            tempActionValue = defaultValue - tempActionValue;
            //进入下一月
            AddMonthValue();
        }

        _curActionValue = tempActionValue;
    }

    public int GetDefaultActionValue()
    {
        int defaultActionValue = _baseActionValue + _extraActionValue;
        return defaultActionValue;
    }

    public int GetMonthValue()
    {
        return _monthValue;
    }

    public int GetYearValue()
    {
        return _yearValue;
    }

    public void AddMonthValue()
    {
        int tempMonthValue = _monthValue + 1;

        if(tempMonthValue > 12)
        {
            AddYearValue();
            tempMonthValue = 1;
        }

        _monthValue = tempMonthValue;

    }

    public void AddYearValue()
    {
        _yearValue += 1;

        if (_yearValue == 11)
            //End Game
            return;
    }

    public string GetLocationName()
    {
        return _CurLocation;
    }

}