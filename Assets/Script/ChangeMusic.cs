using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public GameObject audio1;
    public GameObject audio2;

    public void changeAudio()
    {
        audio1.SetActive(false);
        audio2.SetActive(true);
    }

    public void returnAudio()
    {
        audio2.SetActive(false);
        audio1.SetActive(true);
    }
}
