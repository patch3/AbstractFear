using UnityEngine;

public class PlayerShooting : MonoBehaviour{

    [SerializeField] private GameObject _ammo;
    [SerializeField] private Transform _shotDir;

    public float StartTimeShot = 1f;
    private float _timeShot = 0;
    
    // Update is called once per frame
    void Update(){
        if (_timeShot <= 0){
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space)) {
                Instantiate(_ammo, _shotDir.position, transform.rotation);
                _timeShot = StartTimeShot;
            }
        }else{
            _timeShot -= Time.deltaTime;
        }
    }
}
