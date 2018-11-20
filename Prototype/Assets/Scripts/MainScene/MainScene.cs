public class MainScene : ISceneState
{
    private MainSceneTreeNodeManager m_ManagerCenter;

    public MainScene(SceneStateController controller) : base(controller)
    {
    }

    public override void StateBegin()
    {
        m_ManagerCenter = new MainSceneTreeNodeManager(m_Controller);

        m_ManagerCenter.InitializeManagerCenter();
    }

    public override void StateEnd()
    {
    }

    public override void StateUpdate()
    {
        m_ManagerCenter.Update();
    }

    public override void StateFixedUpdate()
    {
        m_ManagerCenter.FixedUpdate();
    }
}