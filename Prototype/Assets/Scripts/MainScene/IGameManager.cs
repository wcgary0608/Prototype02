public abstract class IGameManager
{
    protected MainSceneTreeNodeManager m_ManagerCenter = null;

    public IGameManager(MainSceneTreeNodeManager center)
    {
        m_ManagerCenter = center;
    }

    public virtual void Initialize()
    {
    }

    public virtual void Release()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }
}