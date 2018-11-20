public class StartScene : ISceneState
{
    private LoginSceneTreeNodeManager m_ManagerCenter;

    public StartScene(SceneStateController controller) : base(controller)
    {
    }

    public override void StateBegin()
    {
        m_ManagerCenter = new LoginSceneTreeNodeManager(m_Controller);

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