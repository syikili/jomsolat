using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class test1 : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject camera = GameObject.Find("Main Camera");
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.targetCameraAlpha = 0.5F;
        videoPlayer.url = "/Media/w.mp4";

        videoPlayer.isLooping = false;
        videoPlayer.Play();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
