using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Disables the foreground. Foreground is automatically re enabled when Set Foreground is used.
// Used so foreground image does not stop the user from interacting with the UI.
public class DisableForegroundNode : Node 
{
	
	public override void Run_Node()
	{
		UIManager.ui_manager.foreground.gameObject.SetActive(false);
		Finish_Node();
	}
	
	
	public override void Finish_Node()
	{
		StopAllCoroutines();
		
		base.Finish_Node();
	}
}
