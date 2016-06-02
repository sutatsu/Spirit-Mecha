using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KataiScript : UnitClass {

	public WeaponManager weaponManager;

	//weapons with which to do things
	public WeaponClass WeaponMainArmPrefab;
	public WeaponClass WeaponSupportArmPrefab;
	public WeaponClass WeaponShoulderPrefab;
	public WeaponClass WeaponBackPrefab;

	public bool LINEBREAK0;

	public ThrusterClass ThrusterPrefab;
	public ThrusterClass thrusters;

	protected WeaponClass WeaponMainArm;
	protected WeaponClass WeaponSupportArm;
	protected WeaponClass WeaponShoulder;
	protected WeaponClass WeaponBack;


//	public float SpeedWildburn;
//	public float SpeedOverburn;
//	public float SpeedFullburn;
//	public float SpeedHalfburn;
//	public float SpeedCrawlingburn;

	void Awake(){

		instantiateAwake ();

		weaponManager = GameObject.Find ("WeaponManagerContainer").GetComponent<WeaponManager>();
		WeaponMainArmPrefab = weaponManager.MainArmSetter;
		WeaponSupportArmPrefab = weaponManager.SupportArmSetter;
		WeaponShoulderPrefab = weaponManager.ShoulderSetter;
		WeaponBackPrefab = weaponManager.BackSetter;


		//instantiate weapons
		if (WeaponMainArmPrefab != null)
			WeaponMainArm = Instantiate (WeaponMainArmPrefab);
		if (WeaponSupportArmPrefab != null)
			WeaponSupportArm = Instantiate (WeaponSupportArmPrefab);
		if (WeaponShoulderPrefab != null)
			WeaponShoulder = Instantiate (WeaponShoulderPrefab);
		if (WeaponBackPrefab != null)
			WeaponBack = Instantiate (WeaponBackPrefab);
	

	}

	// Use this for initialization
	void Start () {

		//Assign as parent to AllyObjects transform
		gameObject.transform.parent = GameObject.Find("AllyObjects").transform;
		gameObject.transform.localPosition = new Vector3(0,0,20);

		//Add weapons as children
		WeaponMainArm.transform.parent = gameObject.transform;
		WeaponMainArm.transform.localPosition = WeaponMainArmPrefab.transform.localPosition;

		WeaponSupportArm.transform.parent = gameObject.transform;
		WeaponSupportArm.transform.localPosition = WeaponSupportArmPrefab.transform.localPosition;

		WeaponShoulder.transform.parent = gameObject.transform;
		WeaponShoulder.transform.localPosition = WeaponShoulderPrefab.transform.localPosition;

		WeaponBack.transform.parent = gameObject.transform;
		WeaponBack.transform.localPosition = WeaponBackPrefab.transform.localPosition;

		//Only Katai should maintain their 4 weapons sprites holder thing

		//get movement speeds from thrusters
		thrusters = Instantiate(ThrusterPrefab);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//returns GameObject for WeaponMainArm
	public WeaponClass getMainArm(){
		return WeaponMainArm;
	}
	public WeaponClass getSupportArm(){
		return WeaponSupportArm;
	}
	public WeaponClass getShoulder(){
		return WeaponShoulder;
	}
	public WeaponClass getBack(){
		return WeaponBack;
	}

	public void setSpeedOverburn(){
		moveSpeed = 1.5f*thrusters.moveSpeed;
		moveCost = 2f * thrusters.energyCost;
	}
	public void setSpeedFullburn(){
		moveSpeed = thrusters.moveSpeed;
		moveCost = thrusters.energyCost;
	}
	public void setSpeedHalfburn(){
		moveSpeed = 0.75f*thrusters.moveSpeed;
		moveCost = 0.5f * thrusters.energyCost;
	}

}
