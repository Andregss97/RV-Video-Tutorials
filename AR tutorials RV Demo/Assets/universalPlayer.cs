using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class universalPlayer : MonoBehaviour
{
    public VideoPlayer player{
        get => GetComponent<VideoPlayer>();
    }

    public static VideoPlayer staticPlayer;
    // Start is called before the first frame update
    void Start()
    {
        staticPlayer = player;
        staticPlayer.GetComponent<RawImage>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Stop(){
        staticPlayer.Stop();
        staticPlayer.GetComponent<RawImage>().enabled = false;
        staticPlayer.clip = null;
    }

    public static void Play(){
        staticPlayer.GetComponent<RawImage>().enabled = true;
        staticPlayer.Play();
    }
}
