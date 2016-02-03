using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Brightens the given actor 
public class BrightenActorNode : Node
{
    public string actor_name;   // Actor to brighten

    public override void Run_Node()
    {
        ActorManager.Get_Actor(actor_name).Lighten();

        Finish_Node();
    }


    public override void Finish_Node()
    {
        StopAllCoroutines();

        base.Finish_Node();
    }
}
