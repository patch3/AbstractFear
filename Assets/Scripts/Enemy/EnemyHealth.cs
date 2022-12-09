using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    [SerializeField] private Image _bar;

    [SerializeField] protected float Hp = 100f;
    private float _fill = 1f;

    public delegate void HpHendler(float hp);
    public event HpHendler EventHpUpdate;
    

    // прощитать урон и отобразить хп
    public void DealDamage(float damage) {
        _fill -= damage / Hp;
        HpBarUpdate();
        if (EventHpUpdate != null) EventHpUpdate(_fill * 100f);
    }
    // прощитать урони и отобразить хп
    public void DealHealing(float healing) {
        _fill += healing / Hp;
        HpBarUpdate();
        if (EventHpUpdate != null) EventHpUpdate(_fill * 100f);
    }
    public delegate void Death();
    public event Death EventDeathEnemy;
    // отображение на хит баре
    public void HpBarUpdate() {
        _bar.fillAmount = _fill;
        if (_fill <= 0) {
            EventDeathEnemy?.Invoke();
            Destroy(gameObject);
        }
    }

    
}
