using JetBrains.Annotations;
using UnityEngine;

public class BULLET: MonoBehaviour

{
    public float speed = 12;
    public float lifetime = 2;
    public LayerMask hitLayers; 

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
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
