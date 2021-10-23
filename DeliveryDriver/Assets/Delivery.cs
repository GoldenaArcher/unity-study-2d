using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    [SerializeField] Color32 hasPackageColor = new Color32(255, 0, 0, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);

    [SerializeField] float destroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collided");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (the thing we triggered is package)
        if (other.tag == "Package" && !this.hasPackage)
        {
            Debug.Log("Package hitted");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }
        else if (other.tag == "Customer" && this.hasPackage)
        {
            Debug.Log("Customer Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
