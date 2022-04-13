using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Wheel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Wheel.GetComponent<Animator>().SetTrigger("Right");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Wheel.GetComponent<Animator>().SetTrigger("Left");
        }
    }

    public void PlayGame()
    {
        if (Wheel.transform.rotation.eulerAngles.z >= -10 && Wheel.transform.rotation.eulerAngles.z <= 10)
        {
            Debug.Log("0");
            SceneManager.LoadScene(2);

        }
        if (Wheel.transform.rotation.eulerAngles.z >= 80 && Wheel.transform.rotation.eulerAngles.z <= 100)
        {
            Debug.Log("90");
            SceneManager.LoadScene(3);
        }
        if (Wheel.transform.rotation.eulerAngles.z >= 170 && Wheel.transform.rotation.eulerAngles.z <= 190)
        {
            Debug.Log("180");
            SceneManager.LoadScene(4);
        }
        if (Wheel.transform.rotation.eulerAngles.z >= 260 && Wheel.transform.rotation.eulerAngles.z <= 280)
        {
            Debug.Log("-90");
            SceneManager.LoadScene(5);

        }


    }
}
