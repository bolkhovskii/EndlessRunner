using UnityEngine;
using System.Collections;

public class LevelDestroyer : MonoBehaviour {

    [SerializeField]
    private GameObject platformDestroyerPoint;


	// Use this for initialization
	void Start () {
        platformDestroyerPoint = GameObject.Find("LvlDestroyer");
	}
	
	// Update is called once per frame
	void Update () {
	if(transform.position.z < platformDestroyerPoint.transform.position.z)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
            //gameObject.SetActive(false);
        }
	}
}
