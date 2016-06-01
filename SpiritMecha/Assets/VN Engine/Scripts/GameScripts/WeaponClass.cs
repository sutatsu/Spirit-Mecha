using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Class contains variables but does nothing with them?
public class WeaponClass : MonoBehaviour {
	
//	private float damageResistance { get; set; }
//	private float health { get; set; }
//	private float minDamage { get; set; }
//	private float maxDamage { get; set; }
//	private float hits { get; set; }
//	private float accuracy { get; set; }
//	private float cooldown { get; set; }
//	private float weight { get; set; }
//	private float ammoCurrent { get; set; }
//	private float ammoCost { get; set; }
//	private float ammoMax { get; set; }
//	private float energyCost { get; set; }

	public float damageResistance;
	public float damageThreshold;
	public float health;
	public float minDamage;
	public float maxDamage;
	public float hits;
	public float accuracy;
	public float cooldown;
	public float weight;
	public float ammoCurrent;
	public float ammoMax;
	public float energyCost;
	public float hitDelay;

	public GameObject particleEffect;

	[TextArea(3,10)]
	public string weaponDescription;
	public string weaponName;

	private bool weaponCanFire = true;

	public GameObject artObject; //Prefab
	private GameObject artObjectInstance;

	private Animator animator;
	//private AudioSource audioSource;

	public AudioClip audioFire;


	// constructor that does not run.
	public WeaponClass(float damageResistance, float health, float minDamage,
		float maxDamage, float hits, float accuracy, float cooldown, float weight,
		float ammoMax, float ammoCurrent, float energyCost)
	{
		this.damageResistance = damageResistance; //weapon's resist to damage
		this.health = health; //weapon's health
		this.minDamage = minDamage; //weapon's min roll
		this.maxDamage = maxDamage; //weapon's max roll
		this.hits = hits; //weapon's attack number, each rolls damage
		this.accuracy = accuracy; //each hit's chance of hitting
		this.cooldown = cooldown; //time to give timer before weapon can fire again
		this.weight = weight; //how heavy the weapon is (kg)
		this.ammoMax = ammoMax; //weapon's max ammunition
		this.ammoCurrent = ammoCurrent; //weapon's current ammunition
		this.energyCost = energyCost; //how much energy the weapon costs to fire
	}


	void Start(){
		//audioSource = GetComponent<AudioSource> ();

		//Instantiances the Sprite and assigns itself as a child to this gameObject
		artObjectInstance = Instantiate (artObject);
		artObjectInstance.transform.parent = gameObject.transform;
//		artObjectInstance.transform.localPosition = artObject.transform.localPosition;

		//Gets the animator component of the instance (important!)
		animator = artObjectInstance.GetComponent<Animator> ();
		//Debug.Log(animator.ToString ());

	}


	//Call this function from button, with this class passed in to the gameController
	public List<float> fireWeapon(){
		//Delay weapon firing

		//Receive order from GameController (which maintains a target)
		//If weapon can fire, fire weapon
//		weaponCanFire = false;
		//Weapon Cooldown managed by button timer
	
		//Play animation and sound of weapon firing
		NewAudioManager.instance.RandomizeSfx(audioFire);
//		Debug.Log(animator.ToString ());
		animator.SetTrigger ("Fire");

		//Create particle object of weapon firing
		Instantiate(particleEffect, this.transform.position, this.transform.rotation);
	
		//Add rollHits into a list
		List<float> hitList = new List<float>();

		for (int i = 0; i < rollHits (); i++) {
			hitList.Add (rollDamage());
		}

		//Pass HitList to enemy
		return hitList;

		//Weapon fires 'hits' number of times, each shot doing 'damage'
	}

	private int rollHits(){
		//calculates number of hits using accuracy
		int madeHits = 0;
		for (int i = 0; i < hits; i++) {
			if ((Random.Range(1, 100))<= accuracy) {
				madeHits++;
			}
		}
		return madeHits;
	}

	//run this function for each madeHit
	private float rollDamage(){
		return Random.Range (minDamage, maxDamage);
	}

	private void reduceAmmo(){
		ammoCurrent--;
	}

	private void playShootAnim(){
	//play animation from animatorComponent within GameObject,
	
	}

	private void playBreakAnim(){
	}

	//Function unecessary
	public bool checkCanWeaponFire(){
		//returns true if weapon can fire, false if not
		return weaponCanFire;
	}
}

