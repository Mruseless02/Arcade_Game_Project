using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum SoundType
{
    Fire_Magic,
    Explosion,
    Fire_Crackle,
    Wind_Magic,
    Water_Bullet,
    Water_Spike,
    Water_Drips,
    Thunder_Magic,
    Thunder_Hit,
    Ice_Magic_Create,
    Ice_Magic,
    Ice_Freeze,
    Dark_Magic,
    Dark_Hit,
    Dark_Ground,
    Stone_Magic,
    Hit,
    Death,
    Skeleton_Hit,
    Skeleton_Death,
    Enemy_Death,  
    EvilMageLaugh,
    Enemy_Hit,
    Enemy_Slash,
    Enemy_Bite,
    Enemy_Attack,
    Traps,
    Steps,
    StairClimbing,
    Eviroment,
    Atmosphere,
    Charging,
    Earth_Bump,
    Humanoid_Hurt,
    Humanoid_Died,
    Ice_Hit, 
    Wind_Suck,
    Wind_Explode,
    Water_Hit,
    Typing,
    DoorOpen,DoorClose,
    FireTrap,
}

[RequireComponent(typeof(AudioSource)) ,ExecuteInEditMode]
public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] AudioList[] soundList;
    private AudioSource audioSource;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public static void PlayAudio(SoundType sound,float Volume = 1)
    {
        AudioClip[] clips = instance.soundList[(int)sound].sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0,clips.Length)];
        instance.audioSource.PlayOneShot(randomClip, Volume);
    }

#if UNITY_EDITOR

    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);
        for(int i = 0; i < soundList.Length; i++)
            soundList[i].name = names[i];
    }
#endif
}
[Serializable]
public struct AudioList
{
    public AudioClip[] sounds { get => Sound; }
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] Sound;
}