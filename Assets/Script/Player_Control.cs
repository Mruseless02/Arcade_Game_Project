using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.VFX;

public class Player_Control : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public float force;
    public float jumpPwr;
    public float climb;
    private bool isJumping = false;
    private bool isClimbing = false;
    public bool Have_Key = false;
    private bool combat;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        combat = false;
    }

    // Update is called once per frame
    void Update()
    {
        combatMode();
        if (!combat)
        {
            GetComponent<Typer>().enabled = false;
            playerMove();
        }
        else if (combat)
        {
            GetComponent<Typer>().enabled = true;
        }
    }

    private void combatMode()
    {
        if(GameObject.FindWithTag("Enemy") == null)
        {
            combat = false;
        }
    }

    private void playerMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-force, rb.velocity.y);
            sprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(force, rb.velocity.y);
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpPwr);
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.W) && isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, climb);
        }
        if (Input.GetKey(KeyCode.S) && isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, -climb);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnActive"))
        {
            combat = true;
        }
        if (collision.CompareTag("Stairs"))
        {
            isClimbing = true;
            rb.gravityScale = 0f;
        }
        if (collision.CompareTag("Traps"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stairs"))
        {
            isClimbing = false;
            rb.gravityScale = 10f;
        }
        if (collision.CompareTag("Keys"))
        {
            Have_Key = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}