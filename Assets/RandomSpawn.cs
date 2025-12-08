using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] Memories;
    public GameObject enemy;
    public Vector3 Positionforspawn;
    void Start()
    {
        InvokeRepeating("EnemySpawn", 2, 1);

        // 1 Memories Support
        Vector2 PositionToSpawn1 = new Vector2(Random.Range(1, 56), Random.Range(-1, -50));
        Instantiate(Memories[0], PositionToSpawn1, Quaternion.identity);

        // 2 Memories Support
        Vector2 PositionToSpawn2 = new Vector2(Random.Range(-1, -56), Random.Range(-1, -50));
        Instantiate(Memories[1], PositionToSpawn2, Quaternion.identity);

        // 3 Memories Support
        Vector2 PositionToSpawn3 = new Vector2(Random.Range(1, 56), Random.Range(1, 50));
        Instantiate(Memories[2], PositionToSpawn3, Quaternion.identity);

        // 4 Memories Support
        Vector2 PositionToSpawn4 = new Vector2(Random.Range(-1, -56), Random.Range(1, 50));
        Instantiate(Memories[3], PositionToSpawn4, Quaternion.identity);
    }

    void Update()
    {

    }

    void EnemySpawn()
    {
        Vector3 Positionforspawn = new Vector3(Random.Range(-56, 56), Random.Range(-50, 50), 0);
        Instantiate(enemy, Positionforspawn, Quaternion.identity);
    }
}
