using UnityEngine;

public class PlayerShooting : MonoBehaviour{

    public GameObject ammo;
    public Transform shotDir;

    public float startTime;
    private float timeShot = 0;
    
    // Update is called once per frame
    void Update(){
        if (timeShot <= 0){
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space)) {
                Instantiate(ammo, shotDir.position, transform.rotation);
                timeShot = startTime;
            }
        }else{
            timeShot -= Time.deltaTime;
        }
    }
}
