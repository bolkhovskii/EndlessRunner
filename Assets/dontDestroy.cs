using UnityEngine;
using System.Collections;

public class dontDestroy : MonoBehaviour {
     private static dontDestroy instance = null;

    // Game Instance Singleton
    public static dontDestroy Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Use this for initialization
}
