using UnityEngine;

public class Roomenemyspawn : MonoBehaviour
{
    public int RandEnem;
    [SerializeField] private Transform Object;
    public GameObject enemy;
    void Start()
    {
        Instantiate(enemy, Object.position, Quaternion.identity);
    }

    void Update()
    {

    }

    public void Reward()
    {
        
    }
}
