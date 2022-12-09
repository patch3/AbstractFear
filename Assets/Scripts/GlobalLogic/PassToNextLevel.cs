using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassToNextLevel : MonoBehaviour{

    [SerializeField] private Sprite _indexArrow;

    [SerializeField] private GameObject _pointIndexAreaLeft;
    [SerializeField] private GameObject _pointIndexAreaRight;


    // Start is called before the first frame update
    void Start(){
        // ���������� ���������� ������� �� ������ ��������
        UpgradeObject.UpgradeSelected += �rutchNextLevel;
    }
    public void �rutchNextLevel(Type T) => NextLevel();
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
