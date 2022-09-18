using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public static MusicPlayer instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = PlayerPrefManager.GetMasterVolume();
    }

    public void SetAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
    }
    
/*    public void SetToggleAudio(bool isOn)
    {
        if (isOn)
        {
            audioSource.Play();
        } else
        {
            audioSource.Stop();
        }
    }*/
}
