using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomsongButton : MonoBehaviour
{
    public CustomSongs customSongs;
    public TextMeshProUGUI songName;
    void Start()
    {
        customSongs = GameObject.Find("DataPath").GetComponent<CustomSongs>();
        
    }

    public void playsong()
    {
        customSongs.StartCoroutine(customSongs.PlaySong(songName.text,gameObject));
        //customSongs.selectSong(gameObject);
        
    }




    // Update is called once per frame
    void Update()
    {
        
    }

}
