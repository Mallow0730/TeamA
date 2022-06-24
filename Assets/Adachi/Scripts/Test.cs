using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void DontActive()
    {
        gameObject.SetActive(false);
    }
}
