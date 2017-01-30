using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    [SerializeField]
    private GameObject platformDestroyerPoint;
    private Transform player;
    [SerializeField]
    private AudioSource dieSound;


    // Use this for initialization
    void Start()
    {
        player = GetComponent<Transform>();
        platformDestroyerPoint = GameObject.Find("Fall");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < platformDestroyerPoint.transform.position.y)
        {
            gameObject.SetActive(false);
            dieSound.Play();
        }
    }
}
