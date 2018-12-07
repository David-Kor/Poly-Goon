using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour {

    public Slider backVolume;
    public AudioSource audio;

    private float backVol = 1f;

	// Use this for initialization
	void Start ()
    {
        backVol = PlayerPrefs.GetFloat("BackVol", 1f);
        backVolume.value = backVol;
        audio.volume = backVolume.value;
    }
	
	// Update is called once per frame
	void Update () {
        SoundSlider();
    }

    public void SoundSlider()
    {
        backVol = backVolume.value;
        audio.volume = backVol;
        PlayerPrefs.SetFloat("BackVol", backVol);
    }
}
