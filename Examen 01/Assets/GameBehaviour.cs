using System.Collections;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField] private float delayDestroy = 0.5f;
    private bool tieneGF;
    public GameObject novia; // Asigna la novia en el inspector
    public AudioClip explosionSound; // Asigna el sonido de explosión en el inspector
    private AudioSource explosionAudioSource; // Fuente de audio para el sonido de explosión

    void Start()
    {
        novia.SetActive(false); // Asegúrate de que la novia esté desactivada al inicio
        explosionAudioSource = GetComponent<AudioSource>(); // Obtener el componente de AudioSource
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("PUM!");
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando en trigger!");
        
        if (other.CompareTag("Enemigo"))
        {
            tieneGF = false;
            Debug.Log("Mataste al enemigo!");

            // Reproducir sonido de explosión
            explosionAudioSource.PlayOneShot(explosionSound);

            // Hacer aparecer a la novia
            novia.SetActive(true);

            // Mover al enemigo y luego destruirlo
            Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                Vector2 forceDirection = other.transform.position - transform.position;
                forceDirection.Normalize();
                enemyRb.AddForce(forceDirection * 10f, ForceMode2D.Impulse); // Puedes ajustar la fuerza según sea necesario
                StartCoroutine(DestroyEnemyAfterDelay(other.gameObject));
            }
            else
            {
                // Si no tiene Rigidbody2D, simplemente destrúyelo después de un retraso
                Destroy(other.gameObject, delayDestroy);
            }
        }

        if (other.CompareTag("GF"))
        {
            tieneGF = true;
            novia.SetActive(false);
            Debug.Log("Recogiste a tu novia!");
        }

        if (other.CompareTag("Casa") && tieneGF)
        {
            tieneGF = false;
            Debug.Log("En casa!");
            // Aquí puedes añadir la lógica para ganar el juego
        }
    }

    IEnumerator DestroyEnemyAfterDelay(GameObject enemy)
    {
        yield return new WaitForSeconds(delayDestroy);
        Destroy(enemy);
    }
}
