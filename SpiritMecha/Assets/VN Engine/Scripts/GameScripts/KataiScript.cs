using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KataiScript : MonoBehaviour {

	//Katai's guns
	private UnitClass Katai;
	//Katai's properties
	public float health;
	public float healthMax;
	public float damageThreshold; 
	public float damageResist;
	public float moveSpeed;
	public float weight;
	public float ammoStorage;
	public float energyGeneration;

	//weapons with which to do things
	public Weapon WeaponMainArm;
	public Weapon WeaponSupportArm;
	public Weapon WeaponShoulder;
	public Weapon WeaponBack;
	private List<Weapon> weaponsList;


	// Use this for initialization
	void Start () {

		weaponsList.Add (WeaponMainArm);
		weaponsList.Add (WeaponSupportArm);
		weaponsList.Add (WeaponShoulder);
		weaponsList.Add (WeaponBack);
	
		//Initalize the player, and then... maybe I should just use a prefab.
		Katai = new UnitClass (health, damageThreshold, damageResist, moveSpeed,
			weight, ammoStorage, energyGeneration, weaponsList);

	}
	
	// Update is called once per frame
	void Update () {
	
	}




}
