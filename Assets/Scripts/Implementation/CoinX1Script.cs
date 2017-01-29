using UnityEngine;
using System.Collections;

public class CoinX1Script : MonoBehaviour
{

<<<<<<< HEAD
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
=======
    void OnTriggerEnter(Collider other)
>>>>>>> Final
    {
        if (other.gameObject.name == "Player")
        {
            gameObject.SetActive(false);

        }
    }
}
