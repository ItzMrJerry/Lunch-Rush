using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class customsongScene : MonoBehaviour
{
    public AudioClip Song;
    public AudioSource AudioManager;
    public bool EditSong = false;
    public int Loaded = 0;
    private static customsongScene playerInstance;
    public string SongName;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

        //if (AudioManager == null) return;
      


    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "CustomLevel" && AudioManager == null)
        {
            AudioManager = GameObject.Find("AudioManager").GetComponent<AudioSource>();
            

        }
        if (SceneManager.GetActiveScene().name == "CustomLevel" && AudioManager.clip == null)
        {
            AudioManager.clip = Song;
            AudioManager.Play();
        }

        
    }
    void OnSceneLoaded()
    {

    }

    public void SwitchToCustomLevel(bool editing)
    {
        
        EditSong = editing;
        Loaded++;
        SceneManager.LoadScene("CustomLevel");
    }

}
