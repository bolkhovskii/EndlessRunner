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

    [SerializeField]
    private CoinGenerator theCoinGenerator;

    private int platformSelector;

    [SerializeField]
    private float[] platformWidths;
    [SerializeField]
    private ObjectPool[] theObjectPool;

    void Start () {
        platformWidths = new float[theObjectPool.Length];
        for(int i = 0; i < theObjectPool.Length; i++)
        {
            platformWidths[i] = theObjectPool[i].pooledObject.GetComponentInChildren<BoxCollider>().size.z +1f;
        }
	}
	
	void Update () {
	if(transform.position.z < generationPoint.position.z)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, theObjectPool.Length);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (platformWidths[platformSelector] / 2) + distanceBetween);
            GameObject newPlatform = theObjectPool[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z));
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (platformWidths[platformSelector] / 2));

        }
    }
}