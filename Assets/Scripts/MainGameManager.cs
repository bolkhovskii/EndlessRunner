using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Assets.Scripts.Core;
using Assets.Scripts.Utils;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(LevelManager))]
public class MainGameManager : MonoBehaviour
{
    public static IPlayerManager Player { get; private set; }
    public static ILevelManager Level { get; private set; }

    private List<IGameManager> _startSequence;

    public void Awake()
    {
        Player = GetComponent<IPlayerManager>();
        Level = GetComponent<ILevelManager>();
        
        _startSequence = new List<IGameManager>();
        _startSequence.Add(Level);
        _startSequence.Add(Player);
        StartCoroutine(StartupManagers());
    }
    // Use this for initialization
    private IEnumerator StartupManagers()
    {
        foreach (var manager in _startSequence)
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

            foreach (var manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started)
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
