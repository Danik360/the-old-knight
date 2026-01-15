using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public GameObject Me;
    private Player_attack attack;
    public bool Livestat;
    public int PlayerDamage;
    public int HP = 2;

    void Start()
    {
        PlayerAnim = GameObject.Find("player").GetComponent<Movement>();
        Livestat = true;
        attack = GameObject.Find("forwsrd").GetComponent<Player_attack>();
    }

    void Update()
    {
        PlayerDamage = attack.MyDamage;
    }

    public void TakeDamage()
    {
        Debug.Log("удар по " + gameObject.name); // Показывает имя конкретного врага
        HP -= PlayerDamage;
        if (HP <= 0)
        {
            Livestat = false;
            Debug.Log("Убил " + gameObject.name);
            Destroy(Me);
        }
    }
}