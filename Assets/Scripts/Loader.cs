using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    public GameObject gameManager;

	// Use this for initialization
	void Awake () {
       
        if (GameManager.instance == null)
            Instantiate(gameManager);
       
    }

    void Start() {
        // проверка
        GameManager.instance.AdjustScore(-1000);
        //
    }

    // Update is called once per frame
    void Update () {
	
	}
}
