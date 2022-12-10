using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialLoadingScen : MonoBehaviour{
    // Start is called before the first frame update
    void Start(){
        try {
            Progress progress = SaveProgress.Reading();
            switch (progress.ProgressLvl) {
                case 1:
                    SceneManager.LoadScene("FirstLevelScene");
                    break;
                case 2:
                    SceneManager.LoadScene("SecondLevelScene");
                    break;
                default:
                    Debug.LogError("Не понятный уровень в ProgressLvl: " + progress.ProgressLvl);
                    SaveProgress.Saveing(new Progress(progress.PreviousRecord));
                    SceneManager.LoadScene("FirstLevelScene");
                    break;
            }

        } catch (System.Exception ex1) {
            Debug.Log(ex1.Message);
            try {
                SaveProgress.Saveing(new Progress());
                SceneManager.LoadScene("FirstLevelScene");
            } catch (System.Exception ex2) {
                Debug.LogError(ex2.Message);
                return;
            }
        }
    }
}
