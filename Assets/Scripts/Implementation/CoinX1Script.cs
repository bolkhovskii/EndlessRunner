using UnityEngine;
using System.Collections;

public class CoinX1Script : MonoBehaviour
{
    [SerializeField]
    private AudioSource coin;
    [SerializeField]
    private GameObject particle;

    void Start()
    {
        coin = GameObject.Find("coinsoudn").GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
           
            coin.Play();
            gameObject.SetActive(false);


        }
    }
}
