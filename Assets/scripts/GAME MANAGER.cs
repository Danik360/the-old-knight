using UnityEngine;
using UnityEngine.UI;

public class GAMEMANAGER : MonoBehaviour
{
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
}
