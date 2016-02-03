using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Not used in real code. Merely a template to copy and paste from when creating new nodes.
public class NodeTemplate : Node 
{
	public override void Run_Node()
	{
		//StartCoroutine();
	}


    // As an example, when the user clicks the button, proceed to the next Node. Often you will not want this behaviour, so you may leave it blank.
	public override void Button_Pressed()
	{
		Finish_Node();
	}


	public override void Finish_Node()
	{
		StopAllCoroutines();
		
		base.Finish_Node();
	}
}
