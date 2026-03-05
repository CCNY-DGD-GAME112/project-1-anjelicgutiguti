using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed = 5;
    Rigidbody2D rb;

    //jump code
    public float jumpForce = 12;
    public Transform groundCheck;
    public float groundcheckRadius = 1;
    public LayerMask groundlayer;

    //guncall, shoot
    public Transform firepoint;
    public pitol gun;

    public bool isGrounded;
    float moveX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundcheckRadius, groundlayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        Vector3 mouseWorld = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        mouseWorld.z = 0;
        Vector2 aimDirection = (mouseWorld - firepoint.position);
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x);
        firepoint.rotation = Quaternion.Euler(0, 0, angle);

       // if (Input.GetMouseButtonDown(0))
       // {
        //    pitol.TryShoot();
       // }

    }
    void FixedUpdate()
    {
     rb.linearVelocity = new Vector2 (moveX * moveSpeed, rb.linearVelocity.y);
    }

}
