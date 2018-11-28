using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute{

    private int _curHp = 10;
    public int CurHp
    {
        get { return _curHp; }
        set
        {
            if (value < 0) return;
            value = Mathf.Min(value, _maxHp);
            _curHp = value;
        }
    }

    private int _maxHp = 10;
    public int MaxHp
    {
        get { return _maxHp; }
        set
        {
            if (value <= 0) return;

            if (value < _curHp)
            {
                _curHp = value;
            }     
            _maxHp = value;
        }
    }

    public float HpFillAmount
    {
        get
        {
            return (float)_curHp / _maxHp;
        }
    }

    private int _curMp = 3;
    public int CurMp
    {
        get { return _curMp; }
        set
        {
            if (value < 0) return;

            if (value > _maxMp)
            {
                value = _maxMp;
            }
            _curMp = value;
        }
    }

    private int _maxMp = 5;
    public int MaxMp
    {
        get { return _maxMp; }
        set
        {
            if (value < 0) return;

            if (_curMp > value)
            {
                _curMp = value;
            }    
            _maxMp = value;
        }
    }

    public float MpFillAmount
    {
        get
        {
            float fillAmount;
            if (_curMp == 0)
            {
                fillAmount = 0;
            }
            else
            {
                fillAmount = (float)_curMp / _maxMp;
            }
            return fillAmount;
        }
    }

    private int _geValue = 0;
    public int GEValue
    {
        get { return _geValue; }
        set
        {
            _geValue = Mathf.Clamp(value, _minGEValue, _maxGEValue);
        }
    }
    private const int _maxGEValue = 100;
    private const int _minGEValue = -100;

    private int _fameValue = 0;
    public int FameValue
    {
        get { return _fameValue; }
        set
        {
            _fameValue = Mathf.Clamp(value, _minFameValue, _maxFameValue);
        }
    }
    private const int _maxFameValue = 100;
    private const int _minFameValue = 0;

    private int _shenFaValue = 2;
    public int ShenFaValue
    {
        get { return _shenFaValue; }
        set
        {
            _shenFaValue = Mathf.Clamp(value, _minShenFaValue, _maxShenFaValue);
        }
    }
    private const int _maxShenFaValue = 100;
    private const int _minShenFaValue = 1;

    private int _luckValue = 0;
    public int LuckValue
    {
        get { return _luckValue; }
        set
        {
            _luckValue = Mathf.Clamp(value, _minLuckValue, _maxLuckValue);
        }
    }
    private const int _maxLuckValue = 100;
    private const int _minLuckValue = -100;

    //Skills
    private int _fishingSkillValue = 1;
    public int FishingSkillValue
    {
        get { return _fishingSkillValue; }
        set
        {
            _fishingSkillValue = Mathf.Min(value, _maxSkillValue);
        }
    }

    private int _huntingSkillValue = 1;
    public int HuntingSkillValue
    {
        get { return _huntingSkillValue; }
        set
        {
            _huntingSkillValue = Mathf.Min(value, _maxSkillValue);
        }
    }

    private int _medicineSkillValue = 1;
    public int MedicineSkillValue
    {
        get { return _medicineSkillValue; }
        set
        {
            _medicineSkillValue = Mathf.Min(value, _maxSkillValue);
        }
    }

    private int _cookingSkillValue = 1;
    public int CookingSkillValue
    {
        get { return _cookingSkillValue; }
        set
        {
            _cookingSkillValue = Mathf.Min(value, _maxSkillValue); 
        }
    }

    private int _musicSkillValue = 1;
    public int MusicSkillValue
    {
        get { return _musicSkillValue; }
        set
        {
            _musicSkillValue = Mathf.Min(value, _maxSkillValue);
        }
    }

    private int _chessSkillValue = 1;
    public int ChessSkillValue
    {
        get { return _chessSkillValue; }
        set
        {
            _chessSkillValue = Mathf.Min(value, _maxSkillValue);
        }
    }

    private int _writeSkillValue = 1;
    public int WriteSkillValue
    {
        get { return _writeSkillValue; }
        set
        {
            _writeSkillValue = Mathf.Min(value, _maxSkillValue);
        }
    }

    private int _drawSkillValue = 1;
    public int DrawSkillValue
    {
        get { return _drawSkillValue; }
        set
        {
            _drawSkillValue = Mathf.Min(value, _maxSkillValue);
        }
    }

    private const int _maxSkillValue = 100;

    public string PlayerName { get; set; }

    private List<Buff> _listBuff = new List<Buff>();
    public List<Buff> ListBuff
    {
        get { return _listBuff; }
    }




    public PlayerAttribute()
    {
    }

    public void InitializePlayer()
    {
        PlayerName = "贾健程";

        InitializePlayerBuffList();
    }

    private void InitializePlayerBuffList()
    {
        List<string> buffKeyList = StaticData.Instance.InitializeTestBuffList();

        foreach (string key in buffKeyList)
        {
            BuffData data = StaticData.Instance.GetBuffDataFromDic(key);

            if (data != null)
            {
                Buff buff = new Buff(data);
                _listBuff.Add(buff);
            }
            else
                continue;
        }

    }

    public bool AddBuff(string buffKey)
    {
        BuffData buffData = StaticData.Instance.GetBuffDataFromDic(buffKey);
        Buff buff = new Buff(buffData);

        if (_listBuff.Contains(buff))
            return false;

        _listBuff.Add(buff);
        return true;

    }

    public bool RemoveBuff(string buffKey)
    {
        bool isSuccess = false;

        foreach (Buff buff in _listBuff)
        {
            string key = buff.GetBuffKey();
            if (buffKey == key)
            {
                _listBuff.Remove(buff);
                isSuccess = true;
            }

        }

        return isSuccess;
    }

    public int GetSkillValue(SkillTypeEnum skillKey)
    {
        switch (skillKey)
        {
            case SkillTypeEnum.fishing:
                return _fishingSkillValue;

            case SkillTypeEnum.hunting:
                return _huntingSkillValue;

            case SkillTypeEnum.medicine:
                return _medicineSkillValue;

            case SkillTypeEnum.cooking:
                return _cookingSkillValue;

            case SkillTypeEnum.music:
                return _musicSkillValue;

            case SkillTypeEnum.chess:
                return _chessSkillValue;

            case SkillTypeEnum.write:
                return _writeSkillValue;

            case SkillTypeEnum.draw:
                return _drawSkillValue;

            default:
                return -1;
        }
    }

    public void ChangeSkillValue(SkillTypeEnum skillKey, int changeValue)
    {

        switch (skillKey)
        {
            case SkillTypeEnum.fishing:
                FishingSkillValue = changeValue;
                break;

            case SkillTypeEnum.hunting:
                HuntingSkillValue = changeValue;
                break;

            case SkillTypeEnum.medicine:
                MedicineSkillValue = changeValue;
                break;

            case SkillTypeEnum.cooking:
                CookingSkillValue = changeValue;
                break;

            case SkillTypeEnum.music:
                MusicSkillValue = changeValue;
                break;

            case SkillTypeEnum.chess:
                ChessSkillValue = changeValue;
                break;

            case SkillTypeEnum.write:
                WriteSkillValue = changeValue;
                break;

            case SkillTypeEnum.draw:
                DrawSkillValue = changeValue;
                break;

            default:
                Debug.Log("no such skill type");
                break;
        }
    }

}
