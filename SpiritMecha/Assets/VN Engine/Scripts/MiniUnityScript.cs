using UnityEngine;
using System.Collections;

public class MinyUnityScript : MonoBehaviour {

	/*
	 * This script must maintain the little avatar which represents each units position in space (X-axis)
	 * Important things that must be maintained include distance between characters (computed on attack?)
	 * Script must communicate with the parent that creates them, receiving commands to move telling them
	 * how far to go. Therefore, this script only needs to maintain functions for moving, including
	 * how far they move. And a death script which removes it from play.
	 */

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	protected void gainLeftVelocity(float speed)
	{
		
	}

	protected void gainRightVelocity(float speed)
	{

	}

	private void loseVelocity()
	{
	}

}
