using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour{

    private static List<Type> _listUpgrade = new();
    /// <summary>
    /// первый байт - Confidence
    /// </summary>


    // Start is called before the first frame update
    void Start(){
        foreach (Type upgrade in _listUpgrade)
            gameObject.AddComponent(upgrade);
        UpgradeObject.UpgradeSelected += EventActivateUpdate;
    }

    private void EventActivateUpdate(Type upgrade) {
        gameObject.AddComponent(upgrade);
        _listUpgrade.Add(upgrade);
    }
}
