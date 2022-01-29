using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SubtitlesManager : MonoBehaviour
{
    public VideoPlayer player{
        get => GetComponent<VideoPlayer>();
    }

    public static VideoPlayer staticPlayer;
    public GameObject easySubtitles;

    // Start is called before the first frame update
    void Start()
    {
        staticPlayer = player;   
    }

    // Update is called once per frame
    void Update()
    {
        if(staticPlayer.GetComponent<RawImage>().enabled){
            if(staticPlayer.clip.name == "Step1"){
                easySubtitles.SetActive(true);
                Debug.Log("Easy ligado");
            }
        }
        else{
            easySubtitles.SetActive(false);
        }
    }
}
