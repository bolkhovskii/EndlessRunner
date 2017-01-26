using UnityEngine;
using System.Collections;

public class StaffScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("STAFF SCRIPT " + collider.gameObject.name);
    }
}
