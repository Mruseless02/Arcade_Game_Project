using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActive : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_Control>() != null)
        {
            Player_Control player = collision.GetComponent<Player_Control>();
            player.CanMove = false;
            canvas.SetActive(true);
        }
    }

    public void disableCanvas()
    {

        canvas.SetActive(false);
    }
}
