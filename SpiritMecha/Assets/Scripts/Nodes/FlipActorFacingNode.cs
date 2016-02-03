using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Flips the facing of the actor. (left to right, or right to left 
public class FlipActorFacingNode : Node
{
    public string actor_name;

    public override void Run_Node()
    {
        Actor actor = ActorManager.Get_Actor(actor_name);
        Vector3 scale = actor.transform.localScale;
        scale.x = -scale.x;
        actor.transform.localScale = scale;

        Finish_Node();
    }


    public override void Finish_Node()
    {
        StopAllCoroutines();

        base.Finish_Node();
    }
}
