using UnityEngine;

public class BossEnemyEye : MonoBehaviour {
    [SerializeField] private float _timeShots = 0.4f;
    [SerializeField] private float _firstStageTimeShots = 0.35f;
    [SerializeField] private float _secondStageTimeShots = 0.3f;
    [SerializeField] private float _deathStageTimeShots = 0.2f;
    
    [SerializeField] private float _timeEye = 0.5f;
    [SerializeField] private float _firstStageTimeEye = 0.45f;
    [SerializeField] private float _secondStageTimeEye = 0.4f;
    [SerializeField] private float _deathStageTimeEye = 0.3f;
    

    private float _timeBtwShots = 2;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _enemyBullet;

    private Vector3 _vMinСamera;// вектор нижнего левого угла камеры
    private Vector3 _vMaxCamera;//Получаем верхний правый угол камеры

    private Transform _plyer;
    private EnemyHealth _health;

    private ushort _countAttack = 0; //счетчик для последовательных аттак
    private ushort _numRemaingAttack = 0;
    private bool _attacking = false;

    [SerializeField] private ushort _numShotsAttacks = 10;
    [SerializeField] private ushort _startNumEyesAttacks = 1;

    private _delegateAttack[] _attacksDelegate;
    private delegate void _delegateAttack();

    private bool _firstStage = false;
    private bool _secondStage = false;
    private bool _deathStage = false;

   

    // Start is called before the first frame update
    void Start() {
        _vMinСamera = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        _vMaxCamera = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));   //Получаем верхний правый угол камеры

        _attacksDelegate = new _delegateAttack[2];
        _attacksDelegate[0] = AttackShots;
        _attacksDelegate[1] = null;

        _plyer = GameObject.FindGameObjectWithTag("Player").transform;
        _health = gameObject.GetComponent<EnemyHealth>();

        _health.EventHpUpdate += CheckNumHp; // добавляем обработчик событий
    }
    // Update is called once per frame
    void FixedUpdate() {
        if (_timeBtwShots <= 0) {
            if (_attacksDelegate[_countAttack] != null)
                _attacksDelegate[_countAttack](); // Атакуем!
            else {
                _countAttack = 0;
                _attacksDelegate[_countAttack]();
            }
            --_numRemaingAttack;
            if (_numRemaingAttack == 0) {
                _attacking = false;
                if (_countAttack >= _attacksDelegate.Length - 1) {
                    _countAttack = 0;
                } else ++_countAttack;
            }
        } else {
            _timeBtwShots -= 0.02f;
        }
    }
    
    // обработчик события изменения Hp
    private void CheckNumHp(float hp) {
        if (hp < 75 && !_firstStage) {
            // с новой стадией добавляем новую аттаку
            _attacksDelegate[1] = AttackEye;
            _timeShots = _firstStageTimeShots;
            _timeEye = _firstStageTimeEye;
            _firstStage = true;
        } if (hp < 50 && !_secondStage) {
            _timeShots = _secondStageTimeShots;
            _timeEye = _secondStageTimeEye;
            _secondStage = true;
        } if (hp < 10 && !_deathStage) {
            _timeShots = _deathStageTimeShots;
            _timeEye = _deathStageTimeEye;
            _deathStage = true;
        }
    }

    /* АТАКИ */

    // аттака пулей
    private void AttackShots() {
        if (!_attacking) {
            _numRemaingAttack = _numShotsAttacks;
            //_firstStageTimeShots = 
            _attacking = true;
        }
        _timeBtwShots = _timeShots;
        Instantiate(_bullet, transform.position, Quaternion.identity);
    }

    // аттака следящей пулей
    private void AttackEye() {
        if (!_attacking) {
            _numRemaingAttack = _startNumEyesAttacks;
            _attacking = true;
        }
        _timeBtwShots = _timeEye;
        Vector2 placeSpawn;
        if (_plyer.position.x < 0) {
            placeSpawn = new Vector2(_vMaxCamera.x + 2, _vMaxCamera.y);
        } else {
            placeSpawn = new Vector2(_vMinСamera.x - 2, _vMaxCamera.y);
        }
        Instantiate(_enemyBullet, placeSpawn, Quaternion.identity);
    }

    /*public void ShotThePlayer() {
        Instantiate(_bullet, transform.position, );
    }*/
}

