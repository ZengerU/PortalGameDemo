using TMPro;
using UnityEngine;

/// <summary>
/// Controller for main menu scene.
/// </summary>
public class LevelController : SceneController
{
    [SerializeField] private GameObject gameOverPanel, gamePausedPanel, gameWonPanel;
    
    /// <summary>
    /// Pause the game.
    /// </summary>
    public void GamePause()
    {
        if(gameOverPanel.activeSelf || gameWonPanel.activeSelf)
            return;
        Cursor.lockState = CursorLockMode.None;
        gamePausedPanel.SetActive(true);
        Time.timeScale = 0;
    }
    /// <summary>
    /// Unpause the game.
    /// </summary>
    public void UnpauseGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gamePausedPanel.SetActive(false);
        Time.timeScale = 1;
    }
    /// <summary>
    /// Win the game.
    /// </summary>
    public void GameWin()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameWonPanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    /// <summary>
    /// Lose the game.
    /// </summary>
    public void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
