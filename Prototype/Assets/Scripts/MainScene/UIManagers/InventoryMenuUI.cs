using Assets.Scripts.MainScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuUI : IUserInterface
{
    //buttons
    private Button _btnAll;
    private Button _btnDrug;
    private Button _btnEquipment;
    private Button _btnSundry;
    private Button _btnUseItem;
    private Button _btnDropItem;

    //images
    private Image _imgItemImage;

    //text
    private TextMeshProUGUI _itemName;
    private TextMeshProUGUI _itemDescription;


    //objects
    private GameObject _oItemContent;

    //prefab

    public InventoryMenuUI(MainSceneTreeNodeManager center) : base(center)
    {
        Initialize();
    }

    public override void Initialize()
    {
        GetUIComponents();
        HideRootUI();
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
        var MenuUI = UITool.FindUIGameObject(MainUIComponentCollection.MenuUI);
        _oRootUI = UnityTool.FindChildGameObject(MenuUI, MainUIComponentCollection.InventoryMenu);

        var itemList = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.ItemList);
        var itemViewport = UnityTool.FindChildGameObject(itemList, MainUIComponentCollection.Viewport);

        //get UI Components
        _btnAll = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.AllBtn);
        _btnDrug = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.DrugBtn);
        _btnEquipment = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.EquipmentBtn);
        _btnSundry = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.SundryBtn);

        _oItemContent = UnityTool.FindChildGameObject(itemViewport, MainUIComponentCollection.Content);

        _imgItemImage = UITool.GetUIComponent<Image>(_oRootUI, MainUIComponentCollection.ItemImage);
        _itemName = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.ItemName);
        _itemDescription = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.ItemDescription);

        _btnUseItem = UITool.GetUIComponent<Button>(MainUIComponentCollection.UseBtn);
        _btnDropItem = UITool.GetUIComponent<Button>(MainUIComponentCollection.DropBtn);

    }
}