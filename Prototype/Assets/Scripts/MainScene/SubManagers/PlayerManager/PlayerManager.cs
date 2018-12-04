using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// TBD:GiftList / Connection with ChoiceManager / Equipment
/// </summary>

public class PlayerManager : IGameManager
{
    public PlayerAttribute PlayerAttribute;
    



    public PlayerManager(MainSceneTreeNodeManager center) : base(center)
    {

    }

    public override void Initialize()
    {
        InitializePlayerValue();
    }

    public override void Release()
    {
    }

    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
    }

    private void InitializePlayerValue()
    {
        PlayerAttribute = new PlayerAttribute();
        PlayerAttribute.InitializePlayer();
    }


    


}