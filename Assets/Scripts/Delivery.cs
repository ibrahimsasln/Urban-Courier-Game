using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.3f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (the tag is package)
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Picked up package!");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();

            Destroy(collision.gameObject, destroyDelay);
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered package!");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject);
        }
        

    }
}
