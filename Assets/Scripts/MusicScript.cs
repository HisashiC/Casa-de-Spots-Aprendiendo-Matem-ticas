using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour
{
    public AudioSource musicSource;
    public static MusicScript instance = null;
    private string scene;

    public static MusicScript Instance
    {
        get { return instance; }
    }

    void Awake()
    { 
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Update()
    {
        scene = SceneManager.GetActiveScene().name;
        switch (scene)
        {
            case "World":
                musicSource.Stop();                
                break;
            case "World 2":
                musicSource.Stop();                
                break;
            case "World 3":
                musicSource.Stop();                
                break;
            case "World 4":
                musicSource.Stop();                
                break;
            default:
                if(!musicSource.isPlaying)
                musicSource.Play();
                break;
        }
        //musicSource.volume = volumen;
    }
    public void StopMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Stop();
    }
}