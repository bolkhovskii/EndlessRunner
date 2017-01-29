using UnityEngine;
using System.Collections;

public class CoinX1Script : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gameObject.SetActive(false);

        }
    }
}
