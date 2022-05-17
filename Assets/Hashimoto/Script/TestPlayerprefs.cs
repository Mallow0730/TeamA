using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerprefs : MonoBehaviour
{
    
    void Start()
    {
        var a = PlayerPrefs.GetInt("COINSCORE", 0);
        var b = PlayerPrefs.GetInt("EXPSCORE", 0);
        Debug.Log(a);
        Debug.Log(b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
