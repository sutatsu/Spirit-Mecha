using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	
	private float damageResistance { get; set; }
	private float health { get; set; }
	private float damage { get; set; }
	private float hits { get; set; }
	private float accuracy { get; set; }
	private float cooldown { get; set; }
	private float weight { get; set; }
	private float ammoCurrent { get; set; }
	private float ammoCost { get; set; }
	private float ammoMax { get; set; }
	private float energyCost { get; set; }

	// constructor
	public Weapon(float damageResistance, float health, float damage,
		float hits, float accuracy, float cooldown, float weight,
		float ammoMax, float ammoCost, float energyCost)
	{
		this.damageResistance = damageResistance;
		this.health = health;
		this.damage = damage;
		this.hits = hits;
		this.accuracy = accuracy;
		this.cooldown = cooldown;
		this.weight = weight;
		this.ammoMax = ammoMax;
		this.ammoCurrent = ammoMax;
		this.energyCost = energyCost;
	}
}

