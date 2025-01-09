using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuBGm : MonoBehaviour
{
    private void Start()
    {
        AudioManager.PlayAudio(SoundType.MainMenuBgm);
    }
}
