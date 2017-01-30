using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    public GameObject pooledObject;

    public int pooledAmount;

    public Transform parent;

    List<GameObject> pooledObjects;
    // Use this for initialization
    void Start()
    {
        parent = GetComponent<Transform>();
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.transform.SetParent(parent);
            obj.SetActive(false);
            pooledObjects.Add(obj);

        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {

            if (pooledObjects[i].activeInHierarchy == false)
            {
                return pooledObjects[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.transform.SetParent(parent);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
