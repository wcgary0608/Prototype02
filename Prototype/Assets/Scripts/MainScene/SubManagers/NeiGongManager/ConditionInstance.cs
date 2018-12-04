using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConditionInstance : MonoBehaviour {

    private Image _imgBg;

    private TextMeshProUGUI _tConditionValue;

    
    public void InitializeInstance(string value, bool isConditionMet)
    {
        _imgBg = this.gameObject.GetComponent<Image>();
        _tConditionValue = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "ConditionValue");

        _tConditionValue.SetText(value);

        if (isConditionMet)
        {
            _imgBg.color = Color.green;
        }

    }


}
