using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float moveSpeed = 5;
    private Rigidbody2D rb;

    //jump code
    public float jumpForce = 12;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    //guncall, shoot
    public Transform firepoint;
    public pistol gun;

    private bool isGrounded;
    private float moveX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;
        Vector2 aimDirection = (mouseWorld - firepoint.position);
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x)*Mathf.Rad2Deg;
        firepoint.rotation = Quaternion.Euler(0, 0, angle);

       if (Input.GetMouseButtonDown(0))
       {
            gun.TryShoot();
       }

    }
    void FixedUpdate()
    {
     rb.linearVelocity = new Vector2 (moveX * moveSpeed, rb.linearVelocity.y);
    }

}
