﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
    [SerializeField]
    public GameObject pooledObject;
    [SerializeField]
    private int poolAmount;

    List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {
        pooledObjects = new List<GameObject>();

        for(int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
	}

    public GameObject GetPooledObject()
    {
        for(int i = 0; i<pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
