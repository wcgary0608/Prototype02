using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.MainScene;

public class BuffInstance : MonoBehaviour {

    private GameObject _oBuffInstance;

    private Image _imgBuffInstanceImg;

    private TextMeshProUGUI _tBuffName;

    private string _buffKey;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitializeInstance(string buffKey)
    {
        _oBuffInstance = this.gameObject;

        _imgBuffInstanceImg = _oBuffInstance.GetComponent<Image>();

        _tBuffName = UITool.GetUIComponent<TextMeshProUGUI>(_oBuffInstance, "Text");

        _buffKey = buffKey;
    }

    private void OnMouseEnter()
    {
        Debug.Log("mouse enter ");
        string outputParams = "";
        
        MainSceneTreeNodeManager.Instance.DoAction(DoActionKey.SwitchBuffDescription, out outputParams, _buffKey);
    }

}
