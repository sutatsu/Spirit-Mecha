using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthShardMod : MonoBehaviour {

	private float maxDamageValue = 600;

	// Use this for initialization
	void Start () {
//		setRandomRotationRange (-15f, 15f);
//		setTextValueToShow(1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void setRandomRotationRange(float minValue, float maxValue){
		Vector3 eulerVector = new Vector3 (this.transform.localRotation.eulerAngles.x,
			this.transform.localRotation.eulerAngles.y,
			this.transform.localRotation.eulerAngles.z + Random.Range (minValue, maxValue));
		//this.transform.localRotation.eulerAngles = eulerVector;
		this.transform.Rotate(eulerVector);
	}

	public void setTextValueToShow(float number)
	{
		gameObject.GetComponent<Text> ().text = ((int)number).ToString();
		setTextSizeByValue (number);
	}

	private void setTextSizeByValue(float number)
	{
		gameObject.transform.localScale = new Vector3(
			(0.8f/maxDamageValue*number+0.4f),
			(0.8f/maxDamageValue*number+0.4f)
		);
	}
}
