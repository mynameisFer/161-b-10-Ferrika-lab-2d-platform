using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //attributes
    private int health;
    public int Health
    {
        get { return health; }
        set { health = (value < 0) ? 0 : value; }
    }

    protected Animator anim;
    protected Rigidbody2D rb;

    public HealthBar healthBar;

    //initialize character
    public void Initialize(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} is initialize Health: {this.Health} ");

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(Health);
        }
    }
    public void  TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took damage {damage}. Current Health: {Health}");

        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }

        IsDead();
    }

    public bool IsDead()
    {
        if(Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
