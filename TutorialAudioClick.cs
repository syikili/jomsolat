using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class TutorialAudioClick : MonoBehaviour {

    public AudioClip sound;

    private Button buttonSound { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }


    // Use this for initialization
    void Start () {

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = true;

        buttonSound.onClick.AddListener(() => PlaySound());
		
	}

    void PlaySound()
    {
        source.PlayOneShot(sound);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
