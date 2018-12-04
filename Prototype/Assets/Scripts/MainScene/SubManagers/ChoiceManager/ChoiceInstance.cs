using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.MainScene;

public class ChoiceInstance : MonoBehaviour {

    private MainSceneTreeNodeManager _managerCenter;

    public Choice Choice { get; set; }

    private TextMeshPro _tChoiceName;

    private SpriteRenderer _sr;

    private string _EventId;

    private bool _isCurTarget = false;

    private bool _isSelected = false;

    private bool _isPast = false;

    private void Awake()
    {
        _tChoiceName = UnityTool.FindChildGameObject(this.gameObject, "Text").GetComponent<TextMeshPro>();
        _sr = this.gameObject.GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitializeInstance(Choice choice, MainSceneTreeNodeManager managerCenter, bool isCurTarget)
    {
        _managerCenter = managerCenter;
        _isCurTarget = isCurTarget;
        Choice = choice;
    }

    public void SetInstanceToPast()
    {
        _isCurTarget = false;
        _isSelected = false;
        _isPast = true;
        _sr.color = Color.gray;
    }

    public void SetInstanceToCurrent()
    {
        _isCurTarget = true;
        _isSelected = false;
        _isPast = false;
    }

    public void SetBoolIsCurTarget(bool temp)
    {
        _isCurTarget = temp;
    }

    public void SetBoolIsSelected(bool temp)
    {
        _isSelected = temp;
    }

    public void SetBoolIsPast(bool temp)
    {
        _isPast = temp;
    }

    private void OnMouseDown()
    {
        if (_isPast == true) return;

        if (_isSelected == true) return;

        if(_isCurTarget == true)
        {
            string outputParams = "";
            if (!_managerCenter.DoAction(DoActionKey.ShowAvailableChoices, out outputParams))
            {
                //log error
            }
            _isSelected = true;
            _sr.color = Color.gray;
        }
        else
        {
            _managerCenter.MakeChoice(this);
            _managerCenter.HideChoiceDescriptionPanel();
            SetInstanceToCurrent();
        }
    }

    private void OnMouseEnter()
    {
        if (_isPast == true) return;

        if (_isSelected == true) return;

        if (_isCurTarget == true) return;

        _managerCenter.ShowChoiceDescrptionPanel(Choice);
    }

    private void OnMouseExit()
    {
        if (_isPast == true) return;

        if (_isSelected == true) return;

        if (_isCurTarget == true) return;

        _managerCenter.HideChoiceDescriptionPanel();
    }

}
