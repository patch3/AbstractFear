using UnityEngine;
public class EnemyShooting : MonoBehaviour{
    public float Speed;
    public float DestroyTime;

    private Transform Player;
//    private Vector2 Target;

    // Start is called before the first frame update
    void Start(){
        Destroy(gameObject, DestroyTime);
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        //Target = _playerTarget.position;
        //Target = new Vector2(_playerTarget.position.x - transform.position.x, _playerTarget.position.y - transform.position.y);

        transform.rotation = QuaternionTurn(Player);
    }

    // Update is called once per frame
    void FixedUpdate(){
        transform.Translate(Vector2.right * Speed * 0.02f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) Destroy(gameObject); // удаляем если пуля пересекла цель
    }

    private Quaternion QuaternionTurn(Transform other) {
        return Quaternion.AngleAxis(
           Mathf.Atan2(other.position.y - transform.position.y,
           other.position.x - transform.position.x) * Mathf.Rad2Deg,
           Vector3.forward);
    }
}
