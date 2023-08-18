using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
 

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        // if(other.gameObject.tag == "Player"){
        //     Destroy(gameObject);
        // }
        Debug.Log("Collision");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Package" && !hasPackage){
            Debug.Log("Package Picked");
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
            hasPackage = true;
        } else if (other.gameObject.tag == "Customer" && hasPackage){
            Debug.Log("Delivered to Customer");
             spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}
