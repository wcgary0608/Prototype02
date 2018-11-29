using Assets.Scripts.MainScene;
using UnityEngine;

public class InputManager : IGameManager
{
    public InputManager(MainSceneTreeNodeManager center) : base(center)
    {
    }

    public override void Initialize()
    {
    }

    public override void Release()
    {
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchMenuUI();
        }
    }

    public override void FixedUpdate()
    {
    }

    private void SwitchMenuUI()
    {
        //打开主菜单---ESC
        string outputParams = "";
        if (!_managerCenter.DoAction(DoActionKey.SwitchMenuUI, out outputParams))
        {
            //log error
        }
    }
}