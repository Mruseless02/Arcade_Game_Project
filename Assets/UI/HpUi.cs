using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;
public class HpUi : MonoBehaviour
{

    public GameObject Player;
    private Player_Hp Hp;
    private int Current_Hp;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Little Mage");
        Hp = Player.GetComponent<Player_Hp>();
    }

    // Update is called once per frame
    void Update()
    {
        Current_Hp = Hp.HP;

        animator.SetInteger("Hp",Current_Hp);
    }
}
