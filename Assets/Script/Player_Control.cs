using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Player_Control : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    private bool combat;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        combat = true;
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
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            combat = false;
            Debug.Log("not Incombat");
        }
    }

    private void playerMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-force, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(force, rb.velocity.y);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            combat = true;
            Debug.Log("incombat");
        }
    }
}