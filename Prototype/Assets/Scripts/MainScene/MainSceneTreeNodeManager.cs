using Assets.Scripts.MainScene;

public class MainSceneTreeNodeManager
{
    private SceneStateController m_SceneController;

    //UIManagers

    private MainPartUI UI_MainPart;

    private MenuUI UI_Menu;

    private StatusMenuUI _statusMenuUI;

    private InventoryMenuUI _inventoryMenuUI;

    private NeiGongMenuUI _neiGongMenuUI;

    private CardMenuUI _cardMenuUI;

    private SocialMenuUI _socialMenuUI;

    //GameManagers
    private InputManager m_InputManager;

    public MainSceneTreeNodeManager(SceneStateController controller)
    {
        m_SceneController = controller;
    }

    public void InitializeManagerCenter()
    {
        InitializeGameManagers();

        InitializeUIManagers();
    }

    public void Update()
    {
        m_InputManager.Update();
    }

    public void FixedUpdate()
    {
        m_InputManager.FixedUpdate();
    }

    private void InitializeGameManagers()
    {
        m_InputManager = new InputManager(this);
    }

    private void InitializeUIManagers()
    {
        UI_MainPart = new MainPartUI(this);

        UI_Menu = new MenuUI(this);

        _statusMenuUI = new StatusMenuUI(this);
        _inventoryMenuUI = new InventoryMenuUI(this);
        _neiGongMenuUI = new NeiGongMenuUI(this);
        _cardMenuUI = new CardMenuUI(this);
        _socialMenuUI = new SocialMenuUI(this);
    }

    public bool DoAction(string key, out string outputParams, string inputParams = "")
    {
        outputParams = "";
        bool localSuccess = false;
        switch (key)
        {
            case DoActionKey.SwitchMenuUI:
                localSuccess = SwitchMenuUI(out outputParams);
                return localSuccess;

            default:
                return localSuccess;
        }
    }

    public bool OpenSpecificMenu(string menuKey)
    {
        CloseAllMenus();

        bool localSuccess = false;
        switch (menuKey)
        {
            case UIMenuKey.StatusMenu:
                localSuccess = _statusMenuUI.ShowRootUI();
                return localSuccess;

            case UIMenuKey.InventoryMenu:
                localSuccess = _inventoryMenuUI.ShowRootUI();
                return localSuccess;

            case UIMenuKey.NeiGongMenu:
                localSuccess = _neiGongMenuUI.ShowRootUI();
                return localSuccess;

            case UIMenuKey.CardMenu:
                localSuccess = _cardMenuUI.ShowRootUI();
                return localSuccess;

            case UIMenuKey.SocialMenu:
                localSuccess = _socialMenuUI.ShowRootUI();
                return localSuccess;

            default:
                return localSuccess;
        }

    }

    private void CloseAllMenus()
    {
        _statusMenuUI.HideRootUI();
        _inventoryMenuUI.HideRootUI();
        _neiGongMenuUI.HideRootUI();
        _cardMenuUI.HideRootUI();
        _socialMenuUI.HideRootUI();
    }

    private bool SwitchMenuUI(out string error)
    {
        error = "";
        if (UI_Menu == null)
        {
            error = "Fail to load menu UI. Menu UI is not initialized properly";
            return false;
        }

        if (UI_Menu.isVisible())
            UI_Menu.HideRootUI();
        else
            UI_Menu.ShowRootUI();

        return true;
    }
}