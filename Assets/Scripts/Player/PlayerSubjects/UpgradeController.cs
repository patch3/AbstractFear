using System;
using UnityEngine;

public class UpgradeController : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        foreach (Type upgrade in SaveProgress.CurrentPrigress.ListUpgrade)
            gameObject.AddComponent(upgrade);
    }

    public delegate void UpgradeControllerEvent();
    public event UpgradeControllerEvent UpgradeUpdate;

    private void ActivateUpdate(Type upgrade) {
        gameObject.AddComponent(upgrade);
        SaveProgress.CurrentPrigress.ListUpgrade.Add(upgrade);
        UpgradeUpdate?.Invoke();
    }

    

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Upgrade")) {
            ActivateUpdate(
                Type.GetType(
                    collision.gameObject.GetComponent<UpgradeObject>().ScriptName
                    )
                );
            Destroy(collision.gameObject);
        }
    }
}