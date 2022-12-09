using System;
using UnityEngine;

public class UpgradeObject : MonoBehaviour{

    [SerializeField] private string _ScriptName;

    public delegate void UpgradeEvent(Type typeUpgrade);
    public static event UpgradeEvent UpgradeSelected;
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (UpgradeSelected != null)
                UpgradeSelected(Type.GetType(_ScriptName));
            Destroy(gameObject);
        }
    }
}
