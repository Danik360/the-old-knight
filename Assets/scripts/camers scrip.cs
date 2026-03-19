using UnityEngine;

public class camersscrip : MonoBehaviour
{
    private Vector2 PlayerLastPos;
    [SerializeField] Movement Move;
    void Start()
    {
        
    }

    void Update()
    {
        PlayerLastPos = Move.transform.position;

        // камера не должна быть точно в его позиции по z,
        // обычно в 2D у камеры z = -10
        Vector3 cameraPos = PlayerLastPos;
        cameraPos.z = transform.position.z; // или просто -10

        transform.position = cameraPos;
    }
}
