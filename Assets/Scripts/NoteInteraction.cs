using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteInteraction : MonoBehaviour
{
    public GameObject Note;
    public KeyCode DashKeyOne;
    public KeyCode DashKeyTwo;
    public GameObject TextPopUp;
    private GameObject Canvas;
    private PlayerManager PM;
    private AudioManager AS;
    public GameObject AudioSourcePrefab;
    public AudioClip Swing;

   
    private void Start()
    {
        Canvas = GameObject.Find("GameUI");
        PM = GameObject.Find("Player").GetComponent<PlayerManager>();
        AS = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        KeyInput();
    }

    private void KeyInput()
    {
        if (Input.GetKeyDown(DashKeyOne) && Note != null || Input.GetKeyDown(DashKeyTwo) && Note != null)
        {
            float Distance = Note.transform.position.x - transform.position.x;
            if (Distance < 0.1)
            {
                SpawnTextPopUp(true);
                PM.AddCombo(true);
                PM.AddScore(100 + (PM.Combo * 10));
                PlaySound();
            }
            else
            {
                SpawnTextPopUp(false);
                PM.AddCombo(true);
                PM.AddScore(100 + (PM.Combo * 5));
                PlaySound();
            }
            Note.SetActive(false);
            PM.AttackAnim();
            
        } else if (Input.GetKeyDown(DashKeyOne) && Note == null || Input.GetKeyDown(DashKeyTwo) && Note == null)
        {
            PM.AddCombo(false);
        }
    }

    private void SpawnTextPopUp(bool Prefect)
    {
        GameObject Go = Instantiate(TextPopUp, Canvas.transform);
        Go.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Prefect)
        {
            Go.GetComponentInChildren<TextMeshProUGUI>().text = "perfect";
        }
        else
        {
            Go.GetComponentInChildren<TextMeshProUGUI>().text = "great";
        }
        Destroy(Go, 0.4f);
    }
    public void PlaySound()
    {

        GameObject go = Instantiate(AudioSourcePrefab, transform.position, Quaternion.identity);
        Destroy(go, 0.4f);
        AudioSource aud = go.GetComponent<AudioSource>();

        aud.volume = AS.GameAudioVolume;
        AS.GameAudioSlider.value = AS.GameAudioVolume;

        aud.volume = Random.Range(AS.GameAudioVolume / 20, AS.GameAudioVolume / 10);
        aud.clip = Swing;
        aud.pitch = Random.Range(0.7f, 0.85f);
        aud.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Note")
        {
            Note = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            Note = null;
        }
    }
}
