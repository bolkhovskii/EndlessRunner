using UnityEngine;
using System.Collections;

public class CoinX1Script : MonoBehaviour
{
    [SerializeField]
    private AudioSource coin;

    void Start()
    {
        coin = GameObject.Find("coinsoudn").GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            
            gameObject.SetActive(false);
            coin.Play();

        }
    }
}
