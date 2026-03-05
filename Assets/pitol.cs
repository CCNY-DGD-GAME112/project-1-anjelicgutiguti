using UnityEngine;

public class pitol : MonoBehaviour
{
    public Transform firepoint;
    public bb BulletPrefab;

    public float fireCooldown = 2;
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
        if (cooldownTimer < 0) return;
        cooldownTimer = fireCooldown;
        bb Bullet = Instantiate(BulletPrefab, firepoint.position, firepoint.rotation);
        Bullet.Launch(firepoint.right);
    }
    
}
