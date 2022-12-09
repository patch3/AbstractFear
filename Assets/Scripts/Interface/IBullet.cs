using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface Bullet {
    protected abstract float Speed { get; set; }
    public abstract float Damage { get; set; }
    protected abstract float DestroyTime { get; set; }
}
