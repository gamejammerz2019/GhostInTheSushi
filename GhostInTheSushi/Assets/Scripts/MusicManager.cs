using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;

    public AudioClip newMusic;

    public static MusicManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            //Finds the game object called Game Music, if it goes by a different name, change this.
            GameObject go = GameObject.Find("Game Music");
            //Replaces the old audio with the new one set in the inspector.
            go.GetComponent<AudioSource>().clip = newMusic;
            //Plays the audio.
            go.GetComponent<AudioSource>().Play();
            go.GetComponent<AudioSource>().loop = true;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // any other methods you need
}