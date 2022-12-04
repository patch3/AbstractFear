using UnityEngine;
public class EnemyObj : MonoBehaviour
{
    public float StartTimeBtwShots = 1.22f;
    private float TimeBtwShots = 2;

    public GameObject ProjecTile;
    private Vector3 _vMin�amera;// ������ ������� ������ ���� ������
    private Vector3 _vMaxCamera;//�������� ������� ������ ���� ������
    private Transform Plyer = GameObject.FindGameObjectWithTag("Player").transform;



    // Start is called before the first frame update
    void Start(){
        _vMin�amera = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        _vMaxCamera = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));   //�������� ������� ������ ���� ������

        Plyer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update(){
        if (TimeBtwShots <= 0) {
            Instantiate(ProjecTile, transform.position, Quaternion.identity);
            TimeBtwShots = StartTimeBtwShots;
        } else {
            TimeBtwShots -= Time.deltaTime;
        }
    }

    /*public void ShotThePlayer() {
        Instantiate(ProjecTile, transform.position, );
    }*/
}

