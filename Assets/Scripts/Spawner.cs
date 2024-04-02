using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject gobject;
    [SerializeField] KeyCode button;


    void Update()
    {
        if (Input.GetKeyDown(button)) 
        {
            Instantiate(gobject);
        }
    }
}
