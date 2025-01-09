using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private DialogTrigger trigger;
    [SerializeField]
    private GameObject DialogBox;
    public GameObject DialogManager;
    [SerializeField]
    private GameObject item;
    public GameObject DropPos;
    public GameObject Canvas;
    private bool haventDrop = true;
    private void Start()
    {
        trigger = DialogBox.GetComponent<DialogTrigger>();
    }

    private void Update()
    {
        ItemDrop();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            trigger.TriggerDialog();
        }
    }

    void ItemDrop()
    {
        if(DialogManager.GetComponent<DialogManager>().DialogEnd == true && haventDrop == true)
        {
            Instantiate(item, DropPos.transform.position, Quaternion.identity);
            haventDrop = false;
            Canvas.SetActive(true);
        }
    }
}
