using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] RandomRocks;
    private int RocksCount;
    public GameObject[] Memories;
    public GameObject enemy;
    public Vector3 Positionforspawn;
    void Start()
    {
        RocksCount = Random.Range(13, 40);

        for (int i = 0; i < RocksCount; i++)
        {
            GameObject R = RandomRocks[Random.Range(0, RandomRocks.Length)];
            Vector2 PositionRocksSpawn = new Vector2(Random.Range(-56, 56), Random.Range(-50, 50));
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            GameObject newRock = Instantiate(R, PositionRocksSpawn, randomRotation);

            float randomScale = Random.Range(2.5f, 6f);
            newRock.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }


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

    void EnemySpawn()
    {
        Vector3 Positionforspawn = new Vector3(Random.Range(-56, 56), Random.Range(-50, 50), 0);
        Instantiate(enemy, Positionforspawn, Quaternion.identity);
    }
}
