using UnityEngine;
using System.Collections;

public class RemoveAfterTime : MonoBehaviour {

	public float lifetime = 4.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Destroy(gameObject, lifetime);
	
	}
}
