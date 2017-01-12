using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }

    public void Startup()
    {
        Debug.Log("Player manager starting...");
        status = ManagerStatus.Started;


    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
