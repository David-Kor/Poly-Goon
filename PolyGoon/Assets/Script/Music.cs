using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour {

    public Slider backVolume;
    private AudioSource audio;
    private AudioSource mainAudioClip;
    private AudioSource hexagonAudioClip;
    private AudioSource pentagonAudioClip;
    private AudioSource circleAudioClip;

    
    private float backVol = 1f;

    private GameObject AllMusic;

	// Use this for initialization
	void Awake ()
    {
        AllMusic = gameObject.transform.GetChild(0).GetChild(9).gameObject;
        //Main Camera/Canvas/Music
        mainAudioClip = AllMusic.transform.GetChild(0).GetComponent<AudioSource>();
        hexagonAudioClip = AllMusic.transform.GetChild(1).GetComponent<AudioSource>();
        pentagonAudioClip = AllMusic.transform.GetChild(2).GetComponent<AudioSource>();
        circleAudioClip = AllMusic.transform.GetChild(3).GetComponent<AudioSource>();

        audio = mainAudioClip;      //시작 화면 오디오 재생
        hexagonAudioClip.Stop();    //헥사곤 게임에 사용될 오디오. 정지
        pentagonAudioClip.Stop();   //펜타곤 게임에 사용될 오디오. 정지
        circleAudioClip.Stop();     //원 게임에 사용될 오디오. 정지

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
    public void ControlMusic(int musicNumber)
    {
        switch (musicNumber)
        {
            case 0:
                audio.Stop();          //이전에 들어있던 AudioSource 정지
                audio = mainAudioClip;
                audio.Play();
                break;
            case 1:
                audio.Stop();          //이전에 들어있던 AudioSource 정지
                audio = hexagonAudioClip;
                audio.Play();
                break;
            case 2:
                audio.Stop();          //이전에 들어있던 AudioSource 정지
                audio = pentagonAudioClip;
                audio.Play();
                break;
            case 3:
                audio.Stop();          //이전에 들어있던 AudioSource 정지
                audio = circleAudioClip;
                audio.Play();
                break;
            default:
                audio.Stop();          //이전에 들어있던 AudioSource 정지
                audio = mainAudioClip;
                audio.Play();
                break;
        }
    }
}
