using UnityEngine;
using System.Collections;

public class MatchKataiSpriteTransform : MonoBehaviour {

	//The Katai Sprite GameObject this weapon's Transform will be matched to.
	public GameObject kataiSprite;

	// Use this for initialization
	void Start () {
		kataiSprite = GameObject.Find ("SpriteKatai(Clone)");
	}
	
	// Update is called once per frame
	void Update () {
	
		//if(kataiSprite != null)
		Vector3 temp = kataiSprite.transform.localPosition;
		temp.z -= 1;
		gameObject.transform.localPosition = temp;
//		Debug.Log (gameObject.transform.localPosition.y.ToString ());

	}
}
