using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts.MainScene;

public class ChapterInstance : MonoBehaviour
{
    private MainSceneTreeNodeManager _managerCenter;

    public int Index;

    public Image _imgBg;

    public GameObject DefaultCover;

    public GameObject CompleteCover;

    public TextMeshProUGUI ChapterName;

    public Toggle Toggle;


    private void Start()
    {
        //_toggle = this.gameObject.GetComponent<Toggle>();
        //_tChapterName = UITool.GetUIComponent<TextMeshProUGUI>(this.gameObject, "ChapterName");
        //_oDefaultCover = UnityTool.FindChildGameObject(this.gameObject, "DefaultCover");
        //_oCompleteCover = UnityTool.FindChildGameObject(this.gameObject, "CompleteCover");
    }


    public void InitializeInstance(string Name,MainSceneTreeNodeManager managerCenter)
    {
        _managerCenter = managerCenter;
        ChapterName.SetText(Name);

    }

    public void ActivateChapter()
    {
        DefaultCover.SetActive(false);
        Toggle.interactable = true;
    }

    public void SetToDefault()
    {
        DefaultCover.SetActive(true);
        CompleteCover.SetActive(false);
        Toggle.interactable = false;
        Toggle.isOn = false;
    }

    public void ChapterComplete()
    {
        CompleteCover.SetActive(true);
        DefaultCover.SetActive(false);
        Toggle.interactable = false;
    }

    public void OnToggleValueChanged()
    {
        string outputParams = "";

        if (Toggle.isOn)
        {
            _managerCenter.DoAction(DoActionKey.UpdateNeiGongCAPanel, out outputParams, Index.ToString());
            _imgBg.color = Color.red;
        }
        else
        {
            _managerCenter.DoAction(DoActionKey.ClearCAPanel, out outputParams);
            _imgBg.color = Color.black;
        }

    }

}
