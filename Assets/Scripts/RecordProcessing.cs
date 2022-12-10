using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordProcessing : MonoBehaviour{
    [SerializeField]
    private GameObject _currentRecord;
    [SerializeField]
    private GameObject _previousRecord;
    [SerializeField]
    private GameObject _messageRecord;

    // Start is called before the first frame update
    void Start(){
        Debug.Log("PastTime: " + SaveProgress.CurrentPrigress.PastTime.ToString(@"hh\:mm\:ss") +
                  "\nPreviousRecord: " + SaveProgress.CurrentPrigress.PreviousRecord.ToString(@"hh\:mm\:ss"));
        SaveProgress.CurrentPrigress.FixTime();
        _currentRecord.gameObject.GetComponent<TextMeshProUGUI>().text += SaveProgress.CurrentPrigress.PastTime.ToString(@"hh\:mm\:ss");
        if (SaveProgress.CurrentPrigress.PreviousRecord != TimeSpan.MaxValue) {
            _previousRecord.gameObject.GetComponent<TextMeshProUGUI>().text += SaveProgress.CurrentPrigress.PreviousRecord.ToString(@"hh\:mm\:ss");
        }
        if (SaveProgress.CurrentPrigress.PastTime < SaveProgress.CurrentPrigress.PreviousRecord ||
            SaveProgress.CurrentPrigress.PreviousRecord == TimeSpan.MaxValue) {
            _messageRecord.GetComponent<TextMeshProUGUI>().text = "Новый рекорд!";
            SaveProgress.Saveing(new Progress(SaveProgress.CurrentPrigress.PastTime));
        }else
            SaveProgress.Saveing(new Progress(SaveProgress.CurrentPrigress.PreviousRecord));
    }

    public void FromTheBeginning() {
        SceneManager.LoadScene("FirstLevelScene");
    }

    public void QuitGame() {
        Application.Quit();
    }

}
