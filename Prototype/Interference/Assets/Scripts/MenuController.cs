using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour 
{
    public int sceneIndex = 0;

	void OnMouseDown ()
	{
        if (sceneIndex == 1)
        {
            PlayScene();
        }
        else if (sceneIndex == 2)
        {
            InstructionScene();
        }
        else if (sceneIndex == 3)
        {
            MenuScene();
        }
        else if (sceneIndex == 4)
        {
            Application.Quit();
        }
    }

    void InstructionScene()
    {
        SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
    }

    void PlayScene()
    {
        SceneManager.LoadScene("Interference", LoadSceneMode.Single);
    }

    void MenuScene()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}