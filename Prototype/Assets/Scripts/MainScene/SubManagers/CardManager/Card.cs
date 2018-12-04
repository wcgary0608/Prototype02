using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardTargetRangeEnum
{
    single,
    multiple,
    self,
    none
}

public enum CardTypeEnum
{
    attakP, attakPM, defendP, defendPM
}

public class Card
{

    private CardTargetRangeEnum _targetType;
    public CardTargetRangeEnum TargetType
    {
        get { return _targetType; }
    }

    private string _cardId;
    public string CardId
    {
        get { return _cardId; }
    }

    private CardTypeEnum _cardType;
    public CardTypeEnum CardType
    {
        get { return _cardType; }
    }

    private string _cardName;
    public string CardName
    {
        get { return _cardName; }
    }

    private string _cardDescription = "";
    public string CardDescription
    {
        get { return _cardDescription; }
    }

    private int _dmageValue;
    public int DmageValue
    {
        get { return _dmageValue; }
    }

    private int _defenceValue;
    public int DefenceValue
    {
        get { return _defenceValue; }
    }

    private int _powerCost;
    public int PowerCost
    {
        get { return _powerCost; }
    }

    private int _mpCost;
    public int MpCost
    {
        get { return _mpCost; }
    }

    public bool IsChosen { get; set; }

    private List<ICardStrategy> _listStategy = new List<ICardStrategy>();

    public Card(string cardName, CardTypeEnum type, int dmg, int defend, int powerCost, int mpCost)
    {
        _cardName = cardName;
        _cardType = type;
        _dmageValue = dmg;
        _defenceValue = defend;
        _powerCost = powerCost;
        _mpCost = mpCost;
    }

    public virtual void InitializeCard(string[] data)
    {

    }

    public virtual void UseCard()
    {

        foreach (ICardStrategy s in _listStategy)
        {
            s.ApplyStategy();
        }
    }

}
