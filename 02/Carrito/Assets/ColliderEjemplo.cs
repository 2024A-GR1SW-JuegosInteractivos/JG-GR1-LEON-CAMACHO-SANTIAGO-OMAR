using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEjemplo : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("PUM!");
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando en trigger!");
        if (other.tag == "Paquete")
        {
            Debug.Log("Recogio paquete!");
        }
        if (other.tag == "Cliente")
        {
            Debug.Log("Dejo paquete!");
        }
    }
}
