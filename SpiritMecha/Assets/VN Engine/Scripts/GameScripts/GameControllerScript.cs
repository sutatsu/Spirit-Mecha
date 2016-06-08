using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	//This code should control the entire fight in the game, managing when
	/* the enemies, the player Katai, Kikai's questions and answers, all 
	 * of the weapons, etc. Katai should hold 4 visual objects, and 4 internal
	 * objects, all objects within Katai code, for testing perhaps just here?
	 * The enemy will need a list, each enemy also possessing a list of attacks
	 * they possess. Enemies will need rudimentary AI which says to attack and
	 * move. This script will query everyone on what they are doing every
	 * second, and let them decide as such. Enemy Controller would be a good 
	 * script to have. For now, let's worry about one step at a time.
	 * Katai needs guns to shoot, let's give her guns.
	 */

//	public CountdownTimer ButtonMainArm;
//	public CountdownTimer ButtonSupportArm;
//	public CountdownTimer ButtonShoulder;
//	public CountdownTimer ButtonBack;

	public bool LINEBREAK;

	public KataiScript KataiPrefab; //Prefab, assign in Inspector
	public TestTankScript EnemyPrefab;  //Prefab, assign in Inspector
	public List<UnitClass> enemyScriptList;

	public bool LINEBREAK2;

	public Animator PlayerHealthbar;
	//player energy bar
	public Animator EnemyHealthBar;
	public GameObject EnemyHealthShardParent;
	public HealthShardMod EnemyHealthShardText;
	//enemy energy bar

	public UpdateTextToVariable enemyTextToUpdate; //Player healthbar
	//Enemy healthbar

	public bool LINEBREAK3;

	//Leave unassigned in Inspector
	public KataiScript kataiInstance;
	public TestTankScript enemyInstance; //The target of Katai's weapons
	public List<TestTankScript> enemyList;

	private WeaponClass WeaponMainArm;
	private WeaponClass WeaponSupportArm;
	private WeaponClass WeaponShoulder;
	private WeaponClass WeaponBack;

	public MiniKataiScript miniKataiPrefab;
	public MiniKataiScript miniKatai;
//	private List<MiniEnemyScript> miniEnemyList;

	public bool LINEBREAK4;

//	public List<TestTankScript> enemiesToSpawnList;

	private bool fightWon = false;


	//Use this for initialization
	//Because it's all in Start I can start with the GameController OFF!!! YAY!~
	void Start () {
		//Assign Katai instances from prefabs
//		kataiInstance = Instantiate (KataiPrefab);
		miniKatai = Instantiate (miniKataiPrefab);

		//Populate Katai's instance with Weapons

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		manageInput ();
	}


	//Receive input from four visual weapon buttons and do things.
	//Check if it can fire before sending signal to fire.
	public void inputMainArm(){
		Invoke ("MainArmInvoke", WeaponMainArm.hitDelay);
	}

	private void MainArmInvoke(){
//		if (ButtonMainArm != null) {
//			if (!ButtonMainArm.isTriggered ()) { //Appeals to CountdownTimer
//				ButtonMainArm.setTimer (WeaponMainArm.cooldown); //Sets Countdown Timer
//				//fireWeapon returns a list of how much damage each hit did.
//				foreach (float f in WeaponMainArm.fireWeapon()) { //BREAD AND BUTTER OCCURS HERE //////////
//					//TODO: create a floating text object with damage contained within it.
//					Debug.Log ("Main Arm Dealt: " + f + " Damage");
//
//					//Store each hit in a list that continually chops away every 0.1 second
//					enemyDamageReceiveList.Add (f);
//				}
//				Debug.Log ("");
//			}
//		}
	}

	public void inputSupportArm(){
		Invoke ("SupportArmInvoke", WeaponSupportArm.hitDelay);
	}

	public void inputShoulder(){
		Invoke ("ShoulderInvoke", WeaponShoulder.hitDelay);
	}

	public void inputBack(){
		Invoke ("BackInvoke", WeaponBack.hitDelay);
	}

	//Due to the nature of creating enemies and Katai at runtime,
	//it is necessary to hold functions for modifying dem fuckers here.
	public void setKataiHealth(float number){
		kataiInstance.setHealth (number);
	}
	public void reduceKataiHealth(float number){
		kataiInstance.reduceHealth (number);
	}
	public void setEnemyHealth(float number){
		enemyInstance.setHealth (number);
	}
	public void reduceEnemyHealth(float number){
		enemyInstance.reduceHealth (number);
	}

	private void createFloatingNumber(float num){
		HealthShardMod floatingText = Instantiate(EnemyHealthShardText);
		floatingText.transform.SetParent (EnemyHealthShardParent.transform);
		floatingText.transform.localScale = EnemyHealthShardText.transform.localScale;
		floatingText.transform.localPosition = EnemyHealthShardText.transform.localPosition;
		floatingText.transform.localRotation = EnemyHealthShardText.transform.localRotation;
		floatingText.setTextValueToShow (num);

		floatingText.gameObject.SetActive (true);
	}

	public void createNewEnemy(TestTankScript newEnemy){
//		This function should create a new enemy and keep it contained within EnemyObjects, as it should
//		default to doing.
		TestTankScript nextEnemy = Instantiate(newEnemy);
		//add enemy to list
		enemyList.Add(nextEnemy);
	}

	public void assignNewTarget(){
		//This function should assign the Game Controller's Enemy Prefab to newTarget.
		if (enemyInstance == null) {
			if (enemyList.Count > 0) {
				Debug.Log("assigning new target");
				enemyInstance = enemyList [0];
				enemyInstance.gameObject.SetActive (true);
				enemyList.RemoveAt (0);
			}else{
			//end fight
				Debug.Log("Fight Ends");
			}
		}
	}


	private void manageInput(){
		if(Input.GetKey("a")){
			//go left
			movementLeft();
		}
		if(Input.GetKey("w")){
			//go up
			movementUp();
		}
		if(Input.GetKey("d")){
			//go right
			movementRight();
		}
		if(Input.GetKey("s")){
			//go down
			movementDown();
		}

		if(Input.GetKey("j")){
			//use weapon j
		}
		if(Input.GetKey("i")){
			//use weapon i
		}
		if(Input.GetKey("l")){
			//use weapon l
		}
		if(Input.GetKey("k")){
			//use weapon k
		}
	}

	//BUTTON PRESSES FOR MOVEMENT
	public void setSpeedOverburn(){
		kataiInstance.setSpeedOverburn();
	}
	public void setSpeedFullburn(){
		kataiInstance.setSpeedFullburn ();
	}

	public void setSpeedHalfburn(){
		kataiInstance.setSpeedHalfburn();
	}

	public void movementRight(){
		miniKatai.gainRightVelocity (kataiInstance.moveSpeed);
	}
	public void movementLeft(){
		miniKatai.gainLeftVelocity (kataiInstance.moveSpeed);
	}
	public void movementUp(){
		miniKatai.gainRightVelocity (kataiInstance.moveSpeed*0.8f);
	}
	public void movementDown(){
		miniKatai.gainLeftVelocity (kataiInstance.moveSpeed*0.8f);
	}

}
