using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

	//This code should control the entire fight in the game, managing when
	/* the enemies, the player Katai, Kikai's questions and answers, all 
	 * of the weapons, etc. Katai should hold 4 visual objects, and 4 internal
	 * objects, all objects within Katai code, for testing perhaps just here?
	 * The enemy will need a list, each enemy also possessing a list of weapons
	 * they possess. Enemies will need rudimentary AI which says to attack and
	 * move. This script will query everyone on what they are doing every
	 * second, and let them decide as such. Enemy Controller would be a good 
	 * script to have. For now, let's worry about one step at a time.
	 * Katai needs guns to shoot, let's give her guns.
	 */

	public CountdownTimer ButtonMainArm;
	public CountdownTimer ButtonSupportArm;
	public CountdownTimer ButtonShoulder;
	public CountdownTimer ButtonBack;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//Receive input from four visual weapon buttons and do things.
	void inputMainArm(){
		ButtonMainArm.setTimer (1);
	}

	void inputSupportArm(){
		ButtonMainArm.setTimer (1);
	}

	void inputShoulder(){
		ButtonMainArm.setTimer (1);
	}

	void inputBack(){
		ButtonMainArm.setTimer (1);
	}


}
