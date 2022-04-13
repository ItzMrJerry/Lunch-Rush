using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CustomSongConstructor : MonoBehaviour
{
    public Transform Target;
    public List<float> positions;
    private bool editor;
    private customsongScene CustomSongEditor;

    // Start is called before the first frame update
    void Start()
    {
        CustomSongEditor = GameObject.Find("CustomSong").GetComponent<customsongScene>();
        editor = CustomSongEditor.EditSong;
        Debug.Log(editor);
    }

    // Update is called once per frame
    void Update()
    {
        if (editor) RecordInput();

    }

    private void RecordInput()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.F))
        {
            positions.Add(Target.position.x);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            CreateText();
        }
    }

    public void CreateText()
    {
        string path = Application.dataPath + "/Resources/" + CustomSongEditor.SongName+ ".text";

        if (File.Exists(path))
        {
            File.WriteAllText(path, "");
            Debug.Log("Replace text");
        }

        foreach (var pos in positions)
        {
            string posstring = pos.ToString();
            File.AppendAllText(path, posstring + "\n");
        }
        Debug.Log("Path: " + path);
    }
}
