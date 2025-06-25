using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTriger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>())
        {
            GameManager.instance.StartMoveCoffeHouse();
        }        
    }
}
