using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroPlayer : MonoBehaviour
{
    
    [SerializeField] float steerSpeed = 150.0f;
    [SerializeField] float moveSpeed = 8.0f;
    
    [SerializeField] private float velocidadRapido = 20f;
    [SerializeField] private float velocidadLento = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
