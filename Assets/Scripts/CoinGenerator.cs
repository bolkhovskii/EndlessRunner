using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

    [SerializeField]
    public ObjectPool coinPool;

    [SerializeField]
    private float distanceBetweenCoins;

    public void SpawnCoins(Vector3 startPosition)
    {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObject();
        coin2.transform.position = new Vector3(Random.Range(startPosition.x - 3f,startPosition.x + 3f), startPosition.y, startPosition.z - distanceBetweenCoins);
        coin2.SetActive(true);

    }
}
