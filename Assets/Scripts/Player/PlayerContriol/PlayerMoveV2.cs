using System.Collections;
using UnityEngine;

public class PlayerMoveV2 : MonoBehaviour
{
    public float speed = 1.5f;
    public float acceleration = 100;

    private Vector2 direction;
    private Rigidbody2D body;

    void Start(){
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        body.gravityScale = 0;
    }

    void Update(){
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        StartCoroutine(Rotation());
    }

    void FixedUpdate() {
        body.AddForce(direction.normalized * body.mass * speed * acceleration);
        if (Mathf.Abs(body.velocity.x) > speed) {
            body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed, body.velocity.y);
        } if (Mathf.Abs(body.velocity.y) > speed) {
            body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed);
        }
    }
    IEnumerator Rotation() {
        Vector2 lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        yield return new WaitForSeconds(0.1f);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
