public class LoginSceneTreeNodeManager
{
    private SceneStateController m_SceneController;

    private UIManager m_UIManager;

    public LoginSceneTreeNodeManager(SceneStateController controller)
    {
        m_SceneController = controller;
    }

    public void InitializeManagerCenter()
    {
        InitializeManager();
    }

    public void Update()
    {
        m_UIManager.Update();
    }

    public void FixedUpdate()
    {
    }

    private void InitializeManager()
    {
        m_UIManager = new UIManager(this);
        m_UIManager.Initialize();
    }

    public virtual void ChangeToMainScene()
    {
        m_SceneController.SetState(new MainScene(m_SceneController), "MainScene");
    }
}