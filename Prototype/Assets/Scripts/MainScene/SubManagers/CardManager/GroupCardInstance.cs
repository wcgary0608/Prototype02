using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroupCardInstance : MonoBehaviour {

    public Card Card { get; set; }

    private TextMeshProUGUI _powerCost;

    private TextMeshProUGUI _mpCost;

    private TextMeshProUGUI _cardName;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitializeGroupCardInstance(Card card)
    {
        _powerCost = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "PowerCost");
        _mpCost = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "MpCost");
        _cardName = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "CardName");

        Card = card;
        _powerCost.SetText(card.PowerCost.ToString());
        _mpCost.SetText(card.MpCost.ToString());
        _cardName.SetText(card.CardName);
    }
}
