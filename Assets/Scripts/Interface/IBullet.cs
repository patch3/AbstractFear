using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet: MonoBehaviour {
    protected virtual float Speed { get; set; }
    public virtual float Damage {  get;  set; }
    protected virtual float DestroyTime { get; set; }
}
