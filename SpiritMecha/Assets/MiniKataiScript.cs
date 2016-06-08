using UnityEngine;
using System.Collections;

public class MiniKataiScript : MinyUnityScript {

	//object to parent to
//	GameObject parent = null;

	public WeaponManager weaponManager;

	//weapons with which to do things
	public bool WEAPONS;
	public WeaponClass WeaponAPrefab;
	public WeaponClass WeaponWPrefab;
	public WeaponClass WeaponDPrefab;
	public WeaponClass WeaponSPrefab;

	public bool MODULES;
	public ThrusterClass ThrusterPrefab;

	protected WeaponClass WeaponA;
	protected WeaponClass WeaponW;
	protected WeaponClass WeaponD;
	protected WeaponClass WeaponS;

	protected ThrusterClass thrusters;

	void Awake(){

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
		this.transform.SetParent(GameObject.Find ("Battlefield").transform);

		//get movement speeds from thrusters
		thrusters = Instantiate(ThrusterPrefab);

		WeaponA.transform.parent = gameObject.transform;
		WeaponA.transform.localPosition = WeaponAPrefab.transform.localPosition;

		WeaponW.transform.parent = gameObject.transform;
		WeaponW.transform.localPosition = WeaponWPrefab.transform.localPosition;

		WeaponD.transform.parent = gameObject.transform;
		WeaponD.transform.localPosition = WeaponDPrefab.transform.localPosition;

		WeaponS.transform.parent = gameObject.transform;
		WeaponS.transform.localPosition = WeaponSPrefab.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
//		manageInput ();
	}



}
