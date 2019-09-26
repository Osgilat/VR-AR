using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSwapper : MonoBehaviour
{
    private void Start()
    {
        float randValue = Random.value;
        if (randValue < 0.5f) 
        {
            Swap();
        }
    }

    public GameObject other;
 
    
    void Swap() {
        Debug.Log("SWAPPED POSITIONS");    
        Vector3 temp = transform.position;
        transform.position = other.transform.position;
        other.transform.position = temp;
    }
}
