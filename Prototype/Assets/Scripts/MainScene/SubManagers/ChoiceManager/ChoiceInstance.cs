using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceInstance : MonoBehaviour {

    private TextMeshPro _tChoiceName;

    private string _EventId;

    private bool _isPast = false;

	// Use this for initialization
	void Start () {
        _tChoiceName = UnityTool.FindChildGameObject(this.gameObject, "Text").GetComponent<TextMeshPro>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
