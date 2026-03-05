using JetBrains.Annotations;
using UnityEngine;

public class bb : MonoBehaviour

{
    public float speed = 12;
    public float Lifetime = 2;
    public LayerMask hitLayers; 

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, Lifetime);
    }

    public void Launch(Vector2 direction)
    {
        rb.linearVelocity = direction.normalized * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (((1 << other.gameObject.layer) & hitLayers) != 0)
        {
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
}
