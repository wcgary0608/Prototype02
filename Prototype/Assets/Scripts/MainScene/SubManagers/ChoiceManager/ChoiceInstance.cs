using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.MainScene;

public class ChoiceInstance : MonoBehaviour {

    private MainSceneTreeNodeManager _managerCenter;

    private TextMeshPro _tChoiceName;

    private string _EventId;

    private bool _isPast = false;

    private void Awake()
    {
        _tChoiceName = UnityTool.FindChildGameObject(this.gameObject, "Text").GetComponent<TextMeshPro>();
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitializeInstance(Choice choice, MainSceneTreeNodeManager managerCenter)
    {
        _managerCenter = managerCenter;
    }

    private void OnMouseDown()
    {
        string outputParams = "";
        if(!_managerCenter.DoAction(DoActionKey.ShowAvailableChoices, out outputParams))
        {
            //log error
        }
    }

}
