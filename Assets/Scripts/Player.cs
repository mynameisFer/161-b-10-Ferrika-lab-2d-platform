using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get ; set ; }
    [field: SerializeField] public Transform Shootpoint { get; set; }
    public float ReloadTime { get ; set ; }
    public float WaitTime { get ; set ; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialize(100);
        ReloadTime = -5.0f;
        WaitTime = 0.0f;
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            //take damage
            OnHitWith(enemy);
        }
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }

    public void Shoot()
    {
      if(Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        {
            var bullet = Instantiate(Bullet, Shootpoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
            {
                banana.InitWeapon(29, this);
            }
            WaitTime = 0.0f; //Reset WaitTime
        }
    }
}
