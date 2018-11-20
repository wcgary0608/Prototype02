using UnityEngine.SceneManagement;

public class SceneStateController
{
    private ISceneState m_State;

    private bool m_bRunBegin = false;

    private bool m_bLoadingScene = true;

    public void Initialize()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        m_bLoadingScene = false;
    }

    public void Update()
    {
        if (m_bLoadingScene == true)
            return;

        if (m_State != null && m_bRunBegin == false)
        {
            m_State.StateBegin();
            m_bRunBegin = true;
        }

        if (m_State != null)
            m_State.StateUpdate();
    }

    public void FixedUpdate()
    {
        if (m_bLoadingScene == true)
            return;

        if (m_State != null && m_bRunBegin == true)
            m_State.StateFixedUpdate();
    }

    /// <summary>
    /// set the scene variables for initialization
    /// </summary>
    /// <param name="state">the state of the scene</param>
    /// <param name="sceneName">the scene name</param>
    public void SetState(ISceneState state, string sceneName)
    {
        m_bRunBegin = false;
        m_bLoadingScene = true;

        LoadScene(sceneName);

        if (m_State != null)
            m_State.StateEnd();

        m_State = state;
    }

    private void LoadScene(string sceneName)
    {
        if (sceneName == null || sceneName.Length == 0)
            return;

        SceneManager.LoadScene(sceneName);
    }
}