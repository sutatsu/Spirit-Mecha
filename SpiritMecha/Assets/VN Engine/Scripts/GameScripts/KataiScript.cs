using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KataiScript : UnitClass {

	public WeaponManager weaponManager;

	//weapons with which to do things
	public WeaponClass WeaponAPrefab;
	public WeaponClass WeaponWPrefab;
	public WeaponClass WeaponDPrefab;
	public WeaponClass WeaponSPrefab;

	public bool LINEBREAK0;

	public ThrusterClass ThrusterPrefab;
	public ThrusterClass thrusters;

	protected WeaponClass WeaponA;
	protected WeaponClass WeaponW;
	protected WeaponClass WeaponD;
	protected WeaponClass WeaponS;


//	public float SpeedWildburn;
//	public float SpeedOverburn;
//	public float SpeedFullburn;
//	public float SpeedHalfburn;
//	public float SpeedCrawlingburn;

	void Awake(){

		instantiateAwake ();

		weaponManager = GameObject.Find ("WeaponManagerContainer").GetComponent<WeaponManager>();
		WeaponAPrefab = weaponManager.ASetter;
		WeaponWPrefab = weaponManager.WSetter;
		WeaponDPrefab = weaponManager.DSetter;
		WeaponSPrefab = weaponManager.SSetter;


		//instantiate weapons
		if (WeaponAPrefab != null)
			WeaponA = Instantiate (WeaponAPrefab);
		if (WeaponWPrefab != null)
			WeaponW = Instantiate (WeaponWPrefab);
		if (WeaponDPrefab != null)
			WeaponD = Instantiate (WeaponDPrefab);
		if (WeaponSPrefab != null)
			WeaponS = Instantiate (WeaponSPrefab);
	

	}

	// Use this for initialization
	void Start () {

		//Assign as parent to AllyObjects transform
		gameObject.transform.parent = GameObject.Find("AllyObjects").transform;
		gameObject.transform.localPosition = new Vector3(0,0,20);

		//Add weapons as children
		WeaponA.transform.parent = gameObject.transform;
		WeaponA.transform.localPosition = WeaponAPrefab.transform.localPosition;

		WeaponW.transform.parent = gameObject.transform;
		WeaponW.transform.localPosition = WeaponWPrefab.transform.localPosition;

		WeaponD.transform.parent = gameObject.transform;
		WeaponD.transform.localPosition = WeaponDPrefab.transform.localPosition;

		WeaponS.transform.parent = gameObject.transform;
		WeaponS.transform.localPosition = WeaponSPrefab.transform.localPosition;

		//Only Katai should maintain their 4 weapons sprites holder thing

		//get movement speeds from thrusters
		thrusters = Instantiate(ThrusterPrefab);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//returns GameObject for WeaponA
	public WeaponClass getA(){
		return WeaponA;
	}
	public WeaponClass getW(){
		return WeaponW;
	}
	public WeaponClass getD(){
		return WeaponD;
	}
	public WeaponClass getS(){
		return WeaponS;
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
