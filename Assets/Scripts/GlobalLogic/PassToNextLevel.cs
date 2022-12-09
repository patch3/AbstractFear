using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassToNextLevel : MonoBehaviour{

    [SerializeField] private Sprite _indexArrow;

    [SerializeField] private GameObject _pointIndexAreaLeft;
    [SerializeField] private GameObject _pointIndexAreaRight;


    // Start is called before the first frame update
    void Start(){
        // ïðèâÿçûâàþ îáðàáîò÷èê ñîáûòèé íà ïîäáîð ïðåäìåòà
        UpgradeObject.UpgradeSelected += ÑrutchNextLevel;
    }
    public void ÑrutchNextLevel(Type T) => NextLevel();
    public void NextLevel() {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        _pointIndexAreaLeft.GetComponent<SpriteRenderer>().sprite = _indexArrow;
        _pointIndexAreaRight.GetComponent<SpriteRenderer>().sprite = _indexArrow;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            SceneManager.LoadScene("SecondLevelScene");
        }
    }
}
