using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class universalArrow : MonoBehaviour
{

    public GameObject arrow{
        get => GetComponent<GameObject>();
    }

    public static GameObject staticArrow;

    
    // Start is called before the first frame update
    void Start()
    {
        staticArrow = arrow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Active(){
        staticArrow.SetActive(true);
    }

    public static void Inactive(){
        staticArrow.SetActive(false);
    }
}
