using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public AudioSource Audio;
    public bool menu;
    public bool NoteLights;
    private GameObject[] notes;
    private void Start()
    {
        if (NoteLights)
        {
            notes = GameObject.FindGameObjectsWithTag("Note");
            foreach (var item in notes)
            {
                item.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().enabled = true;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menu)
        {
            MenuSwitch();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menu)
        {
            PauseMenu.SetActive(false);

        }
    }
    public void MenuSwitch()
    {

        PauseMenu.SetActive(!PauseMenu.activeSelf);
        if (PauseMenu.activeSelf == true)
        {
            Time.timeScale = 0;
            Audio.Pause();
        }
        else
        {
            Time.timeScale = 1;
            Audio.Play();
            SettingsMenu.SetActive(false);
            
        }
    }
    public void BackTomenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
