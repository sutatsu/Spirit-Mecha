using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Removes all actors from the scene. If sliding out, waits until the actor if offscreen first 
public class ExitAllActorsNode : Node
{
    public bool slide_out = false;  // If true, have all characters slide out before being destroyed
    public bool fade_out = false;

    public override void Run_Node()
    {
        if (!slide_out && !fade_out)
        {
            for (int x = ActorManager.actors_on_scene.Count - 1; x >= 0; x--)
            {
                ActorManager.Remove_Actor(ActorManager.actors_on_scene[x]);
            }
        }
        else
        {
            for (int x = ActorManager.actors_on_scene.Count - 1; x >= 0; x--)
            {
                Actor actor = ActorManager.actors_on_scene[x];

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
            }
        }

        Finish_Node();
    }


    public override void Finish_Node()
    {
        base.Finish_Node();
    }
}
