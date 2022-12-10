using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassToNextLevel : MonoBehaviour{

    [SerializeField] private Sprite _indexArrow;

    [SerializeField] private GameObject _pointIndexAreaLeft;
    [SerializeField] private GameObject _pointIndexAreaRight;


    // Start is called before the first frame update
    void Start() {
        // привязываю обработчик событий на подбор предмета
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<UpgradeController>().UpgradeUpdate += NextLevel;
    }

    public void NextLevel() {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        _pointIndexAreaLeft.GetComponent<SpriteRenderer>().sprite = _indexArrow;
        _pointIndexAreaRight.GetComponent<SpriteRenderer>().sprite = _indexArrow;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            try {
                SaveProgress.CurrentPrigress.UpdateLevelCounter();
                SaveProgress.Saveing(SaveProgress.CurrentPrigress);
                SceneManager.LoadScene("SecondLevelScene");
            } catch (Exception ex) {
                Debug.LogException(ex);
            }
        }
    }
}
