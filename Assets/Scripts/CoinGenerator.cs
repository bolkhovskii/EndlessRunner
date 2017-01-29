using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

    [SerializeField]
    public ObjectPool coinPool;
    [SerializeField]
    public ObjectPool coinPool2;

    [SerializeField]
    private float distanceBetweenCoins;

    public void SpawnCoins(Vector3 startPosition)
    {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObject();
        coin2.transform.position = new Vector3(Random.Range(startPosition.x - 1.5f,startPosition.x +1.5f), startPosition.y, startPosition.z - distanceBetweenCoins);
        coin2.SetActive(true);

        GameObject coin3 = coinPool2.GetPooledObject();
        coin2.transform.position = new Vector3(Random.Range(startPosition.x - 1.5f, startPosition.x + 1.5f), startPosition.y, startPosition.z - distanceBetweenCoins);
        coin3.SetActive(true);
    }
}
