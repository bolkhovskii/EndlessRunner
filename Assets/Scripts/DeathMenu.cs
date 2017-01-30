using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathMenu : MonoBehaviour {
    [SerializeField]
    private GameObject deathMenu;
    [SerializeField]
    private Text _coin;
    [SerializeField]
    private Text _score;
    [SerializeField]
    
    // Use this for initialization
    void Start () {
        
        deathMenu.SetActive(false);
	}
	
    public void ToggleEndMenu(float Score, float Coins, bool _isDead)
    {
        deathMenu.SetActive(_isDead);
        _coin.text = Coins.ToString();
        _score.text = ((int)Score).ToString();
    }
}
