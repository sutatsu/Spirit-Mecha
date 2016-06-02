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
	private Rigidbody2D rBody;
//	public GameControllerScript gameCont;

	// Use this for initialization
	void Start () {
		rBody = this.GetComponent<Rigidbody2D> ();
//		gameCont = GameObject.Find ("GameController");
	}

	// Update is called once per frame
	void Update () {

	}

	public void gainLeftVelocity(float speed)
	{
		rBody.velocity = new Vector2 (-speed, 0);
	}

	public void gainRightVelocity(float speed)
	{
		rBody.velocity = new Vector2 (speed, 0);
	}

	public void loseVelocity()
	{
	}

}
