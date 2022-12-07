using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public Image Bar;

    [SerializeField] protected float hp = 100f;
    private float Fill = 1f;

    public delegate void HpHendler(float hp);
    public event HpHendler EventHpUpdate;
    public delegate void Death();
    public event Death EventDeathEnemy;

    // ��������� ���� � ���������� ��
    public void DealDamage(float damage) {
        Fill -= damage / hp;
        HpBarUpdate();
        if (EventHpUpdate != null) EventHpUpdate(Fill * 100f);
    }
    // ��������� ����� � ���������� ��
    public void DealHealing(float healing) {
        Fill += healing / hp;
        HpBarUpdate();
        if (EventHpUpdate != null) EventHpUpdate(Fill * 100f);
    }
    // ����������� �� ��� ����
    public void HpBarUpdate() {
        Bar.fillAmount = Fill;
        if (Fill <= 0) {
            EventDeathEnemy();
            Destroy(gameObject);
        }
    }

    
}
