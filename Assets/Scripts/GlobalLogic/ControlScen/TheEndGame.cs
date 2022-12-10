using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEndGame : MonoBehaviour{

    [SerializeField] private Sprite _indexArrow;

    [SerializeField] private GameObject _pointIndexAreaLeft;
    [SerializeField] private GameObject _pointIndexAreaRight;

    [SerializeField] private GameObject _boss;


    // Start is called before the first frame update
    void Start() {
        // Û·ËÈÒÚ‚Ó ·ÓÒÒ‡
        _boss.GetComponent<EnemyHealth>().EventDeathEnemy += NextLevel;
    }
    public void —rutchNextLevel(Type T) => NextLevel();
    public void NextLevel() {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        _pointIndexAreaLeft.GetComponent<SpriteRenderer>().sprite = _indexArrow;
        _pointIndexAreaRight.GetComponent<SpriteRenderer>().sprite = _indexArrow;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            SceneManager.LoadScene("RecordScene");
        }
    }
}

