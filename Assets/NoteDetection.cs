using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetection : MonoBehaviour
{
    public PlayerManager PM;

    private void Start()
    {
        PM = GameObject.Find("Player").GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Note")
        {
            Debug.Log("Failure");
            PM.Combo = 0;
            PM.AddCombo(false);
        }
    }
}
