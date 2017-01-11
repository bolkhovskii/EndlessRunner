using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(LevelManager))]
public class MainGameManager : MonoBehaviour {
    public static PlayerMovement Player { get; private set; }
    public static LevelManager Level { get; private set; }

    private List<IGameManager> _startSequence;

    void Awake()
    {
        Player = GetComponent<PlayerMovement>();
        Level = GetComponent<LevelManager>();


        _startSequence = new List<IGameManager>();
        _startSequence.Add(Level);
        _startSequence.Add(Player);
        StartCoroutine(StartupManagers());
    }

    // Use this for initialization

private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int numModules = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach (IGameManager manager in _startSequence)
            {
                if(manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }

            if (numReady > lastReady)
                Debug.Log("Progress: " + numReady + "/" + numModules);
            yield return null;
        }
        Debug.Log("All managers started up");
    }
}
