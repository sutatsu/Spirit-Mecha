using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateTextToVariable : MonoBehaviour {

	//Variable for text to match
	public float variable = 0;
	private Text txt;

	// Use this for initialization
	void Start () {
		txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (variable >= 0.0f) {
			txt.text = ((int)variable).ToString ();
		} else {
			txt.text = "0";
		}
	}
}
