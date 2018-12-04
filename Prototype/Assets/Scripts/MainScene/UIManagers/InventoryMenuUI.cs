using Assets.Scripts.MainScene;
using Assets.Scripts.MainScene.SubManagers.InventoryManager;
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
    private GameObject _ItemContent;

    //prefab
    private GameObject _itemPrefab;


    public InventoryMenuUI(MainSceneTreeNodeManager center) : base(center)
    {
        Initialize();
    }

    public override void Initialize()
    {
        GetUIComponents();
        HideRootUI();
        AttachButtonListener();
        AddItemsToInventory();
    }

    private void AttachButtonListener()
    {
        _btnAll.onClick.AddListener(() => { openInventorySubCategory(InventoryCategoryEnum.AllItem); });
        _btnDrug.onClick.AddListener(() => { openInventorySubCategory(InventoryCategoryEnum.Drug); });
        _btnEquipment.onClick.AddListener(() => { openInventorySubCategory(InventoryCategoryEnum.Equipment); });
        _btnSundry.onClick.AddListener(() => { openInventorySubCategory(InventoryCategoryEnum.Sundry); });
        _btnUseItem.onClick.AddListener(() => { UseButtonOnclick(); });
        _btnDropItem.onClick.AddListener(() => { DropButtonOnClick(); });
    }

    private void openInventorySubCategory(InventoryCategoryEnum MenuKey)
    {
        switch (MenuKey)
        {
            case InventoryCategoryEnum.AllItem:
                Debug.Log("all item clicked");
                break;
            case InventoryCategoryEnum.Drug:
                Debug.Log("Drug item clicked");
                break;
            case InventoryCategoryEnum.Equipment:
                Debug.Log("Equipment item clicked");
                break;
            case InventoryCategoryEnum.Sundry:
                Debug.Log("Sundry item clicked");
                break;
            default:
                //do nothing
                break;
        }
    }

    private void UseButtonOnclick()
    {
        string outputParams = string.Empty;
        if (!_managerCenter.DoAction(DoActionKey.InvUseButtonOnClick, out outputParams))
        {
            Debug.Log("InvUseButtonOnClick event error");
            return;
        }
    }

    private void DropButtonOnClick()
    {
        string outputParams = string.Empty;
        if (!_managerCenter.DoAction(DoActionKey.InvDropButtonOnClick, out outputParams))
        {
            Debug.Log("InvDropButtonOnClick event error");
            return;
        }
        _itemDescription.SetText(string.Empty);
        _itemName.SetText(string.Empty);
        _imgItemImage = null;
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
        var menuUI = UITool.FindUIGameObject(MainUIComponentCollection.MenuUI);
        _oRootUI = UnityTool.FindChildGameObject(menuUI, MainUIComponentCollection.InventoryMenu);

        var itemList = UnityTool.FindChildGameObject(_oRootUI, MainUIComponentCollection.ItemList);
        var itemViewport = UnityTool.FindChildGameObject(itemList, MainUIComponentCollection.Viewport);

        //get UI Components
        _btnAll = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.AllBtn);
        _btnDrug = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.DrugBtn);
        _btnEquipment = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.EquipmentBtn);
        _btnSundry = UITool.GetUIComponent<Button>(_oRootUI, MainUIComponentCollection.SundryBtn);

        _ItemContent = UnityTool.FindChildGameObject(itemViewport, MainUIComponentCollection.Content);

        _imgItemImage = UITool.GetUIComponent<Image>(_oRootUI, MainUIComponentCollection.ItemImage);
        _itemName = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.ItemName);
        _itemDescription = UITool.GetUIComponent<TextMeshProUGUI>(_oRootUI, MainUIComponentCollection.ItemDescription);

        _btnUseItem = UITool.GetUIComponent<Button>(MainUIComponentCollection.UseBtn);
        _btnDropItem = UITool.GetUIComponent<Button>(MainUIComponentCollection.DropBtn);

        _itemPrefab = Resources.Load<GameObject>("Prefabs/UI/InventoryMenu/itemInstance");

    }

    public void AddItemsToInventory()
    {
        string Ids = string.Empty;
        if (!_managerCenter.DoAction(DoActionKey.InvGetItemList, out Ids))
        {
            Debug.Log("InvSetChosenItem event error");
        }

        string[] IdArray = Ids.Split('^');
        foreach (string Id in IdArray)
        {
            int idInt = int.MinValue;
            if (int.TryParse(Id, out idInt))
            {
                Item tempItem = ItemDatabase.Instance.GetItem(idInt);
                if (tempItem != null)
                {
                    AddItemToInvenotory(tempItem);
                }
            }
        }


    }

    public void OnItemBtnClick(Item item)
    {
        _itemDescription.SetText(item.Description);
        _itemName.SetText(item.Name);
        _imgItemImage = item.Icon;

        string outParams = string.Empty;
        if (!_managerCenter.DoAction(DoActionKey.InvSetChosenItem, out outParams, item.Id.ToString()))
        {
            Debug.Log("InvSetChosenItem event error");
        }
    }
    
    public void AddItemToInvenotory(Item item)
    {
        GameObject itemObject = GameObject.Instantiate(_itemPrefab, _ItemContent.transform);

        item.ItemObject = itemObject;

        Button itemBtn = itemObject.GetComponent<Button>();
        GameObject textObject = UnityTool.FindChildGameObject(itemObject, MainUIComponentCollection.ItemText);
        TextMeshProUGUI itemText = textObject.GetComponent<TextMeshProUGUI>();

        itemText.SetText(item.Name);
        itemBtn.onClick.AddListener(() => { OnItemBtnClick(item); });
    }

    public void getListOfItems()
    {

    }
}