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

	public CountdownTimer ButtonMainArm;
	public CountdownTimer ButtonSupportArm;
	public CountdownTimer ButtonShoulder;
	public CountdownTimer ButtonBack;

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

	public float damageListTimer = 0.1f;

	private WeaponClass WeaponMainArm;
	private WeaponClass WeaponSupportArm;
	private WeaponClass WeaponShoulder;
	private WeaponClass WeaponBack;

	public MiniKataiScript miniKataiPrefab;
	public MiniKataiScript miniKatai;
//	private List<MiniEnemyScript> miniEnemyList;

	public bool LINEBREAK4;


	//Lists that hold all damage received in individual units, and carry out the damage of each individual
	//strike every 0.1 seconds (potentially in the future with a scaling number, faster if there's too many
	private List<float> playerDamageReceiveList;
	private List<float> enemyDamageReceiveList;
	private bool damageListsInvoked = false;

	public List<TestTankScript> enemiesToSpawnList;

	private bool fightWon = false;


	//Use this for initialization
	//Because it's all in Start I can start with the GameController OFF!!! YAY!~
	void Start () {
		//Assign Katai and Enemies instances from prefabs
		kataiInstance = Instantiate (KataiPrefab);
		//enemyInstance = Instantiate (EnemyPrefab);
		miniKatai = Instantiate (miniKataiPrefab);


		//Populate Katai's instance with Weapons
		WeaponMainArm = kataiInstance.getMainArm ();
		WeaponSupportArm = kataiInstance.getSupportArm ();
		WeaponShoulder = kataiInstance.getShoulder ();
		WeaponBack = kataiInstance.getBack ();


		//create new damage receive lists for managing iterative damage
		playerDamageReceiveList = new List<float>();
		enemyDamageReceiveList = new List<float>();

		//Check what level the player is on and then load that shit
		//We can Ressources Load but what's the point? Just load from prefabs already in the level?
		//Not very scalable. Is loading a Unity Level smarter? Probably. Therefore GameController
		//should maintain a list of all the enemies it needs to spawn.
		enemiesToSpawnList = new List<TestTankScript>();

		//should also maintain a list of all miniEnemies and miniKatai?

	}
	
	// Update is called once per frame
	void Update () {
		//while there is no enemy, bring in the next one
		if (enemyInstance == null) {
			assignNewTarget ();
		}
	
		//constantly update EnemyHealthBar to reflect Enemy.health
		if (enemyInstance != null) {
			EnemyHealthBar.SetFloat ("Blend", (enemyInstance.health / enemyInstance.healthMax));
			enemyTextToUpdate.variable = enemyInstance.health;
		}

		//handle damage receive lists every 0.1 seconds
		if (!damageListsInvoked) {
			damageListsInvoked = true;
			Invoke ("handleDamageLists", damageListTimer);
		}
	}


	//Receive input from four visual weapon buttons and do things.
	//Check if it can fire before sending signal to fire.
	public void inputMainArm(){
		Invoke ("MainArmInvoke", WeaponMainArm.hitDelay);
	}

	private void MainArmInvoke(){
		if (ButtonMainArm != null) {
			if (!ButtonMainArm.isTriggered ()) { //Appeals to CountdownTimer
				ButtonMainArm.setTimer (WeaponMainArm.cooldown); //Sets Countdown Timer
				//fireWeapon returns a list of how much damage each hit did.
				foreach (float f in WeaponMainArm.fireWeapon()) { //BREAD AND BUTTER OCCURS HERE //////////
					//TODO: create a floating text object with damage contained within it.
					Debug.Log ("Main Arm Dealt: " + f + " Damage");

					//Store each hit in a list that continually chops away every 0.1 second
					enemyDamageReceiveList.Add (f);
				}
				Debug.Log ("");
			}
		}
	}

	public void inputSupportArm(){
		Invoke ("SupportArmInvoke", WeaponSupportArm.hitDelay);
	}

	private void SupportArmInvoke(){
		if (ButtonSupportArm != null) {
			if (!ButtonSupportArm.isTriggered ()) { //Appeals to CountdownTimer
				ButtonSupportArm.setTimer (WeaponSupportArm.cooldown); //Sets Countdown Timer
				//fireWeapon returns a list of how much damage each hit did.
				foreach (float f in WeaponSupportArm.fireWeapon()) { //BREAD AND BUTTER OCCURS HERE //////////
					//TODO: create a floating text object with damage contained within it.
					Debug.Log ("Support Arm Dealt: " + f + " Damage");

					//Store each hit in a list that continually chops away every 0.1 second
					enemyDamageReceiveList.Add (f);
				}
				Debug.Log ("");
			}
		}
	}

	public void inputShoulder(){
		Invoke ("ShoulderInvoke", WeaponShoulder.hitDelay);
	}

	private void ShoulderInvoke(){
		if (ButtonShoulder != null) {
			if (!ButtonShoulder.isTriggered ()) { //Appeals to CountdownTimer
				ButtonShoulder.setTimer (WeaponShoulder.cooldown); //Sets Countdown Timer
				//fireWeapon returns a list of how much damage each hit did.
				foreach (float f in WeaponShoulder.fireWeapon()) { //BREAD AND BUTTER OCCURS HERE //////////
					//TODO: create a floating text object with damage contained within it.
					Debug.Log ("Shoulder Dealt: " + f + " Damage");

					//Store each hit in a list that continually chops away every 0.1 second
					enemyDamageReceiveList.Add (f);
				}
				Debug.Log ("");
			}
		}
	}

	public void inputBack(){
		Invoke ("BackInvoke", WeaponBack.hitDelay);
	}

	private void BackInvoke(){
		if (ButtonBack != null) {
			if (!ButtonBack.isTriggered ()) { //Appeals to CountdownTimer
				ButtonBack.setTimer (WeaponBack.cooldown); //Sets Countdown Timer
				//fireWeapon returns a list of how much damage each hit did.
				foreach (float f in WeaponBack.fireWeapon()) { //BREAD AND BUTTER OCCURS HERE //////////
					//TODO: create a floating text object with damage contained within it.
					Debug.Log ("Back Dealt: " + f + " Damage");

					//Store each hit in a list that continually chops away every 0.1 second
					enemyDamageReceiveList.Add (f);
				}
				Debug.Log ("");
			}
		}
	}

	//Here is where the damage list for the enmy is handled, if we replace the enemyInstance
	//we can create a line of enemies.
	private void handleDamageLists(){
		if(enemyDamageReceiveList.Count > 0 && enemyInstance != null){
			//Cause floating number over enemy
			createFloatingNumber(enemyDamageReceiveList[0]);
			enemyInstance.reduceHealth(enemyDamageReceiveList[0]);
			enemyDamageReceiveList.RemoveAt (0);
			//Cause enemy to flash
			enemyInstance.getHit();
		}
		damageListsInvoked = false;
	}

//	IEnumerator handleDamageLists(List<float> goodDamageList, List<float> badDamageList){
//		float 
//	}

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

}
