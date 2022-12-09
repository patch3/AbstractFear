using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour{
    public float Speed = 1.5f;
    public float Acceleration = 100;

    private Vector2 _direction;
    private Rigidbody2D _body;

    void Start(){
        _body = GetComponent<Rigidbody2D>();
        _body.freezeRotation = true;
        _body.gravityScale = 0;
    }

    void Update(){
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        StartCoroutine(Rotation());
    }

    void FixedUpdate() {
        _body.AddForce(_direction.normalized * _body.mass * Speed * Acceleration);
        if (Mathf.Abs(_body.velocity.x) > Speed) {
            _body.velocity = new Vector2(Mathf.Sign(_body.velocity.x) * Speed, _body.velocity.y);
        } if (Mathf.Abs(_body.velocity.y) > Speed) {
            _body.velocity = new Vector2(_body.velocity.x, Mathf.Sign(_body.velocity.y) * Speed);
        }
    }
    IEnumerator Rotation() {
        Vector2 lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        yield return new WaitForSeconds(0.1f);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
