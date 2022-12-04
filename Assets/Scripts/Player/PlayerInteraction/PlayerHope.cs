using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHope : MonoBehaviour {
    [SerializeField] private Image[] _hope;
    [SerializeField] private Sprite _complete;
    [SerializeField] private Sprite _empty;

    private int _hp;

    [SerializeField] public float _startTimeImmortality = 2; 
    private float _timeImmortality = 0; 

    // Start is called before the first frame update
    void Start(){
        _hp = _hope.Length;
    }
    void Update() {
        if (_timeImmortality > 0) {
            _timeImmortality -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("EnemyBullet") || collision.CompareTag("Enemy") && _timeImmortality <= 0) {
            _timeImmortality = _startTimeImmortality;
            --_hp;
            for (byte i = 0; i < _hope.Length; ++i) {
                if (i < _hp) {
                    _hope[i].sprite = _complete;
                } else {
                    _hope[i].sprite = _empty;
                }
            }
            if (_hp <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision) {
        
    }*/
    public void DealDamage() {

    }
}
