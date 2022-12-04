using UnityEngine;

public class TestEnemyObj : MonoBehaviour {
    private const float RADIUS_ATTACK = 5f;
    public const float RADIAN = 57.295779513082320876798154814105f;
    private const float SIN_ROTATE_FOR_CHORD_45 = 0.3826834323650897717284599840304f; // sin(45/ 2)
    // длинна хорды по синусу заданного угла, которую мы принимаем как радиус второй окружности
    private const float CHORD_LENGTH = 2 * RADIUS_ATTACK * SIN_ROTATE_FOR_CHORD_45; 

    [SerializeField] private float StartTimeBtwShots = 1.22f;
    private float TimeBtwShots = 2;

    public GameObject ProjecTile;
    private Transform Player;

    private Vector3 _lastStepRot;

    [SerializeField] private const ushort NUM_CICULAR_ATTACKS = 6;

    private ushort СountAttack = 0;

    private bool CircularArrowAttack = false;

    // Start is called before the first frame update
    void Start() {

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //Debug.Log(COS_ROTATE);
        //Debug.Log(SIN_ROTATE_FOR_CHORD_45);
        //Debug.Log(CHORD_LENGTH);
    }

    // Update is called once per frame
    void Update() {
        if (!CircularArrowAttack) {
            Debug.Log("CircularArrowAttack!");
            _lastStepRot = new Vector3(0, RADIUS_ATTACK);
            GenerateVectorForArrow();
            CircularArrowAttack = true;
            СountAttack = NUM_CICULAR_ATTACKS;
            return;
        }
        GenerateVectorForArrow();
        /*Debug.Log(VRot.ToString());*/
    }

    /*public void ShotThePlayer() {
        Instantiate(ProjecTile, transform.position, );
    }*/

    private void GenerateVectorForArrow() {
        //_lastStepRot = VGeneration;
        float a = (RADIUS_ATTACK * RADIUS_ATTACK - CHORD_LENGTH * CHORD_LENGTH + RADIUS_ATTACK * RADIUS_ATTACK) / (2 * RADIUS_ATTACK);
        Debug.Log("a = " + a + ", CHORD_LENGTH = " + CHORD_LENGTH + ",  h = Sqrt(" + (CHORD_LENGTH * CHORD_LENGTH - a * a) + ")");

        // Вектор указы вающий на точку под точками пересечения окружности
        Vector3 p3 = Vector3.zero + (a / RADIUS_ATTACK) * (_lastStepRot);

        float h = Mathf.Sqrt(RADIUS_ATTACK * RADIUS_ATTACK - a * a);
        Debug.Log("h = " + h);
        float x = p3.x + (h / RADIUS_ATTACK) * (_lastStepRot.y - Vector3.zero.y);
        Debug.Log("x = " + x);
        float y = p3.y - (h / RADIUS_ATTACK) * (_lastStepRot.x - Vector3.zero.x);
        Debug.Log("y = " + y);

        Vector3 VRot = new Vector3(x, y);
        _lastStepRot = VRot;

        Instantiate(ProjecTile, Player.position + VRot, Quaternion.identity);
    }
}

