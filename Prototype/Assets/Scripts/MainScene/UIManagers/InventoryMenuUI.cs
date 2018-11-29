using Assets.Scripts.MainScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuUI : IUserInterface
{
    private Button btn_all;

    private Button btn_drug;

    private Button btn_equipment;

    private Button btn_sundry;

    private GameObject obj_itemContent;

    private Image i_itemImage;

    private TextMeshProUGUI t_itemName;

    private TextMeshProUGUI t_itemDescription;

    private Button btn_useItem;

    private Button btn_dropItem;

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
        //temporary variables
        
        var itemList = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.ItemList);
        var itemViewport = UnityTool.FindChildGameObject(itemList, MainUIComponentCollection.Viewport);

        //UI Components
        

        btn_all = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.AllBtn);
        btn_drug = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.DrugBtn);
        btn_equipment = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.EquipmentBtn);
        btn_sundry = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.SundryBtn);

        obj_itemContent = UnityTool.FindChildGameObject(itemViewport, MainUIComponentCollection.Content);

        i_itemImage = UITool.GetUIComponent<Image>(_oRootUI, MainUIComponentCollection.ItemImage);
        t_itemName = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.ItemName);
        t_itemDescription = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.ItemDescription);

        btn_useItem = UITool.GetUIComponent<Button>(MainUIComponentCollection.UseBtn);
        btn_dropItem = UITool.GetUIComponent<Button>(MainUIComponentCollection.DropBtn);

    }
}