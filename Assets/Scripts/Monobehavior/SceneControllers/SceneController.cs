using System;
using UnityEngine;

/// <summary>
/// Abstract scene controller parent class implementing common methods.
/// </summary>
public abstract class SceneController : MonoBehaviour
{
    /// <summary>
    /// Set timescale back to 1.
    /// </summary>
    private void Awake()
    {
        Time.timeScale = 1;
    }
    
    /// <summary>
    /// Retry current level.
    /// </summary>
    public void RetryLevelHandler()
    {
        TwoDGameController.RetryLevel();
    }
    /// <summary>
    /// Handler for play button.
    /// </summary>
    public void LoadNextLevelHandler()
    {
        TwoDGameController.LoadNextLevel();
    }

    /// <summary>
    /// Handler for quit button.
    /// </summary>
    public void QuitGameHandler()
    {
        TwoDGameController.QuitGame();
    }
}
