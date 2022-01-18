using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoClipPlayer : MonoBehaviour
{
    public VideoClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playClip(){
            universalPlayer.staticPlayer.clip = clip;
            universalPlayer.Play();
    }

    public void stopClip(){
        universalPlayer.Stop();
    }

    public void replayClip(){
        universalPlayer.Stop();
        playClip();
    }
}
