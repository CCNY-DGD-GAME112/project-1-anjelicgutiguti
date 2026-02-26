using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed = 5;
    Rigidbody rb;
    Vector2 move;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("horizontal"),
                           Input.GetAxisRaw("vertical")).normalized;

        rb.linearVelocity = move * moveSpeed * Time.deltaTime;
       
                          
    }
}
