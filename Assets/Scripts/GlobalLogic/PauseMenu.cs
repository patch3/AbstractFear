using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour{

    private static bool _gameIsPaused = false;
    private static bool _audioIsPlay = false;

    [SerializeField] private GameObject _buttonAudio;


    [SerializeField] private Sprite _spriteAudioOn;
    [SerializeField] private Sprite _spriteAudioOff;


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
        if (_audioIsPlay) {
            _buttonAudio.GetComponent<Image>().sprite = _spriteAudioOff;
        } else {
            _buttonAudio.GetComponent<Image>().sprite = _spriteAudioOn;
        }
        _audioIsPlay = !_audioIsPlay;
        AudioListener.pause = _audioIsPlay;
    }
}