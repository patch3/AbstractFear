using UnityEngine;

public class BigBoss : MonoBehaviour {
    [SerializeField] private float _timeShots = 0.4f;
    [SerializeField] private float _firstStageTimeShots = 0.35f;
    [SerializeField] private float _secondStageTimeShots = 0.3f;
    [SerializeField] private float _deathStageTimeShots = 0.2f;

    [SerializeField] private float _timeArrow = 0.2f;
    [SerializeField] private float _firstStageTimeArrow = 0.15f;
    [SerializeField] private float _secondStageTimeArrow = 0.1f;
    [SerializeField] private float _deathStageTimeArrow = 0.05f;

    private float _timeBtwShots = 2;    


    [SerializeField] private GameObject _arrow;
    [SerializeField] private GameObject _bullet;

    private Vector3 _playerTarget;
    private EnemyHealth _health;

    private Vector3 _lastStepRot;

    private ushort _countAttack = 0; //счетчик для последовательных аттак
    private ushort _numRemaingAttack = 0;
    private bool _attacking = false;

    private bool _firstStage = false;
    private bool _secondStage = false;
    private bool _deathStage = false;

   // private Vector3 _vMinСamera;// вектор нижнего левого угла камеры
    //private Vector3 _vMaxCamera;//Получаем верхний правый угол камеры

    private DelegateAttack[] _attacksDelegate;
    private delegate void DelegateAttack();

    // Start is called before the first frame update
    void Start() {
        //_vMinСamera = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
       // _vMaxCamera = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));   //Получаем верхний правый угол камеры

        _attacksDelegate = new DelegateAttack[6];
        _attacksDelegate[0] = AttackShots;
        _attacksDelegate[1] = AttackArrowUnder90;

        
        _health = gameObject.GetComponent<EnemyHealth>();

        _health.EventHpUpdate += CheckNumHp; // добавляем обработчик событий
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (_timeBtwShots > 0) {
            _timeBtwShots -= 0.02f;
            return;
        }
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
        //*Debug.Log(VRot.ToString());*//*
    }

    // обработчик события изменения Hp
    private void CheckNumHp(float hp) {
        if (hp < 75 && !_firstStage) {
            // с новой стадией добавляем новую аттаку
            _attacksDelegate[2] = AttackShots;
            _attacksDelegate[3] = AttackArrowUnder45;
            _timeShots = _firstStageTimeShots;
            _timeArrow = _firstStageTimeArrow;
            _firstStage = true;
        }
        if (hp < 50 && !_secondStage) {
            _attacksDelegate[3] = AttackShots;
            _attacksDelegate[4] = СircularAttack;
            _timeShots = _secondStageTimeShots;
            _timeArrow = _secondStageTimeArrow;
            _secondStage = true;
        }
        if (hp < 10 && !_deathStage) {
            _timeShots = _deathStageTimeShots;
            _timeArrow = _deathStageTimeArrow;
            _deathStage = true;
        }
    }

    [SerializeField] private ushort _numShotsAttacks = 10;
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

    private const float RADIUS_ATTACK = 3f;

    // длинна хорды по синусу заданного угла, которую мы принимаем как радиус второй окружности
    private const float SIN_ROTATE_FOR_CHORD_90 = 0.70710678118654752440084436210485f; // sin(90/2)
    private const float CHORD_LENGTH_90 = 2 * RADIUS_ATTACK * SIN_ROTATE_FOR_CHORD_90;
    private const float POINT_VECTOR_UNDER_45 = 0.70710678118654752440084436210485f;

    private const ushort NUM_ARROW_ATTACK_UNDER_90 = 4;

    private void AttackArrowUnder90() {
        if (!_attacking) {
            Debug.Log("CircularArrowAttack!");
            _playerTarget = GameObject.FindGameObjectWithTag("Player").transform.position;
            _lastStepRot = new Vector2(-POINT_VECTOR_UNDER_45, POINT_VECTOR_UNDER_45) * RADIUS_ATTACK;
            GenerateVectorForArrow(CHORD_LENGTH_90);
            _numRemaingAttack = NUM_ARROW_ATTACK_UNDER_90;
            _timeBtwShots = _timeArrow;
            _attacking = true;
            return;
        }
        GenerateVectorForArrow(CHORD_LENGTH_90);
    }


    private const float SIN_ROTATE_FOR_CHORD_45 = 0.3826834323650897717284599840304f;
    private const float CHORD_LENGTH_45 = 2 * RADIUS_ATTACK * SIN_ROTATE_FOR_CHORD_45;

    private const ushort NUM_ARROW_ATTACK_UNDER_45 = 8;

    private void AttackArrowUnder45() {
        if (!_attacking) {
            Debug.Log("CircularArrowAttack!");
            _playerTarget = GameObject.FindGameObjectWithTag("Player").transform.position;
            _lastStepRot = new Vector2(-POINT_VECTOR_UNDER_45, POINT_VECTOR_UNDER_45) * RADIUS_ATTACK;
            GenerateVectorForArrow(CHORD_LENGTH_45);
            _numRemaingAttack = NUM_ARROW_ATTACK_UNDER_45;
            _timeBtwShots = _timeArrow;
            _attacking = true;
            return;
        }
        GenerateVectorForArrow(CHORD_LENGTH_90);
    }

    private const float SIN_ROTATE_FOR_CHORD_20 = 0.17364817766693034885171662676931f; // sin(20/2)
    private const float CHORD_LENGTH_20 = 2 * RADIUS_ATTACK * SIN_ROTATE_FOR_CHORD_20;

    private const ushort NUM_ARROW_ATTACK_CIRCULAR = 18;

    private void СircularAttack() {
        if (!_attacking) {
            Debug.Log("CircularArrowAttack!");
            _playerTarget = GameObject.FindGameObjectWithTag("Player").transform.position;
            _lastStepRot = new Vector2(0, RADIUS_ATTACK);
            GenerateVectorForArrow(CHORD_LENGTH_20);
            _numRemaingAttack = NUM_ARROW_ATTACK_CIRCULAR;
            _timeBtwShots = _timeArrow;
            _attacking = true;
            return;
        }
        GenerateVectorForArrow(CHORD_LENGTH_20);
    }

    private void GenerateVectorForArrow(float chortLength) {
        //_lastStepRot = VGeneration;
        float a = (2*(RADIUS_ATTACK*RADIUS_ATTACK) - chortLength * chortLength) / (2 * RADIUS_ATTACK);
        Debug.Log("a = " + a + ", chortLength = " + chortLength + ",  h = Sqrt(" + (chortLength * chortLength - a * a) + ")");

        // Вектор указы вающий на точку под точками пересечения окружности
        Vector3 p3 = Vector3.zero + (a / RADIUS_ATTACK) * (_lastStepRot);

        float h = Mathf.Sqrt(RADIUS_ATTACK * RADIUS_ATTACK - a * a);
        Debug.Log("h = " + h);

        float x = p3.x - (h / RADIUS_ATTACK) * (_lastStepRot.y - Vector3.zero.y);
        Debug.Log("x = " + x);
        float y = p3.y + (h / RADIUS_ATTACK) * (_lastStepRot.x - Vector3.zero.x);
        Debug.Log("y = " + y);

        Vector3 VRot = new Vector3(x, y);
        _lastStepRot = VRot;

        Instantiate(_arrow, _playerTarget + VRot, Quaternion.identity);
    }

}