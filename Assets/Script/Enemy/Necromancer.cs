using UnityEditor.Tilemaps;
using UnityEngine;

public class Necromancer : MonoBehaviour
{
    public GameObject Ground_Attack;
    public GameObject Projectile_Attack;
    public GameObject Player;
    public Transform projectileSpawn;
    private SpriteRenderer sprite;
    private Enemy_Hp hp;
    private BossDrop Drops;
    private Rigidbody2D rb;
    private Animator animator;
    public int random;
    private Vector3 target;
    private float timer;
    public float intervals;
    private bool canAtttack;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Player = GameObject.FindWithTag("Player");
        Drops = GetComponent<BossDrop>();
        timer = 0;
        projectileSpawn = gameObject.transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hp = GetComponent<Enemy_Hp>();
        flip();
        RandomAttack();
    }

    
    // Update is called once per frame
    void Update()
    {
        target = Player.transform.position;
        timer += Time.deltaTime;
        if (timer > intervals)
        {
            canAtttack = true;
        }
        if (canAtttack)
        {
            attack(random);
        }
    }

    private void flip()
    {
        if(transform.position.x > Player.transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
    void RandomAttack()
    {
        random = Random.Range(0, 9);
    }

    void attack(int attackType)
    {
        if (attackType <= 4)
        {
            Attack_Ground();
        }
        else if (attackType >= 5)
        {
            Attack_Projectile();
        }
    }
    void Attack_Ground()
    {
        timer = 0;
        animator.Play("Necromancer@GroundAttack");
        canAtttack = false;
        RandomAttack();
    }
    void LaunchGround()
    {
        Instantiate(Ground_Attack, Player.transform.position, Quaternion.identity);
    }

    void Attack_Projectile()
    {
        timer = 0;
        animator.Play("Necromancer@ProjectileAttack");
        canAtttack = false;
        RandomAttack();
    }
    void LaunchProjectile()
    {
        Instantiate(Projectile_Attack, projectileSpawn.position, Quaternion.identity);
    }
}
