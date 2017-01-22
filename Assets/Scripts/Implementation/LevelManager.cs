using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Assets.Scripts.Core;
using Assets.Scripts.Utils;

public class LevelManager : MonoBehaviour, ILevelManager
{
    public ManagerStatus status { get; private set; }

    public GameObject[] LevelPrefabs;
    public GameObject Coin;

    private Transform _playerTransform;
    private float _spawnZ = 0.0f;
    private float _roadLength = 10f;
    private int _lengthOnScreen = 10;
    private float _safeZone = 20f;
    private List<GameObject> _activeTiles;
    private int _lastPrefabIndex = 0;
    private float _iterator = 0;

    private bool _direction = false;

    public LevelManager()
    {
        _iterator = 10;
    }
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
                SpawnLevel(0, 0);
            }
            else
            {
                SpawnLevel(-1, 0);
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
            RandomCoins();
            SpawnLevel(-1, _iterator);
            DeleteTile();
        }
    }

    public void RandomCoins()
    {
        _iterator = _playerTransform.position.z + UnityEngine.Random.Range(0f, 5f);
    }

    private void DeleteTile()
    {
        Destroy(_activeTiles[0]);
        _activeTiles.RemoveAt(0);
    }

    private void SpawnLevel(int prefabIndex, float iterator)
    {
        GameObject bridges;
        GameObject coins;

        if (prefabIndex == -1)
        {
            bridges = Instantiate(LevelPrefabs[RandomPrefabIndex()]) as GameObject;
            coins = (GameObject)Instantiate(Coin);
        }
        else
        {
            bridges = Instantiate(LevelPrefabs[prefabIndex]) as GameObject;
            coins = (GameObject)Instantiate(Coin);

        }
        bridges.transform.SetParent(transform);
        bridges.transform.position = Vector3.forward * _spawnZ;
        coins.transform.SetParent(transform);
        coins.transform.position = Vector3.forward * _spawnZ;
        coins.transform.position = new Vector3(UnityEngine.Random.Range(-1, 2), 1, iterator) * 2.0f;

        var coinCollider2D = coins.GetComponent<Collider>();
        OnTriggerEnter(coinCollider2D);
        _spawnZ += _roadLength;
        _activeTiles.Add(bridges);
        _activeTiles.Add(coins);
        _iterator++;

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "coin")
        {
            Debug.Log("Coin triggered");
        }
    }
    private int RandomPrefabIndex()
    {
        if (LevelPrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = _lastPrefabIndex;

        while (randomIndex == _lastPrefabIndex)
        {
            randomIndex = UnityEngine.Random.Range(0, LevelPrefabs.Length);
        }

        _lastPrefabIndex = randomIndex;

        return randomIndex;
    }

    public void Start()
    {

    }
}
