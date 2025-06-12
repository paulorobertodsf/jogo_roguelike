using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string nameLevel;

    public void Play()
    {
        SceneManager.LoadScene(nameLevel);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
