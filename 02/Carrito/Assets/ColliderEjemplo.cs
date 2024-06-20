using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEjemplo : MonoBehaviour
{
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        Debug.Log("PUM!");
    }
}
