using UnityEngine;
using System.Collections;

public class UnitClass {

	//Properties
	private float health { get; set; }
	private float damageResist { get; set; }
	private float moveSpeed { get; set; }
	private float weight { get; set; }
	private float ammoStorage { get; set; }
	private float energyGeneration {get; set; }

	public UnitClass(float health, float damageResist, float moveSpeed,
		float weight, float ammoStorage, float energyGeneration)
	{
		this.health = health;
		this.damageResist = damageResist;
		this.moveSpeed = moveSpeed;
		this.weight = weight;
		this.ammoStorage = ammoStorage;
		this.energyGeneration = energyGeneration;
	}

	public UnitClass(){
		this.health = 100;
		this.damageResist = 10;
		this.moveSpeed = 10;
		this.weight = 100;
		this.ammoStorage = 1;
		this.energyGeneration = 1;
	}
}
