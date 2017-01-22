using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Assets.Scripts.Core;
using Assets.Scripts.Utils;

public class LevelManager : MonoBehaviour, ILevelManager
{
    public ManagerStatus status { get; private set; }

    public GameObject[] levelPrefabs;

    private Transform _playerTransform;
    private float _spawnZ = 0.0f;
    private float _roadLength = 10f;
    private int _lengthOnScreen = 10;
    private float _safeZone = 20f;
    private List<GameObject> _activeTiles;
    private int _lastPrefabIndex = 0;

    public void Startup()
    {
        Debug.Log("Level manager starting...");
        BeginGenerate();
        status = ManagerStatus.Started;
        // CreateGame();
    }

    void BeginGenerate()
    {
        _activeTiles = new List<GameObject>();
        
        for (int i = 0; i < _lengthOnScreen; i++)
        {
            if (i < 2)
            {
                SpawnLevel(0);
            }
            else
            {
                SpawnLevel();
            }
        }
    }

    public void Update()
    {
        CreateGame();
    }

    public void CreateGame()
    {
        if (_playerTransform == null)
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            // player = Instantiate(playerPrefab, Spawn.position, Spawn.rotation) as GameObject;
            // playerTransform = player.transform;
        }
        else if (_playerTransform.position.z - _safeZone > (_spawnZ - _lengthOnScreen * _roadLength))
        {
            SpawnLevel();
            DeleteTile();
        }
    }

    private void DeleteTile()
    {
        Destroy(_activeTiles[0]);
        _activeTiles.RemoveAt(0);
    }

    private void SpawnLevel(int prefabIndex = -1)
    {
        GameObject go;

        if (prefabIndex == -1)
        {
            go = Instantiate(levelPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(levelPrefabs[prefabIndex]) as GameObject;
        }

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * _spawnZ;
        _spawnZ += _roadLength;
        _activeTiles.Add(go);
    }

    private int RandomPrefabIndex()
    {
        if (levelPrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = _lastPrefabIndex;

        while (randomIndex == _lastPrefabIndex)
        {
            randomIndex = UnityEngine.Random.Range(0, levelPrefabs.Length);
        }

        _lastPrefabIndex = randomIndex;

        return randomIndex;
    }

    public void Start()
    {
        
    }
}
