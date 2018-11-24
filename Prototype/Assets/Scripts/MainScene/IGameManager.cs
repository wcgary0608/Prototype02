public abstract class IGameManager
{
    protected MainSceneTreeNodeManager _managerCenter = null;

    public IGameManager(MainSceneTreeNodeManager center)
    {
        _managerCenter = center;
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