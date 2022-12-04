using UnityEngine;

public class PlayerArrow : MonoBehaviour{

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _destroyTime = 1.22f;

    [SerializeField] private float _damage = 1;

    // Start is called before the first frame update
    void Start(){
        Destroy(gameObject, _destroyTime);
    }

    // Update is called once per frame
    void FixedUpdate(){
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {// снимаем урон удаляем если пуля попала в противника
        if (other.CompareTag("Enemy")) {
            other.gameObject.GetComponent<EnemyHealth>().DealDamage(_damage);
            Destroy(gameObject);
        };
    }
}
