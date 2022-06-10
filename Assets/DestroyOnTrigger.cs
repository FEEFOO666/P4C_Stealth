using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{

    public GameObject objectToDestroy;
    public GameObject effect;

    // use for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Instantiate(effect, objectToDestroy.transform.position, objectToDestroy.transform.rotation);
        Destroy(objectToDestroy);
    }

} 
