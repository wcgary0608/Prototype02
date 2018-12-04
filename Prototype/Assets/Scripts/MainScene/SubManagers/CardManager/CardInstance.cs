using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInstance : MonoBehaviour {

    private MainSceneTreeNodeManager _managerCenter;
    private Card _card;
    public Card Card
    {
        get { return _card; }
    }

    private Toggle _instanceToggle;
    private GameObject _instanceCover;
    private Image _imgCardBg;
    private TextMeshProUGUI _cardName;
    private TextMeshProUGUI _cardDescription;
    private TextMeshProUGUI _powerCost;
    private TextMeshProUGUI _mpCost;
    private string _imagePath = "Images/Menu/Card/";



    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
        

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnToggleValueChanged()
    {

        if (_instanceToggle.isOn == true)
        {
            _instanceCover.SetActive(true);
            _managerCenter.AddCardToCurGroup(_card);
        }
        else
        {
            _instanceCover.SetActive(false);
            _managerCenter.RemoveCardFromCurGroup(_card);
        }

    }

    public void InitializeCardInstance(Card card, MainSceneTreeNodeManager managerCenter)
    {
        _managerCenter = managerCenter;

        _instanceToggle = this.gameObject.GetComponent<Toggle>();
        _instanceCover = UnityTool.FindChildGameObject(this.gameObject, "Cover");
        _imgCardBg = this.gameObject.GetComponent<Image>();
        _cardName = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "CardName");
        _cardDescription = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "CardDescription");
        _powerCost = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "PowerCost");
        _mpCost = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "MpCost");

        _instanceToggle.onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged();
        });

        if (_instanceToggle.isOn == true)
        {
            _instanceCover.SetActive(true);
        }

        _card = card;

        _cardName.SetText(_card.CardName);
        _cardDescription.SetText(_card.CardDescription);
        _powerCost.SetText(_card.PowerCost.ToString());
        

        switch (_card.CardType)
        {
            case CardTypeEnum.attakP:
                _imgCardBg.sprite = Resources.Load<Sprite>(_imagePath + "AttakP");
                break;

            case CardTypeEnum.attakPM:
                _imgCardBg.sprite = Resources.Load<Sprite>(_imagePath + "AttakPM");
                _mpCost.SetText(_card.MpCost.ToString());
                break;

            case CardTypeEnum.defendP:
                _imgCardBg.sprite = Resources.Load<Sprite>(_imagePath + "DefendP");
                break;

            case CardTypeEnum.defendPM:
                _imgCardBg.sprite = Resources.Load<Sprite>(_imagePath + "DefendPM");
                _mpCost.SetText(_card.MpCost.ToString());
                break;

            default:
                break;
        }
    }


}
