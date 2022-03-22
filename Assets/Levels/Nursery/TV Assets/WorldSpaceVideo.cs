using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class WorldSpaceVideo : MonoBehaviour
{


    public VideoClip[] videoClips;

    //public PlayHeadMover playHeadMover;
    private VideoPlayer videoPlayer;
    private int videoClipIndex;

    void Awake()
    {

        StartCoroutine("NextClip");
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Use this for initialization
    void Start()
    {
        //videoPlayer.targetTexture.Release();
        videoPlayer.clip = videoClips[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            //SetNextClip();
            //playHeadMover.MovePlayhead(CalculatePlayedFraction());
        }
    }
    private IEnumerator NextClip()
    {
        float pauseEndTime = Time.realtimeSinceStartup + 7f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        SetNextClip();
    }
    public void SetNextClip()
    {
        videoClipIndex++;

        if (videoClipIndex >= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }

        videoPlayer.clip = videoClips[videoClipIndex];
        videoPlayer.Play();

        StartCoroutine("NextClip");

    }

    
    double CalculatePlayedFraction()
    {
        double fraction = (double)videoPlayer.frame / (double)videoPlayer.clip.frameCount;
        return fraction;
    }
}