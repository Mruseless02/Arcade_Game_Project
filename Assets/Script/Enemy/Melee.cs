using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_Hp>() != null)
        {
            Player_Hp player_Hp = collision.GetComponent<Player_Hp>();
            player_Hp.Hit(damage);
        }
    }
}
