using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private Animator animator;
    public Collider2D coll;
    private bool doorIsOpen = false;
    private bool isLocked = true;
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
                coll.isTrigger = true;
                animator.SetBool("Open", true);
                if (player.Have_Key && doorIsOpen == false)
                {
                    doorIsOpen = true;
                    player.keys -= 1;
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

