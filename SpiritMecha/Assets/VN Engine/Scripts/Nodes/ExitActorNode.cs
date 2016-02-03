﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Removes the actor from the scene. If sliding out, waits until the actor if offscreen first
public class ExitActorNode : Node
{
    public string actor_name;
    public bool slide_out = false;  // If true, have the character slide out before being destroyed
    public bool fade_out = false;

    public override void Run_Node()
    {
        if (!slide_out && !fade_out)
        {
            ActorManager.Remove_Actor(actor_name);
            Finish_Node();
        }
        else
        {
            Actor actor = ActorManager.Get_Actor(actor_name);

            if (fade_out)
            {
                // Fade out
                actor.Fade_Out(1f);
            }
            else
            {
                // Slide out
                actor.Slide_Out(1f);
            }

            StartCoroutine(Wait(actor));
        }
    }


    // Wait until the actor has left the scene
    IEnumerator Wait(Actor actor)
    {
        while (actor != null)
            yield return new WaitForSeconds(0.1f);
        Finish_Node();
    }


    public override void Finish_Node()
    {
        Debug.Log("Finished exit all node");
        base.Finish_Node();
    }
}
