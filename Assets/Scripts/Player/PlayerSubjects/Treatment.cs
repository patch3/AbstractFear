using UnityEngine;

public class Treatment : MonoBehaviour{

    [SerializeField] protected float DestroyTime = 5f;

    void Start() {
        Destroy(gameObject, DestroyTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            PlayerHope hope = other.gameObject.GetComponent<PlayerHope>();
            hope.Hiling(1);
            Destroy(gameObject);
        }; // удаляем если пуля пересекла цель
    }
}
