using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player_Hp : MonoBehaviour
{
    public GameObject MainUi;
    public GameObject Reset;
    [SerializeField]
    private ParticleSystem particle;
    private ParticleSystem particleInstance;
    public int HP = 100;
    private int MaxHp = 100;
    private bool canTakeDamage;
    private float damageInterval = 0.2f;
    private float timer = 0f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        PointStoreage.TotalHp = HP;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > damageInterval)
        {
            canTakeDamage = true;
        }
        Dead();
    }

    private void Dead()
    {
        if(HP <= 0)
        {
            MainUi.SetActive(false);
            Reset.SetActive(true);
            animator.SetTrigger("Dead");
        }
    }
    public void Healing(int ammount)
    {
        if(HP < MaxHp)
        {
            this.HP += ammount;
        }
    }

    public void Hit(int ammount)
    {
        if(canTakeDamage)
        {
            animator.SetTrigger("Hit");
            DamageParticle();
            this.HP -= ammount;
            PointStoreage.TotalHp = HP;
            canTakeDamage = false;
            timer = 0f;
        }
        
    }

    private void DamageParticle()
    {
        particleInstance  = Instantiate(particle, transform.position,Quaternion.identity);
        particleInstance.transform.parent = gameObject.transform;
    }
}
