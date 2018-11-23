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
    private int _curHP;
    private int _maxHP;
    private int _curMP;
    private int _maxMP;

    private int _geValue;
    private int _maxGEValue = 100;
    private int _minGEValue = -100;

    private int _fameValue;
    private int _maxFameValue = 100;
    private int _minFameValue = 0;

    private int _shenFaValue;
    private int _maxShenFaValue = 100;
    private int _minShenFaValue = 1;

    private int _luckValue;
    private int _maxLuckValue = 100;
    private int _minLuckValue = -100;

    private int _fishingSkillValue;
    private int _huntingSkillValue;
    private int _medicineSkillValue;
    private int _cookingSkillValue;
    private int _musicSkillValue;
    private int _chessSkillValue;
    private int _writeSkillValue;
    private int _drawSkillValue;
    private int _maxSkillValue = 100;

    private List<string> _listBuff;

    private string _playerName;
    

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

    private int GetCurHp()
    {
        return _curHP;
    }

    private int GetMaxHp()
    {
        return _maxHP;
    }

    private bool ChangeCurHp(int changeValue)
    {
        int tempHp = _curHP + changeValue;

        if (tempHp < 0)
            return false;
        
        tempHp = Mathf.Min(tempHp, _maxHP);

        _curHP = tempHp;
        return true;
    }

    private bool ChangeMaxHp(int changeValue)
    {
        int tempValue = _maxHP + changeValue;

        if (tempValue <= 0)
            return false;

        if (tempValue < _curHP)
            _curHP = tempValue;

        _maxHP = tempValue;
        return true;
    }

    private void FullUpHp()
    {
        _curHP = _maxHP;
    }

    private int GetCurMp()
    {
        return _curMP;
    }

    private int GetMaxMp()
    {
        return _maxMP;
    }

    private bool ChangeCurMp(int changeValue)
    {
        int tempCurMp = _curMP + changeValue;

        if (tempCurMp < 0)
            return false;

        if (tempCurMp > _maxMP)
            tempCurMp = _maxMP;

        _curMP = tempCurMp;
        return true;
    }

    private bool ChangeMaxMp(int changeValue)
    {
        int tempMaxMp = _maxMP + changeValue;

        if (tempMaxMp < 0)
            return false;

        if (_curMP > tempMaxMp)
            _curMP = tempMaxMp;

        _maxMP = tempMaxMp;
        return true;
    }

    private void FullUpMp()
    {
        _curMP = _maxMP;
    }

    private int GetGEValue()
    {
        return _geValue;
    }

    private void ChangeGEValue(int changeValue)
    {
        int tempGEValue = _geValue + changeValue;
        _geValue = Mathf.Clamp(tempGEValue, _minGEValue, _maxGEValue);
    }

    private int GetFameValue()
    {
        return _fameValue;
    }

    private void ChangeFameValue(int changeValue)
    {
        int tempFameValue = _fameValue + changeValue;
        _fameValue = Mathf.Clamp(tempFameValue, _minFameValue, _maxFameValue);
    }

    private int GetShenFaValue()
    {
        return _shenFaValue;
    }

    private void ChangeShenFaValue(int changeValue)
    {
        int tempShenFaValue = _shenFaValue + changeValue;

        _shenFaValue = Mathf.Clamp(tempShenFaValue, _minShenFaValue, _maxShenFaValue);
    }

    private int GetLuckValue()
    {
        return _luckValue;
    }

    private void ChangeLuckValue(int changeValue)
    {
        int tempLuckValue = _luckValue + changeValue;

        _luckValue = Mathf.Clamp(tempLuckValue, _minLuckValue, _maxLuckValue);
    }

    private int GetSkillValue(SkillType skillKey)
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

    private void ChangeSkillValue(SkillType skillKey, int changeValue)
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

    private bool AddBuff(string buffKey)
    {
        if (_listBuff.Contains(buffKey))
            return false;

        _listBuff.Add(buffKey);
        return true;

    }

    private bool RemoveBuff(string buffKey)
    {
        if (!_listBuff.Contains(buffKey))
            return false;

        _listBuff.Remove(buffKey);
        return true;
    }

    private string GetPlayerName()
    {
        return _playerName;
    }

    private void SetPlayerName(string playerName)
    {
        _playerName = playerName;
    }


}