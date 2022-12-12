using UnityEngine;

public class TrackingBullet : MonoBehaviour {
    protected float Speed { get; set; }
    public float Damage { protected get; set; }
    protected float DestroyTime { get; set; }

    private Vector2 _target;
    private Transform _player;
    private SpriteRenderer _sprite;


    // Start is called before the first frame update
    void Start() {
        Speed = 2;
        Damage = 1;
        DestroyTime = 20;

        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _sprite = GetComponent<SpriteRenderer>();

        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, _player.position, Speed * Time.deltaTime);
        _target = new Vector2(_player.position.x - transform.position.x, _player.position.y - transform.position.y);

        // поворот объекта
        if (!_sprite.flipX && _target.x > 0 || _sprite.flipX && _target.x < 0) {
            _sprite.flipX = !_sprite.flipX;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (other.CompareTag("Player")) {
                PlayerHope hope = other.gameObject.GetComponent<PlayerHope>();
                hope.DealDamage(1);
                Destroy(gameObject); // удаляем если пуля пересекла цель
            }
        }
    }
}
