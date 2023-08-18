using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f;
       [SerializeField] float slowSpeed = 15f;
       [SerializeField] float boostSpeed = 30f;
    
    // int hitPoints = 20; 
    // bool isAlive = true;
    // string myName = "Anastasia";
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

    void OnCollisionEnter2D(Collision2D other) {
                    Debug.Log("Bump");
            moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Boost"){
          Debug.Log("Boost");
          moveSpeed = boostSpeed;
        }
    }
}
