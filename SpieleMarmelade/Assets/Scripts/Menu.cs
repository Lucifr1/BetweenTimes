using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
        KatapultMechanism.catapultflying = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
    }

    public void CreditsBack()
    {
        SceneManager.LoadScene(0);
    }
}
