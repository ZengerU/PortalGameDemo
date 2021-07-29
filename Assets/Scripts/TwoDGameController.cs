using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class TwoDGameController
{

    /// <summary>
    /// Unpause game by setting timescale back to 1.
    /// </summary>
    public static void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// Reload current level.
    /// </summary>
    public static void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// Quit the game.
    /// </summary>
    public static void QuitGame()
    {
#if UNITY_EDITOR //Editor does not quit with Application.Quit
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
    /// <summary>
    /// Load the next level in build scene order.
    /// </summary>
    public static void LoadNextLevel()
    {
        int nextLevel = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings; //Get next level.
        nextLevel = Math.Max(1, nextLevel); //Don't switch to main menu.
        SceneManager.LoadScene(nextLevel);
    }
}