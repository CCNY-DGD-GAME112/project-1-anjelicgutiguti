using UnityEngine;

public class pistol : MonoBehaviour
{
    public Transform firepoint;
    public BULLET bulletPrefab;

    public float fireCooldown = .2f;
    float cooldownTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public void TryShoot()
    {
        if (cooldownTimer < 0)
        {
            return;
        }

        cooldownTimer = fireCooldown;

        BULLET bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bullet.Launch(firepoint.right);
    }
    
}
