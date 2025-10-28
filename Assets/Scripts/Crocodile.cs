using UnityEngine;

public class Crocodile : Enemy, IShootable
{
    [SerializeField] private float atkRange;
    public Player player; //target to atk

    [field: SerializeField] public GameObject Bullet { get ; set; }
    [field: SerializeField] public Transform Shootpoint { get ; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    void Start()
    {
        base.Initialize(50);
        DamageHit = 30;
        //set atk range and target
        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();

        //set timers variable for thorwing rock
        WaitTime = 0.0f;
        ReloadTime = 5.0f; //thorw Rock every 5 sec
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime; //timer
        Behavior();
    }
    public override void Behavior()
    {
        //find distance between Croccodile and Player
        Vector2 distance = transform.position - player.transform.position;
        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{player.name} is in the {this.name}'s atk range!");
            Shoot();
        }
    }
    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot"); // call shoot animation
            var bullet = Instantiate(Bullet, Shootpoint.position, Quaternion.identity);
            Rock rock = bullet.GetComponent<Rock>();
            rock.InitWeapon(30, this);
            WaitTime = 0;
            Debug.Log($"{this.name} shoots rock to the {player.name}!");
        }
    }
}
