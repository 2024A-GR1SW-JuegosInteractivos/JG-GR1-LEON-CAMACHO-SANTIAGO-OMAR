using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroPlayer : MonoBehaviour
{
    [SerializeField] float steerSpeed = 150.0f;
    [SerializeField] float moveSpeed = 8.0f;

    [SerializeField] private float velocidadRapido = 20f;
    [SerializeField] private float velocidadLento = 5f;

    private float velocidadOriginal;
    [SerializeField] private float duracionBoost = 3f;  // Duración del boost

    void Start()
    {
        velocidadOriginal = moveSpeed;
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rapido")
        {
            Debug.Log("Ir rapido");
            StopAllCoroutines();  // Detiene cualquier boost/lento activo
            StartCoroutine(CambiarVelocidadTemporalmente(velocidadRapido));
        }

        if (other.tag == "Lento")
        {
            Debug.Log("Ir lento");
            StopAllCoroutines();  // Detiene cualquier boost/lento activo
            StartCoroutine(CambiarVelocidadTemporalmente(velocidadLento));
        }
    }

    IEnumerator CambiarVelocidadTemporalmente(float nuevaVelocidad)
    {
        moveSpeed = nuevaVelocidad;
        yield return new WaitForSeconds(duracionBoost);
        moveSpeed = velocidadOriginal;
    }
}
