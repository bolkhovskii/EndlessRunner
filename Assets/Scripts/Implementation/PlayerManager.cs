using UnityEngine;
using System.Collections;
using Assets.Scripts.Core;
using Assets.Scripts.Utils;

public class PlayerManager : MonoBehaviour, IPlayerManager
{
    public ManagerStatus status { get; private set; }

    public void Startup()
    {
        Debug.Log("Player manager starting...");
        status = ManagerStatus.Started;
    }
    // Use this for initialization
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("COLLIDING");
    }
}
