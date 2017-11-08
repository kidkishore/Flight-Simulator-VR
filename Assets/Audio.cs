using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {



    public AudioClip birdNoise;
    public AudioSource birdSource;

    // Use this for initialization
    void Start () {

        birdSource.clip = birdNoise;
        birdSource.Play();

    }
	
	// Update is called once per frame
	void Update () {
        
        
		
	}
}
