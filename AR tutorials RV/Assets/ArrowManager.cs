using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public static HashSet<object> requesters = new HashSet<object>();

    public GameObject ArrowObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(requesters.Count > 0){
            //Debug.Log("Show");
            ArrowObject.SetActive(true);
        }
        else{
            //Debug.Log("Hide");
            ArrowObject.SetActive(false);
        }
    }

    public static void RequestShowArrows(object obj){
        requesters.Add(obj);
    }

    public static void RequestHideArrows(object obj){
        requesters.Remove(obj);

    }
}
