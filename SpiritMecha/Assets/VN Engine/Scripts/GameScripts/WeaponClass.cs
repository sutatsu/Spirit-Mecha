using UnityEngine;
using System.Collections;

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

	[TextArea(3,10)]
	public string weaponDescription;

	private bool weaponCanFire = true;

	// constructor
	public WeaponClass(float damageResistance, float health, float minDamage,
		float maxDamage, float hits, float accuracy, float cooldown, float weight,
		float ammoMax, float ammoCost, float energyCost)
	{
		this.damageResistance = damageResistance;
		this.health = health;
		this.minDamage = minDamage;
		this.maxDamage = maxDamage;
		this.hits = hits;
		this.accuracy = accuracy;
		this.cooldown = cooldown;
		this.weight = weight;
		this.ammoMax = ammoMax;
		this.ammoCurrent = ammoMax;
		this.energyCost = energyCost;
	}

	public void fireWeapon(){
		//If weapon can fire, fire weapon.


		//Weapon fires 'hits' number of times, each shot doing 'damage'
	}

	public bool checkCanWeaponFire(){
		//returns true if weapon can fire, false if not
		return weaponCanFire;
	}
}

