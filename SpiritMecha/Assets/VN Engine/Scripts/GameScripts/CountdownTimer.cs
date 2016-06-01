using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	private float timer = 0f;
	private Animator anim;
	private Text number;
	private bool triggered = false;

	private Animator barFillAnim;
	private float barFillSpeed; //multiples of 1, if want 15 sec do 1/15


	void Start(){

		//Get reference to animator component
		anim = GetComponent<Animator>();
		number = GetComponent<Text> ();

		//Get components in children searches base as well
		barFillAnim = GetComponentsInChildren<Animator>()[1];
	}

	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		number.text = Mathf.Round(timer).ToString();

		//If there is no time on the timer
		if (timer <= 0) {
			timer = 0;
			//trigger animation to fade?
			anim.ResetTrigger("Appear");
			anim.SetTrigger("Hide");

			barFillAnim.ResetTrigger ("StartCooldown");

			//set triggered to allow changes now that it is complete
			triggered = false;
		}
		//if there is time on the timer
		else {
			//trigger animation to appear
			anim.ResetTrigger("Hide");
			anim.SetTrigger("Appear");

			//trigger bar to appear
			barFillAnim.SetTrigger("StartCooldown");
			barFillAnim.SetFloat ("barFillSpeed", barFillSpeed);

			//set triggered to prevent changes until complete
			triggered = true;
		}
	
	}

	public void setTimer(float time){
		if (!triggered) {
			timer = time;
			barFillSpeed = 1f / time;
		}
	}

	public bool isTriggered(){
		return triggered;
	}
}
