using UnityEngine.UI;
using Assets.Scripts.StartScene;

public class UIManager
{
    private LoginSceneTreeNodeManager m_ManagerCenter;

    private Button btn_start;

    public UIManager(LoginSceneTreeNodeManager center)
    {
        m_ManagerCenter = center;
    }

    public void Initialize()
    {
        btn_start = UITool.GetUIComponent<Button>(StartUIComponentCollection.StartBtn);

        btn_start.onClick.AddListener(OnStartBtnClick);
    }

    public void Release()
    {
    }

    public void Update()
    {
    }

    private void OnStartBtnClick()
    {
        m_ManagerCenter.ChangeToMainScene();
    }
}