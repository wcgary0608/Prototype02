using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : IGameManager
{
    private int _curHP;
    private int _maxHP;
    private int _curMP;
    private int _maxMP;

    private int _geValue;
    private int _fameValue;
    private int _shenFaValue;
    private int _luckValue;

    private int _fishingSkillValue;
    private int _huntingSkillValue;
    private int _medicineSkillValue;
    private int _cookingSkillValue;
    private int _musicSkillValue;
    private int _chessSkillValue;
    private int _writeSkillValue;
    private int _drawSkillValue;

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

}