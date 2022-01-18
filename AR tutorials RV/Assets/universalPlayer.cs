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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Stop(){
        staticPlayer.Stop();
        staticPlayer.GetComponent<RawImage>().enabled = false;
    }

    public static void Play(){
        staticPlayer.Play();
        staticPlayer.GetComponent<RawImage>().enabled = true;
    }
}
