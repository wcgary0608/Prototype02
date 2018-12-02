using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.MainScene;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NeiGongTitleInstance : MonoBehaviour {

    private MainSceneTreeNodeManager _managerCenter;

    public NeiGong MyNeiGong { get; set; }

    private TextMeshProUGUI _tName;

    private TextMeshProUGUI _tQuality;

    private TextMeshProUGUI _tLevel;

    private Toggle _toggle;

    private Image _imgBg;



    public void InitializeInstance(NeiGong ng, MainSceneTreeNodeManager managerCenter, ToggleGroup toggleGroup)
    {
        _tName = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "Name");
        _tQuality = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "Quality");
        _tLevel = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "Level");
        _toggle = this.gameObject.GetComponent<Toggle>();
        _toggle.group = toggleGroup;
        _imgBg = this.gameObject.GetComponent<Image>();

        _toggle.onValueChanged.AddListener(delegate { OnToggleValueChanged(); });
        if (_toggle.isOn)
        {
            _imgBg.color = Color.gray;
        }

        _managerCenter = managerCenter;
        MyNeiGong = ng;

        _tName.SetText(ng.Name);
        _tQuality.SetText(ng.Quality);
        int level = ng.ListCompleteChapterIndex.Count;
        _tLevel.SetText(level.ToString());
    }

    private void OnToggleValueChanged()
    {
        if (_toggle.isOn)
        {
            _imgBg.color = Color.gray;
            string outputParams = "";
            if(!_managerCenter.DoAction(DoActionKey.UpdateNeiGongDetail, out outputParams, MyNeiGong.Id))
            {
                //log error
            }
        }
        else
        {
            _imgBg.color = Color.white;
        }
    }
    
    public void SetToggleOn()
    {
        _toggle.isOn = true;
    }

    public void UpdateLevelValue()
    {
        int value = MyNeiGong.ListCompleteChapterIndex.Count;
        _tLevel.SetText(value.ToString());
    }

}
