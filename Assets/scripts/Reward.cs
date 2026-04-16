using UnityEngine;

public class Reward : MonoBehaviour
{
    public int CountEnemy;
    public GameObject objectToHide;
    public bool OpenChest;
    void Start()
    {
        objectToHide.SetActive(false);
    }

    void Update()
    {

    }

    public void RewardPlay()
    {
        objectToHide.SetActive(true);
    }
    // сделать систему выдачи награды через колизию
}
