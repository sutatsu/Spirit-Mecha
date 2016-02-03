using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitClass {

	//Properties
	private float health { get; set; }
	private float damageThreshold { get; set; }
	private float damageResist { get; set; }
	private float moveSpeed { get; set; }
	private float weight { get; set; }
	private float ammoStorage { get; set; }
	private float energyGeneration {get; set; }

	private List<Weapon> weaponsList;

	public UnitClass(float health, float damageThreshold, float damageResist, 
		float moveSpeed, float weight, float ammoStorage, float energyGeneration,
		List<Weapon> weapons)
	{
		this.health = health;
		this.damageThreshold = damageThreshold;
		this.damageResist = damageResist;
		this.moveSpeed = moveSpeed;
		this.weight = weight;
		this.ammoStorage = ammoStorage;
		this.energyGeneration = energyGeneration;

		this.weaponsList = weapons;
	}

	public UnitClass(){
		this.health = 100;
		this.damageThreshold = 5;
		this.damageResist = 10;
		this.moveSpeed = 10;
		this.weight = 100;
		this.ammoStorage = 1;
		this.energyGeneration = 1;
	}


	//When altering health, health below or equal to 0 causes death.
	void changeHealth(float number){

		health = health - number;

		if (health <= 0) {
			death ();
		}
	}

	void death(){
		//Unit has died, do something, like play an animation.
	}

	//Receive bonuses to stats from weapons (health, damageResist, etc)
	void updateFromWeapons(){



	}
}
