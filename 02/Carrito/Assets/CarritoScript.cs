using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoScript : MonoBehaviour
{
    [SerializeField] float steerSpeed;
    [SerializeField] float moveSpeed;

    [SerializeField] float flipSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(0, 0, 45);
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float flipAmount = Input.GetAxis("Jump") * flipSpeed * Time.deltaTime;
        transform.Rotate(flipAmount, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
