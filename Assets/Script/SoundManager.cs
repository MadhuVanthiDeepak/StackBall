using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource;
    public bool sound = true;

    private void Awake()
    {
        MakeSingleTon();
        audioSource = GetComponent<AudioSource>();

    }
    void MakeSingleTon()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void  SoundOnOff()
    {
        sound = !sound;
    }

    public void PlaySoundFX(AudioClip clip,float volume)
    {
        if (sound)
            audioSource.PlayOneShot(clip, volume);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
