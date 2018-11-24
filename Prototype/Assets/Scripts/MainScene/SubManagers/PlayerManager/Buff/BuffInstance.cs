using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Assets.Scripts.MainScene;

public class BuffInstance : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    private Image _imgBuffInstanceImg;

    private TextMeshProUGUI _tBuffName;

    private Buff _buff;

    private MainSceneTreeNodeManager _managerCenter;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitializeInstance(Buff buff, MainSceneTreeNodeManager managerCenter)
    {
        _managerCenter = managerCenter;

        _buff = buff;

        buff.SetBuffInstanceObj(this.gameObject);

        _imgBuffInstanceImg = this.gameObject.GetComponent<Image>();
        switch (_buff.GetBuffType())
        {
            case BuffTypeEnum.buff:
                _imgBuffInstanceImg.color = new Color(0f, 0.5f, 0f);
                break;

            case BuffTypeEnum.debuff:
                _imgBuffInstanceImg.color = new Color(0.5f, 0f, 0f);
                break;

            default:
                break;
        }

        _tBuffName = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "Text");
        _tBuffName.SetText(_buff.GetBuffName());
        


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("mouse enter ");
        string outputParams = "";

        _managerCenter.DoAction(DoActionKey.SwitchBuffDescription, out outputParams, _buff.GetBuffDescription());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("mouse exit ");
        string outputParams = "";

        _managerCenter.DoAction(DoActionKey.SwitchBuffDescription, out outputParams, _buff.GetBuffDescription());
    }
}
