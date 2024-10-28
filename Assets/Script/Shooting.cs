using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public string tags;
    public int Damage = 10;
    Vector3 SpawnPoint;
    private Animator animator;
    private Rigidbody2D rb;
    private GameObject Target;
    private GameObject Boss;
    private Transform TargetPos;
    private Transform BossPos;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = transform.position;
        Target = GameObject.FindWithTag(tags);
        TargetPos = Target.transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Enemy_Hp>() != null)
        {
            Enemy_Hp enemy_Hp = collider.GetComponent<Enemy_Hp>();
            enemy_Hp.takingDamage(Damage);
        }
        if (collider.CompareTag(tags))
        {
            force = 0;
            animator.SetTrigger("Hit");
            Debug.Log("Enemyhit");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag(tags))
        {
        Vector3 Direction = TargetPos.position - SpawnPoint;
        rb.velocity = new Vector3(Direction.x, Direction.y).normalized * force;
        Vector3 rotation = TargetPos.position - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }
}
