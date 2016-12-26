using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public GameObject[] levelPrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float roadLength = 7.66f;
    private int lengthOnScreen = 10;
    private int levelIndex = 0;
    // Use this for initialization
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < lengthOnScreen; i++)
        {
            SpawnLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > (spawnZ - lengthOnScreen * roadLength))
        {
            SpawnLevel();
        }
    }

    private void SpawnLevel(int prefabIndex = -1)
    {

        GameObject go;
        go = Instantiate(levelPrefabs[levelIndex], transform.position, Quaternion.identity) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += roadLength;

    }

}
