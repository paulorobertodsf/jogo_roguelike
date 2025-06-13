using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static string pathData = "Assets/Data";
    public static string pathPrefab = "Prefab/";

    public static void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
