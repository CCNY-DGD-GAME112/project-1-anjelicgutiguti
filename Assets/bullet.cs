using JetBrains.Annotations;
using UnityEngine;

public class bullet : MonoBehaviour

{
    public float speed = 12;
    public float Lifetime = 2;
    public int damage = 1; 

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, Lifetime);
    }

    public void 
    // Update is called once per frame
    void Update()
    {
        
    }
}
