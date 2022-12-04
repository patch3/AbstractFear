using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour{
    public Image Bar;

    [SerializeField] protected float hp = 100f;
    private float Fill = 1f;

    // ��������� ���� � ���������� ��
    public void DealDamage(float damage) {
        Fill -= damage / hp;
        HpBarUpdate();
    }
    // ��������� ����� � ���������� ��
    public void DealHealing(float healing) {
        Fill += healing / hp;
        HpBarUpdate();
    }
    // ����������� �� ��� ����
    public void HpBarUpdate() {
        Bar.fillAmount = Fill;
        if (Fill <= 0) Destroy(gameObject);
    }

}
