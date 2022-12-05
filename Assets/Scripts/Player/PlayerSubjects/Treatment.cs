using UnityEngine;

public class Treatment : MonoBehaviour{
    [SerializeField] private GameObject _maxAngle;
    [SerializeField] private GameObject _minAngle;

    [SerializeField] private GameObject _subjectTreatMent;

    [SerializeField] private float _startTimeSpawn = 15f;
    [SerializeField] private float _timeSpawn = 20f;

    // Update is called once per frame
    void FixedUpdate(){
        if (_timeSpawn <= 0) {

        } else {
            _timeSpawn -= 0.02f;
        }
    }
}
