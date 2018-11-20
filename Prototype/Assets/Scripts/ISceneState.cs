public class ISceneState
{
    private string m_StateName = "ISceneStateName";

    public string StateName
    {
        get { return m_StateName; }
        set { m_StateName = value; }
    }

    public SceneStateController m_Controller = null;

    public ISceneState(SceneStateController controller)
    {
        m_Controller = controller;
    }

    public virtual void StateBegin()
    {
    }

    public virtual void StateUpdate()
    {
    }

    public virtual void StateFixedUpdate()
    {
    }

    public virtual void StateEnd()
    {
    }

    public override string ToString()
    {
        return string.Format("[I_SceneState: StateName = {0}", StateName);
    }
}