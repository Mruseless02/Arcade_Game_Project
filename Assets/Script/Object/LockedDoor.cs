using System.Threading;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private Animator animator;
    public Collider2D coll;
    private bool doorIsOpen = false;
    private bool isLocked = true;
    public bool needMoreThenOneLock = false;
    [SerializeField]private int KeysNeeded;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_Control>() != null && isLocked)
        {
            Player_Control player = collision.GetComponent<Player_Control>();
            if (player.Have_Key)
            {
                if (player.Have_Key && doorIsOpen == false && needMoreThenOneLock == false)
                {
                    player.keys -= 1;
                    animator.SetBool("Open", true);
                    coll.isTrigger = true;
                    doorIsOpen = true;
                }
                else if (player.Have_Key && doorIsOpen == false && needMoreThenOneLock == true)
                {
                    if(player.keys == KeysNeeded)
                    {
                        player.keys -= KeysNeeded;
                        animator.SetBool("Open", true);
                        coll.isTrigger = true;
                        doorIsOpen = true;
                    }
                }

            } 
        }
    }
    private void PlayAudioOpen()
    {
        AudioManager.PlayAudio(SoundType.DoorOpen);
    }

    private void PlayAudioClose()
    {
        AudioManager.PlayAudio(SoundType.DoorClose);
    }
}

