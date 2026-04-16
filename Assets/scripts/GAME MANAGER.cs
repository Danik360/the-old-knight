using UnityEngine;
using UnityEngine.UI;

public class GAMEMANAGER : MonoBehaviour
{
    [SerializeField] Reward RoomRew;
    [SerializeField] Roomenemyspawn RoomSpawn;
    public int EnemDie;
    public GameObject GameStartCanvas;
    void Start()
    {
        Time.timeScale = 0;
        GameStartCanvas.SetActive(true);
    }

    void Update()
    {

    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        GameStartCanvas.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CountKill()
    {
        EnemDie += 1;
        if (EnemDie == RoomRew.CountEnemy)
        {
            RoomRew.RewardPlay();
        }
    }
}
