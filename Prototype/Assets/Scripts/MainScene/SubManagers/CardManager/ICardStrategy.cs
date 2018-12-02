using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICardStrategy {

    public Card Card { get; set; }

    public ICardStrategy(Card card)
    {
        Card = card;
    }

    public virtual void ApplyStategy()
    {

    }
}
