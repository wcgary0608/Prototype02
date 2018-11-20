using UnityEngine;

public static class UnityTool
{
    public static GameObject FindGameObject(string name)
    {
        GameObject gameObj = GameObject.Find(name);

        if (gameObj == null)
        {
            Debug.LogWarning("场景中找不到GameObject[" + name + "]对象");
            return null;
        }

        return gameObj;
    }

    public static GameObject FindChildGameObject(GameObject container, string name)
    {
        if (container == null)
        {
            Debug.LogError("UnityTool.GetChild: Container = null");
            return null;
        }

        Transform objTransform = null;

        if (container.name == name)
        {
            objTransform = container.transform;
        }
        else
        {
            Transform[] allChildren = container.transform.GetComponentsInChildren<Transform>(true);

            foreach (Transform child in allChildren)
            {
                if (child.name == name)
                {
                    if (objTransform == null)
                        objTransform = child;
                    else
                        Debug.LogWarning("Container["
                            + container.name + "]下存在重复的组件名["
                            + name + "]");
                }
            }

            if (objTransform == null)
            {
                Debug.LogError("组件[" + container.name + "]下找不到子组件[" + name + "]");
                return null;
            }
        }

        return objTransform.gameObject;
    }
}