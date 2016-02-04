using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestTankScript : MonoBehaviour {

	//Katai's guns
	private UnitClass TestTank;
	//Katai's properties
	public float health;
	public float damageThreshold; 
	public float damageResist;
	public float moveSpeed;
	public float weight;
	public float ammoStorage;
	public float energyGeneration;

	//weapons with which to do things
	public WeaponClass WeaponMainArm;
	public WeaponClass WeaponSupportArm;
	private List<WeaponClass> weaponsList;

	// Use this for initialization
	void Start () {

		//Initalize the player, and then... maybe I should just use a prefab.
		TestTank = new UnitClass (health, damageThreshold, damageResist, moveSpeed,
			weight, ammoStorage, energyGeneration, weaponsList);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
