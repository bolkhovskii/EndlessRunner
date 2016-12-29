using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelManager : MonoBehaviour {
    public GameObject[] levelPrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float roadLength = 10f;
    private int lengthOnScreen = 10;
    private float safeZone = 20f;
    private List<GameObject> activeTiles;
    private int lastPrefabIndex = 0;


    void Start () {
        activeTiles = new List<GameObject>();


        for(int i=0; i < lengthOnScreen; i++)
        {
            if (i < 2)
                SpawnLevel(0);
            else
                SpawnLevel();
        }
    }
	


	void Update () {
      CreateGame();
	}

    public void CreateGame()
    {
        if(playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        } else if (playerTransform.position.z - safeZone > (spawnZ - lengthOnScreen * roadLength))
        {
            SpawnLevel();
            DeleteTile();
        }
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private void SpawnLevel(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(levelPrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(levelPrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += roadLength;
        activeTiles.Add(go);
    }

    private int RandomPrefabIndex()
    {
        if (levelPrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = UnityEngine.Random.Range(0, levelPrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

}
