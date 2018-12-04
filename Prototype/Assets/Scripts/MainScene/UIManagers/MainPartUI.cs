using Assets.Scripts.MainScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainPartUI : IUserInterface
{
    private GameObject _oStatusPanel;

    private GameObject _oTimeWheel;

    private GameObject _oLocationPanel;

    private TextMeshProUGUI _tHpValue;

    private TextMeshProUGUI _tMpValue;

    private TextMeshProUGUI _tActionValue;

    private TextMeshProUGUI _tMonth;

    private TextMeshProUGUI _tLocationName;

    private Image _imgHpFill;

    private Image _imgMpFill;

    public MainPartUI(MainSceneTreeNodeManager center) : base(center)
    {
        
    }

    public override void Initialize()
    {
        GetUIComponents();

        string outputParams = "";
        if (!_managerCenter.DoAction(DoActionKey.InitializeMainPartComponents, out outputParams))
        {
            //log error
        }
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }



    private void GetUIComponents()
    {
        _oRootUI = UITool.FindUIGameObject(MainUIComponentCollection.MainPartUI);

        _oStatusPanel = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.StatusBar);

        _oTimeWheel = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.TimeWheel);

        _oLocationPanel = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.LocationBar);

        _imgHpFill = UITool.GetUIComponent<Image>(_oRootUI, MainUIComponentCollection.HpFill);

        _imgMpFill = UITool.GetUIComponent<Image>(_oRootUI, MainUIComponentCollection.MpFill);

        _tHpValue = UITool.GetUIComponent<TextMeshProUGUI>(_oStatusPanel, MainUIComponentCollection.HpValue);

        _tMpValue = UITool.GetUIComponent<TextMeshProUGUI>(_oStatusPanel, MainUIComponentCollection.MpValue);

        _tActionValue = UITool.GetUIComponent<TextMeshProUGUI>(_oTimeWheel, MainUIComponentCollection.ActionValue);

        _tMonth = UITool.GetUIComponent<TextMeshProUGUI>(_oTimeWheel, MainUIComponentCollection.MonthValue);

        _tLocationName = UITool.GetUIComponent<TextMeshProUGUI>(_oLocationPanel, MainUIComponentCollection.LocationName);
    }

    public bool SetTextForMainPart(TextInMainPartEnum textKey, string newText)
    {
        switch (textKey)
        {
            case TextInMainPartEnum.hpValue:
                _tHpValue.SetText(newText);
                return true;

            case TextInMainPartEnum.mpValue:
                _tMpValue.SetText(newText);
                return true;

            case TextInMainPartEnum.actionValue:
                _tActionValue.SetText(newText);
                return true;

            case TextInMainPartEnum.month:
                _tMonth.SetText(newText);
                return true;

            case TextInMainPartEnum.locationName:
                _tLocationName.SetText(newText);
                return true;

            default:
                Debug.Log("no such TextType in MainPart");
                return false;
        }
    }

    public void SetHpFillAmount(float fillAmount)
    {
        _imgHpFill.fillAmount = fillAmount;
    }

    public void SetMpFillAmount(float fillAmount)
    {
        _imgMpFill.fillAmount = fillAmount;
    }

}