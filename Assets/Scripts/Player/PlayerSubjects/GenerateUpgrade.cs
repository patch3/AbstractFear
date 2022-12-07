using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyHealth;

public class GenerateUpgrade : MonoBehaviour{

    private EnemyHealth _health;

    [SerializeField] private GameObject _upgrade;

    // Start is called before the first frame update
    void Start(){
        _health = gameObject.GetComponent<EnemyHealth>();
        _health.EventDeathEnemy += SpawnItem;
    }

    private void SpawnItem() {
        Instantiate(_upgrade, gameObject.transform.position, Quaternion.identity);
    }

}
