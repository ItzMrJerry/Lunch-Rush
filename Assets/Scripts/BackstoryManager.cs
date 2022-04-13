using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackstoryManager : MonoBehaviour
{
    public List<GameObject> Frames = new List<GameObject>();
    public float FrameTime;

    private void Start()
    {
        StartCoroutine(PlayStory());
    }

    IEnumerator PlayStory()
    {
        DisableGameObjects();
        Frames[0].SetActive(true);
        yield return new WaitForSeconds(2);
        DisableGameObjects();
        Frames[1].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        DisableGameObjects();
        Frames[2].SetActive(true);
        yield return new WaitForSeconds(FrameTime);
        DisableGameObjects();
        Frames[3].SetActive(true);
        yield return new WaitForSeconds(FrameTime);
        DisableGameObjects();
        Frames[4].SetActive(true);
        yield return new WaitForSeconds(FrameTime);
        DisableGameObjects();
        Frames[5].SetActive(true);
        yield return new WaitForSeconds(FrameTime);
        DisableGameObjects();
        Frames[6].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        DisableGameObjects();
        Frames[7].SetActive(true);
        yield return new WaitForSeconds(2);
        DisableGameObjects();
        Frames[8].SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    public void DisableGameObjects()
    {
        foreach (var item in Frames)
        {
            item.SetActive(false);
        }
    }
}
