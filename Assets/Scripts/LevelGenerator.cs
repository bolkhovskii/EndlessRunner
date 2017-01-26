using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private Transform generationPoint;
    [SerializeField]
    private float platformWidth;
    [SerializeField]
    private float distanceBetween=3f;

    [SerializeField]
    private float distanceBetweenMax = 5f;
    [SerializeField]
    private float distanceBetweenMin = 8f;

    //[SerializeField]
    //private GameObject[] thePlatforms;
    private int platformSelector;

    [SerializeField]
    private float[] platformWidths;
    [SerializeField]
    private ObjectPool[] theObjectPool;
    // Use this for initialization
    void Start () {
        //platformWidth = platform.GetComponentInChildren<BoxCollider>().size.z + 10f;

        platformWidths = new float[theObjectPool.Length];
        for(int i = 0; i < theObjectPool.Length; i++)
        {
            platformWidths[i] = theObjectPool[i].pooledObject.GetComponentInChildren<BoxCollider>().size.z +1f;
        }
	}
	
	// Update is called once per frame
	void Update () {
	if(transform.position.z < generationPoint.position.z)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, theObjectPool.Length);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (platformWidths[platformSelector] / 2) + distanceBetween);

           


            //Instantiate(/*platform*/ theObjectPool[platformSelector],transform.position, transform.rotation);
            GameObject newPlatform = theObjectPool[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
	}
}
