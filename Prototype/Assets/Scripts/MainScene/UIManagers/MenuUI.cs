using Assets.Scripts.MainScene;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : IUserInterface
{
    private GameObject obj_menuChoices;

    private Toggle[] list_menuTitles;

    public MenuUI(MainSceneTreeNodeManager center) : base(center)
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
        m_RootUI = UITool.FindUIGameObject(MainUIComponentCollection.MenuUI);

        obj_menuChoices = UnityTool.FindChildGameObject(m_RootUI, MainUIComponentCollection.MenuChoices);

        list_menuTitles = obj_menuChoices.GetComponentsInChildren<Toggle>();
    }
}