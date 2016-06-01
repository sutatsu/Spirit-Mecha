using UnityEngine;
using System.Collections;

public class NewAudioManager : MonoBehaviour {

	public AudioSource efxSource;
	public AudioSource musicSource;
	public static NewAudioManager instance = null; //Allows other scripts to call functions frmo NewAudioManagar.
	public float lowPitchRange = .9f;
	public float highPitchRange = 1.1f;

	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySingle(AudioClip clip){
		efxSource.clip = clip;

		efxSource.Play ();
	}

	public void RandomizeSfx(params AudioClip[] clips)
	{
		int randomIndex = Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);
		efxSource.pitch = randomPitch;
		efxSource.clip = clips [randomIndex];
		efxSource.Play ();
	}
}
