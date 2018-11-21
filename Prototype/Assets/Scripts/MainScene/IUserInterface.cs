using UnityEngine;

public class IUserInterface
{
    protected MainSceneTreeNodeManager m_ManagerCenter = null;
    protected GameObject m_RootUI = null;
    private bool m_bActive = true;

    public IUserInterface(MainSceneTreeNodeManager center)
    {
        m_ManagerCenter = center;
    }

    public bool isVisible()
    {
        return m_bActive;
    }

    public virtual bool ShowRootUI()
    {
        m_RootUI.SetActive(true);
        m_bActive = true;

        return m_bActive;
    }

    public virtual void HideRootUI()
    {
        m_RootUI.SetActive(false);
        m_bActive = false;
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