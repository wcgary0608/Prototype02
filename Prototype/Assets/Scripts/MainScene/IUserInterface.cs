using UnityEngine;

public class IUserInterface
{
    protected MainSceneTreeNodeManager _managerCenter = null;
    protected GameObject _oRootUI = null;
    private bool _isActive = true;

    public IUserInterface(MainSceneTreeNodeManager center)
    {
        _managerCenter = center;
    }

    public bool isVisible()
    {
        return _isActive;
    }

    public virtual bool ShowRootUI()
    {
        _oRootUI.SetActive(true);
        _isActive = true;

        return _isActive;
    }

    public virtual void HideRootUI()
    {
        _oRootUI.SetActive(false);
        _isActive = false;
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