using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitClass : MonoBehaviour {

	//Properties
//	private float health { get; set; }
//	private float damageThreshold { get; set; }
//	private float damageResist { get; set; }
//	private float moveSpeed { get; set; }
//	private float weight { get; set; }
//	private float ammoStorage { get; set; }
//	private float energyGeneration {get; set; }

	//Properties, Stats
	public float health;
	public float healthMax;

	public float moveSpeed;
	public float moveCost;
	public float weight;

	public float energy;
	public float energyMax;
	public float energyGen;

	//Reference to itself
	//public UnitClass itselfPrefab;
	//Reference to an instance of itself?
	//public UnitClass itselfInstance;

	//Reference to the sprite object and animator
	public GameObject artObject;
	public GameObject artObjectInstance;
	protected Animator animator;


	//

	//Does this ever have to be used?
	public UnitClass(float health, float damageThreshold, float damageResist, 
		float moveSpeed, float weight, float ammoStorage, float energyGeneration,
		List<WeaponClass> weapons)
	{
		this.health = health;
//		this.damageThreshold = damageThreshold;
//		this.damageResist = damageResist;
//		this.moveSpeed = moveSpeed;
//		this.weight = weight;
//		this.ammoStorage = ammoStorage;
//		this.energyGeneration = energyGeneration;
	}

	public UnitClass(){
		this.health = 105;
//		this.damageThreshold = 5;
//		this.damageResist = 10;
//		this.moveSpeed = 10;
//		this.weight = 100;
//		this.ammoStorage = 1;
//		this.energyGeneration = 1;
	}

	void Awake(){
//		WeaponMainArm = (WeaponClass)Instantiate(Resources.Load("BattlePrefabs/Arsenal/V0AutoRifle"));

		//itselfInstance = Instantiate (itselfPrefab);
//
//		if(WeaponMainArm != null)
//			weaponsList.Add (WeaponMainArm);
//		if(WeaponSupportArm != null)
//			weaponsList.Add (WeaponSupportArm);
//		if(WeaponShoulder != null)
//			weaponsList.Add (WeaponShoulder);
//		if(WeaponBack != null)
//			weaponsList.Add (WeaponBack);

		instantiateAwake ();

	}

	void Start(){
		//Instantiances the Sprite and assigns it as a child to this gameObject unit
		//		artObjectInstance.transform.localPosition = artObject.transform.localPosition;

		//Gets the animator component of the instance (important!)

	}

	void Update(){

	}

	//When altering health, health below or equal to 0 causes death.
	public void reduceHealth(float number){

		health = health - number;

		if (health <= 0) {
			death ();
		} else if (health > healthMax) {
			health = healthMax;
		}
	}

	public void setHealth(float number){
		health = number;
		if (health <= 0) {
			death ();
		} else if (health > healthMax) {
			health = healthMax;
		}
	}

	protected virtual void death(){
		//Unit has died, do something, like play an animation.
		Debug.Log("Unit has died");
		//remove from target list and play animation
	}

	//Receive bonuses to stats from weapons (health, damageResist, etc)
	private void updateStatsFromWeapons(){
	}

	public void getHit (){
		animator.SetTrigger ("Hit");
	}

	public void instantiateAwake()
	{
		//Instantiances the Sprite and assigns it as a child to this gameObject unit
		//		artObjectInstance.transform.localPosition = artObject.transform.localPosition;
		//WHY DOES THIS HAVE TO BE IN AWAKE?!
		artObjectInstance = Instantiate (artObject);
		artObjectInstance.transform.parent = gameObject.transform;
		//Set artObjectInstance to its old scale
		artObjectInstance.transform.localScale = artObject.transform.localScale;
		animator = artObjectInstance.GetComponent<Animator> ();

	}
}
