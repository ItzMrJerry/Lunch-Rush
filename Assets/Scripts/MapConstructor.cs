using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class MapConstructor : MonoBehaviour
{
    public GameObject Prefab;
    public List<string> filelines;

    public bool SpawnNotes = true;

    public string FileName;
    public bool Testing;
    private string convert;
    private float x;
    public int ammount;
    private customsongScene customsong;
    public List<Color> SkullColors = new List<Color>();

    public GameObject FinishLine;
    public GameObject BossLine;
    void Start()
    {
        customsong = GameObject.Find("CustomSong").GetComponent<customsongScene>();
        if (!customsong.EditSong)
        {
        CreateMap();

        }
    }

    public void CreateMap()
    {



        if (SpawnNotes)
        {
            string path = Application.dataPath + "/Resources/" + customsong.SongName + ".text";

            Debug.Log("Path: " + path);

            filelines = File.ReadAllLines(path).ToList();
            foreach (var Line in filelines)
            {

                if (!Testing)
                {
                    convert = Line.ToString().Replace('.', ',');
                    Debug.Log(convert);
                    x = float.Parse(convert);
                }
                else
                {
                    x = float.Parse(Line);
                }
                if (x == float.Parse(filelines[filelines.Count - 1]))
                {
                    Debug.Log(x);
                    BossLine.transform.position = new Vector3(x + 5, BossLine.transform.position.y, BossLine.transform.position.z);
                    FinishLine.transform.position = new Vector3(x + 30, FinishLine.transform.position.y, FinishLine.transform.position.z);
                }

                //Line.Replace(".", ",");

                //FileTest.text = "FileTest: " + filelines;
                int RandomPos = Random.Range(0, 2);
                if (RandomPos == 1)
                {
                    GameObject UpNote = Instantiate(Prefab, new Vector3(x, 4, 0), Quaternion.identity);
                    UpNote.transform.parent = gameObject.transform;
                    int randomColor = Random.Range(0, SkullColors.Count - 1);
                    UpNote.GetComponent<SpriteRenderer>().color = SkullColors[randomColor];
                    UpNote.GetComponent<Light2D>().color = SkullColors[randomColor];
                    

                    // GameObject UpNote = Instantiate(Prefab, new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z), Quaternion.identity);
                    ammount++;
                }
                if (RandomPos == 0)
                {
                    GameObject UpNote = Instantiate(Prefab, new Vector3(x, 0, 0), Quaternion.identity);
                    UpNote.transform.parent = gameObject.transform;
                    int randomColor = Random.Range(0, SkullColors.Count - 1);
                    UpNote.GetComponent<SpriteRenderer>().color = SkullColors[randomColor];
                    UpNote.GetComponent<Light2D>().color = SkullColors[randomColor];
                    // GameObject UpNote = Instantiate(Prefab, new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z), Quaternion.identity);
                    ammount++;

                }
            }
        }
    }
}
