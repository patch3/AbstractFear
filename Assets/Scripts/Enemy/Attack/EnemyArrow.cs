using System;
using UnityEngine;

public class EnemyArrow : MonoBehaviour{

    public const float Accuracy = 10000.0f;

    public float Speed = 10f;
    private Transform Player;
    
    private float _rotationArrow;
    private Quaternion targeеRotation;
    [SerializeField] private float _speedRotarion = 10.0f;
    [SerializeField] private float DestroyTime = 1.25f;




    private float TempC = 0.5f;


    // Start is called before the first frame update
    void Start(){
        Destroy(gameObject, DestroyTime);
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        _rotationArrow = Mathf.Atan2(Player.position.y - transform.position.y,
        Player.position.x - transform.position.x) * Mathf.Rad2Deg;
        targeеRotation = Quaternion.AngleAxis(_rotationArrow, Vector3.forward);
        // развернуть в обратную сторону от игрока
        transform.rotation = Quaternion.AngleAxis(_rotationArrow + 180f, Vector3.forward);
    }

    // Update is called once per frame
    void Update(){
        if (TempC > 0) {
            TempC -= Time.deltaTime;
            return;
        }
        
        Debug.Log("w = "+ transform.rotation.w + " z = " + transform.rotation.z * Accuracy);

        if (Convert.ToInt32(transform.rotation.w * Accuracy) != Convert.ToInt32(targeеRotation.w * Accuracy) ||
            Convert.ToInt32(transform.rotation.z * Accuracy) != Convert.ToInt32(targeеRotation.z * Accuracy)) {
            Quaternion step = Quaternion.Slerp(transform.rotation, targeеRotation, _speedRotarion * Time.deltaTime);
            transform.rotation = step;
        } else {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) Destroy(gameObject); // удаляем если пуля пересекла цель
    }
}
