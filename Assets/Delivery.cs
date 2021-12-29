using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 noPackageColour = new Color32(255, 255, 255, 255);
    [SerializeField] Color32 hasPackageColour = new Color32(0, 255, 0, 255);
    [SerializeField] float destroyPackageDelay = 0.0f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided with gameobject");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColour;
            Debug.Log("Package picked up");
            Destroy(other.gameObject, destroyPackageDelay);
        }
        if (other.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            spriteRenderer.color = noPackageColour;
            Debug.Log("Package delivered");
        }
    }
}
