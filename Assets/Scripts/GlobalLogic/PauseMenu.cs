using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{

    private static bool _gameIsPaused = false;
    private static bool _audioIsPlay = true;


    [SerializeField] private GameObject _pauseMenuUi;

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (_gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        _pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }

    public GameObject Get_pauseMenuUi() {
        return _pauseMenuUi;
    }

    public void Pause() {
        _pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void ResetLVL() {
        _pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void SoundOnOff() {

    }
}