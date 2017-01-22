using UnityEngine;
using System.Collections;

public class CoinMechanics : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Coin Triggered");
    }
}
