using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CustomSongs : MonoBehaviour
{
    public string data_path;
    public TextMeshProUGUI debugText;
    public bool DebuggingMode = false;
    public GameObject CustomSongPrefab;
    public Transform CustomSongList;

    public AudioClip clip;

    public List<GameObject> songslist = new List<GameObject>();
    public GameObject SelectedSong;
    public AudioSource source;
    private string Songname;
    void Start()
    {
        data_path = Application.dataPath + "/CustomSongs";
        Debug.Log(data_path);
        
        
        if (!System.IO.File.Exists(data_path))
        {
            Directory.CreateDirectory(data_path);

            if (DebuggingMode){
                debugText.text = data_path;
                debugText.color = Color.green;
            }
            else
            {
                debugText.text = "";
            }
        }
            Debug.Log("Checking for Files...");
        
            foreach (string file in System.IO.Directory.GetFiles(data_path))
            {
                if (!file.Contains(".meta") && file.Contains("mp3")) {
                    GameObject go = Instantiate(CustomSongPrefab, CustomSongList);
                    go.GetComponentInChildren<TextMeshProUGUI>().text = Path.GetFileName(file);
                    songslist.Add(go);
                }
            }
        
    }

    public void ShowExplorer()
    {
        Application.OpenURL(data_path);
        //data_path = data_path.Replace(@"/", @"\");   // explorer doesn't like front slashes
        //System.Diagnostics.Process.Start("explorer.exe", "/select," + data_path);
    }
    
    public IEnumerator PlaySong(string filePath, GameObject go)
    {

        //clip = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/CustomSongs/" + filePath, typeof(AudioClip));

        UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip("file:///" + data_path +"/" + filePath, AudioType.MPEG);
        yield return req.SendWebRequest();

        clip = DownloadHandlerAudioClip.GetContent(req);
        source = GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        selectSong(go);
        Songname = filePath;

    }

    public void selectSong(GameObject go)
    {
        foreach (var song in songslist)
        {
            song.GetComponent<Image>().color = Color.white;
        }
        SelectedSong = go;
        SelectedSong.GetComponent<Image>().color = Color.green;
        GameObject.Find("CustomSong").GetComponent<customsongScene>().Song = source.clip;
    }

    public void DeleteSong()
    {
        File.Delete(data_path + "/"+ SelectedSong.GetComponent<TextMeshProUGUI>().text);
    }

    public void PlayLevel(bool editing)
    {
        if (SelectedSong != null)
        {
            customsongScene go = GameObject.Find("CustomSong").GetComponent<customsongScene>();
            go.SongName = Songname;
            go.SwitchToCustomLevel(editing);
        }
       
    }

    

}
