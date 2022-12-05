using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHope : MonoBehaviour {
    [SerializeField] private Image[] _hope;
    [SerializeField] private Sprite _complete;
    [SerializeField] private Sprite _empty;

    public int Hp { get; protected set; }

    [SerializeField] public float _startTimeImmortality = 2; 
    private float _timeImmortality = 0; 

    public int GetLength() {
        return _hope.Length;
    }

    // Start is called before the first frame update
    void Start(){
        Hp = _hope.Length;
    }
    void Update() {
        if (_timeImmortality > 0) {
            _timeImmortality -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("EnemyBullet") || collision.CompareTag("Enemy") && _timeImmortality <= 0) {
            _timeImmortality = _startTimeImmortality;
            --Hp;
            UpdateConvas();
            if (Hp <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void UpdateConvas() {
        for (byte i = 0; i < _hope.Length; ++i) {
            if (i < Hp) {
                _hope[i].sprite = _complete;
            } else {
                _hope[i].sprite = _empty;
            }
        }
    }
    
    public void DealDamage(ushort heath) {
        Hp -= heath;
        UpdateConvas();
        if (Hp <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Hiling(ushort heath) {
        if (Hp > _hope.Length) {
            return;
        }
        Hp += heath;
        UpdateConvas();
    }
}
