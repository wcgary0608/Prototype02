using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private SceneStateController m_SceneStateController;

    /// <summary>
    /// the SOLE awake API for the script. Defining the entry point
    /// </summary>
    private void Awake()
    {
        m_SceneStateController = new SceneStateController();

        GameObject.DontDestroyOnLoad(this.gameObject);

        //passing null scene name to prevent extra loading from SceneStateController as Unity will load one scene by default when it is opened.
        m_SceneStateController.SetState(new StartScene(m_SceneStateController), "");
    }

    /// <summary>
    /// Set loading flag
    /// </summary>
    private void OnEnable()
    {
        m_SceneStateController.Initialize();
    }

    /// <summary>
    /// called after scene loading finished
    /// </summary>
    private void Start()
    {
    }

    /// <summary>
    /// called once per frame
    /// </summary>
    private void Update()
    {
        m_SceneStateController.Update();
    }

    private void FixedUpdate()
    {
        m_SceneStateController.FixedUpdate();
    }
}