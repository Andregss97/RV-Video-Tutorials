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
    public GameObject mediumSubtitles;
    public GameObject hardSubtitles;
    // Start is called before the first frame update
    void Start()
    {
        staticPlayer = player;   
    }

    // Update is called once per frame
    void Update()
    {
        if(staticPlayer.GetComponent<RawImage>().enabled){
            if(staticPlayer.clip.name == "easy"){
            mediumSubtitles.SetActive(false);
            hardSubtitles.SetActive(false);
            easySubtitles.SetActive(true);
            Debug.Log("Easy ligado");
            }
            else if(staticPlayer.clip.name == "medium"){
                easySubtitles.SetActive(false);
                hardSubtitles.SetActive(false);
                mediumSubtitles.SetActive(true);
                Debug.Log("Medium ligado");
            }
            else if(staticPlayer.clip.name == "Hard"){
                easySubtitles.SetActive(false);
                mediumSubtitles.SetActive(false);
                hardSubtitles.SetActive(true);
                Debug.Log("Hard ligado");
            }
        }
        else{
            easySubtitles.SetActive(false);
            mediumSubtitles.SetActive(false);
            hardSubtitles.SetActive(false);
            Debug.Log("Nenhum ligado");
        }
    }
}
