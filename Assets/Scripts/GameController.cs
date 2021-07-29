using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private readonly TimeSpan _levelTime = new TimeSpan(0, 2, 30);
    private TimeSpan _currentTime = new TimeSpan(0, 2, 30);
    private int _currentLevel = 0;

    [SerializeField] private List<GameObject> levelObjectives, inLevelPortals;
    [SerializeField] private TextMeshProUGUI levelCounter, levelTimer;
    [SerializeField] private LevelController _levelController;

    private IEnumerator Start()
    { //Load player current level.
        yield return new WaitForSeconds(.1f);
        _currentLevel = PlayerPrefs.GetInt("level", 0);
        if (_currentLevel > 0)
        {
            for (int i = 0; i < _currentLevel; i++)
            {
                levelObjectives[i].SetActive(false);
                inLevelPortals[i * 2].SetActive(true);
                inLevelPortals[i * 2 + 1].SetActive(true);
            }       
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _levelController.GamePause();
        }
        
        //Checks whether current level is cleared.
        int count = levelObjectives[_currentLevel].transform.childCount;
        int currentCount = 0;
        foreach (Transform currentObjective in levelObjectives[_currentLevel].transform)
        {
            if (!currentObjective.gameObject.activeSelf)
            {
                currentCount++;
            }
        }
        levelCounter.SetText($"{currentCount}/{count}"); //Set current level progress.
        if (currentCount == count)
        {
            LoadNextLevel();
        }

        TimeSpan ts = TimeSpan.FromSeconds(Time.deltaTime);
        _currentTime = _currentTime.Subtract(ts);
        if (_currentTime.TotalMilliseconds < 0)
        {
            _levelController.GameOver();
        }

        levelTimer.SetText(_currentTime.ToString(@"mm\:ss")); //Set current level timer.
    }

    private void LoadNextLevel() //Opens portal to next level.
    {
        if (_currentLevel == 1)
        {
            _levelController.GameWin();
        }
        inLevelPortals[_currentLevel * 2 ].SetActive(true);
        inLevelPortals[_currentLevel * 2 + 1].SetActive(true);
        _currentLevel++;
        _currentTime = _levelTime;
        PlayerPrefs.SetInt("level", _currentLevel);
    }
}
