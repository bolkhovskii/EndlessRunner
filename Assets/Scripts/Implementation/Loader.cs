using UnityEngine;
using System.Collections;
using Assets.Scripts.Core;

public class Loader : MonoBehaviour, ILoader
{
    public GameObject gameManager;
    // Use this for initialization
    public void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    }

    public void Start()
    {
        // проверка
        GameManager.instance.AdjustScore(-1000);
        //
    }

    // Update is called once per frame
    public void Update()
    {

    }
}
