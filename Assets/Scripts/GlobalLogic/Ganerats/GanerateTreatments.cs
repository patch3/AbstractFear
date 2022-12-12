using UnityEngine;

public class GanerateTreatments : MonoBehaviour{

    [SerializeField] private GameObject _maxAngle;
    [SerializeField] private GameObject _minAngle;

    [SerializeField] private GameObject _subjectTreatMent;

    [SerializeField] private float _startTimeSpawn = 5f;
    [SerializeField] private float _timeSpawn = 10f;



    // Update is called once per frame
    void FixedUpdate() {
        if (_timeSpawn <= 0) {
            float randX = Random.Range(_minAngle.transform.position.x, _maxAngle.transform.position.x);
            float randY = Random.Range(_minAngle.transform.position.y, _maxAngle.transform.position.y);
            Instantiate(_subjectTreatMent, new Vector2(randX, randY), Quaternion.identity);
            _timeSpawn = _startTimeSpawn;
        } else {
            _timeSpawn -= 0.02f;
        }
    }
}
