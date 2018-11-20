using UnityEngine;

public static class UITool
{
    private static GameObject m_CanvasObj = null;

    public static GameObject FindUIGameObject(string UIName)
    {
        if (m_CanvasObj == null)
            m_CanvasObj = UnityTool.FindGameObject("Canvas");

        if (m_CanvasObj == null)
            return null;

        return UnityTool.FindChildGameObject(m_CanvasObj, UIName);
    }

    public static T GetUIComponent<T>(GameObject container, string name) where T : UnityEngine.Component
    {
        GameObject childObj = UnityTool.FindChildGameObject(container, name);

        if (childObj == null)
            return null;

        T tempObj = childObj.GetComponent<T>();

        if (tempObj == null)
        {
            Debug.LogWarning("组件[" + name + "]不包含[" + typeof(T) + "]");
            return null;
        }

        return tempObj;
    }

    public static T GetUIComponent<T>(string name) where T : UnityEngine.Component
    {
        GameObject Obj = FindUIGameObject(name);

        if (Obj == null)
            return null;

        T tempObj = Obj.GetComponent<T>();

        if (tempObj == null)
        {
            Debug.LogWarning("组件[" + name + "]不包含[" + typeof(T) + "]");
            return null;
        }

        return tempObj;
    }
}