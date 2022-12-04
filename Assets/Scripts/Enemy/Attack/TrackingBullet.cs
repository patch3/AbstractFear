using UnityEngine;

public class TrackingBullet : MonoBehaviour {
    protected float Speed { get; set; }
    public float Damage { protected get; set; }
    protected float DestroyTime { get; set; }

    private bool _turnRight = false;
    private Vector2 _target;
    private Transform _player; 

    // Start is called before the first frame update
    void Start() {
        Speed = 2;
        Damage = 1;
        DestroyTime = 20;

        _player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, _player.position, Speed * Time.deltaTime);
        _target = new Vector2(_player.position.x - transform.position.x, _player.position.y - transform.position.y);

        // поворот объекта
        if (!_turnRight && _target.x > 0 || _turnRight && _target.x < 0) { 
            _turnRight = !_turnRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) Destroy(gameObject); // удаляем если пуля пересекла цель

    }
}
