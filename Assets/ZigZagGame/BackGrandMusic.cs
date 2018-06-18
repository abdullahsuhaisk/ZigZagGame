using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrandMusic : MonoBehaviour
{

    static BackGrandMusic instance;
    // Use this for initialization
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(instance);
    }
}

