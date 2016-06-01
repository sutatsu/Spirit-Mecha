using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestTankScript : UnitClass {
	
	// Use this for initialization
	void Start () {
		//Assign as parent to EnemyObjects transform
		gameObject.transform.parent = GameObject.Find("EnemyObjects").transform;
		gameObject.transform.localPosition = new Vector3(0,0,20);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void death(){
		//Unit has died, do something, like play an animation.
		Debug.Log("Unit has died");
		//play animation
		animator.SetTrigger("Death");
		//remove from target list
		Invoke("setInactiveDelay", 1.0f);
	}

	private void setInactiveDelay(){
		gameObject.SetActive (false);
		Destroy (this);
	}
}
