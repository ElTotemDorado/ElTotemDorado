using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float m = PlayerPrefs.GetFloat("volume");
        GetComponent<AudioSource>().volume = m;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
