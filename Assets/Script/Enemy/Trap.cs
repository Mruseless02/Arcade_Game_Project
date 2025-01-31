using Unity.VisualScripting;
using UnityEngine;

public class Trap : MonoBehaviour
{
    int damage = 5;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_Hp>() != null)
        {
            Player_Hp player_Hp = collision.GetComponent<Player_Hp>();
            player_Hp.Hit(damage);
        }
    }
}
