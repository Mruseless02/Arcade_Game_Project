using UnityEngine;

public class Destroy_Object : MonoBehaviour
{
    private Enemy_Melee melee;
    private Collider2D coll;
    private Rigidbody2D rb;
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    public void DestroyScript()
    {
        gameObject.tag = "Untagged";
        melee = GetComponent<Enemy_Melee>();
        Destroy(melee);
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(rb); coll.enabled = false;

    }

}
