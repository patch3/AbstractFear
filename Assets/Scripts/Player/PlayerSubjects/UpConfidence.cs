using UnityEngine;

public class UpConfidence : MonoBehaviour{
    private const float _reduceTimeShot = 0.1f;
    private const float _speedUp = 0.5f;

    // Start is called before the first frame update
    void Start() {
        gameObject.GetComponent<PlayerShooting>().StartTimeShot -= _reduceTimeShot;
        gameObject.GetComponent<PlayerMove>().Speed += _speedUp;

    }
}
