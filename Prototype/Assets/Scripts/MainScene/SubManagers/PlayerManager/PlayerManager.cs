using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    fishing, hunting, medicine, cooking, 
    music, chess, write, draw
}

public class PlayerManager : IGameManager
{
    private int _curHP = 10;
    private int _maxHP = 10;
    private int _curMP = 3;
    private int _maxMP = 5;

    private int _geValue = 0;
    private int _maxGEValue = 100;
    private int _minGEValue = -100;

    private int _fameValue = 0;
    private int _maxFameValue = 100;
    private int _minFameValue = 0;

    private int _shenFaValue = 2;
    private int _maxShenFaValue = 100;
    private int _minShenFaValue = 1;

    private int _luckValue = 0;
    private int _maxLuckValue = 100;
    private int _minLuckValue = -100;

    private int _fishingSkillValue = 1;
    private int _huntingSkillValue = 1;
    private int _medicineSkillValue = 1;
    private int _cookingSkillValue = 1;
    private int _musicSkillValue = 1;
    private int _chessSkillValue = 1;
    private int _writeSkillValue = 1;
    private int _drawSkillValue = 1;
    private int _maxSkillValue = 100;

    private List<string> _listBuff;

    private string _playerName = "贾健程";
    

    public PlayerManager(MainSceneTreeNodeManager center) : base(center)
    {

    }

    public override void Initialize()
    {
        
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

    public int GetCurHp()
    {
        return _curHP;
    }

    public int GetMaxHp()
    {
        return _maxHP;
    }

    public bool ChangeCurHp(int changeValue)
    {
        int tempHp = _curHP + changeValue;

        if (tempHp < 0)
            return false;
        
        tempHp = Mathf.Min(tempHp, _maxHP);

        _curHP = tempHp;
        return true;
    }

    public bool ChangeMaxHp(int changeValue)
    {
        int tempValue = _maxHP + changeValue;

        if (tempValue <= 0)
            return false;

        if (tempValue < _curHP)
            _curHP = tempValue;

        _maxHP = tempValue;
        return true;
    }

    public void FullUpHp()
    {
        _curHP = _maxHP;
    }

    public int GetCurMp()
    {
        return _curMP;
    }

    public int GetMaxMp()
    {
        return _maxMP;
    }

    public bool ChangeCurMp(int changeValue)
    {
        int tempCurMp = _curMP + changeValue;

        if (tempCurMp < 0)
            return false;

        if (tempCurMp > _maxMP)
            tempCurMp = _maxMP;

        _curMP = tempCurMp;
        return true;
    }

    public bool ChangeMaxMp(int changeValue)
    {
        int tempMaxMp = _maxMP + changeValue;

        if (tempMaxMp < 0)
            return false;

        if (_curMP > tempMaxMp)
            _curMP = tempMaxMp;

        _maxMP = tempMaxMp;
        return true;
    }

    public void FullUpMp()
    {
        _curMP = _maxMP;
    }

    public int GetGEValue()
    {
        return _geValue;
    }

    public void ChangeGEValue(int changeValue)
    {
        int tempGEValue = _geValue + changeValue;
        _geValue = Mathf.Clamp(tempGEValue, _minGEValue, _maxGEValue);
    }

    public int GetFameValue()
    {
        return _fameValue;
    }

    public void ChangeFameValue(int changeValue)
    {
        int tempFameValue = _fameValue + changeValue;
        _fameValue = Mathf.Clamp(tempFameValue, _minFameValue, _maxFameValue);
    }

    public int GetShenFaValue()
    {
        return _shenFaValue;
    }

    public void ChangeShenFaValue(int changeValue)
    {
        int tempShenFaValue = _shenFaValue + changeValue;

        _shenFaValue = Mathf.Clamp(tempShenFaValue, _minShenFaValue, _maxShenFaValue);
    }

    public int GetLuckValue()
    {
        return _luckValue;
    }

    public void ChangeLuckValue(int changeValue)
    {
        int tempLuckValue = _luckValue + changeValue;

        _luckValue = Mathf.Clamp(tempLuckValue, _minLuckValue, _maxLuckValue);
    }

    public int GetSkillValue(SkillType skillKey)
    {
        switch (skillKey)
        {
            case SkillType.fishing:
                return _fishingSkillValue;

            case SkillType.hunting:
                return _huntingSkillValue;

            case SkillType.medicine:
                return _medicineSkillValue;

            case SkillType.cooking:
                return _cookingSkillValue;

            case SkillType.music:
                return _musicSkillValue;

            case SkillType.chess:
                return _chessSkillValue;

            case SkillType.write:
                return _writeSkillValue;

            case SkillType.draw:
                return _drawSkillValue;

            default:
                return -1;
        }
    }

    public void ChangeSkillValue(SkillType skillKey, int changeValue)
    {
        int tempSkillValue;

        switch (skillKey)
        {
            case SkillType.fishing:
                tempSkillValue = _fishingSkillValue + changeValue;
                _fishingSkillValue = Mathf.Min(tempSkillValue, _maxSkillValue);
                break;

            case SkillType.hunting:
                tempSkillValue = _huntingSkillValue + changeValue;
                _huntingSkillValue = Mathf.Min(tempSkillValue, _maxSkillValue);
                break;

            case SkillType.medicine:
                tempSkillValue = _medicineSkillValue + changeValue;
                _medicineSkillValue = Mathf.Min(tempSkillValue, _maxSkillValue); 
                break;

            case SkillType.cooking:
                tempSkillValue = _cookingSkillValue + changeValue;
                _cookingSkillValue = Mathf.Min(tempSkillValue, _maxSkillValue); ;
                break;

            case SkillType.music:
                tempSkillValue = _musicSkillValue + changeValue;
                _musicSkillValue = Mathf.Min(tempSkillValue, _maxSkillValue);
                break;

            case SkillType.chess:
                tempSkillValue = _chessSkillValue + changeValue;
                _chessSkillValue = Mathf.Min(tempSkillValue, _maxSkillValue);
                break;

            case SkillType.write:
                tempSkillValue = _writeSkillValue + changeValue;
                _writeSkillValue = Mathf.Min(tempSkillValue, _maxSkillValue);
                break;

            case SkillType.draw:
                tempSkillValue = _drawSkillValue + changeValue;
                _drawSkillValue = Mathf.Min(tempSkillValue, _maxSkillValue);
                break;

            default:
                Debug.Log("no such skill type");
                break;
        }
    }

    public bool AddBuff(string buffKey)
    {
        if (_listBuff.Contains(buffKey))
            return false;

        _listBuff.Add(buffKey);
        return true;

    }

    public bool RemoveBuff(string buffKey)
    {
        if (!_listBuff.Contains(buffKey))
            return false;

        _listBuff.Remove(buffKey);
        return true;
    }

    public string GetPlayerName()
    {
        return _playerName;
    }

    public void SetPlayerName(string playerName)
    {
        _playerName = playerName;
    }


}