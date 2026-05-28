using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyCount;

    public float timeLimit = 5f;
    private float timer;
    private bool isPlaying = false;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void Update()
    {
        if (!isPlaying) return;

        timer += Time.deltaTime;

        if (timer >= timeLimit)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        isPlaying = true;
        timer = 0f;
    }

    public void EnemyDefeated()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            GameClear();
        }
    }

    void GameClear()
    {
        Debug.Log("クリア！");
        SceneManager.LoadScene("ResultScene");
    }

    void GameOver()
    {
        Debug.Log("ゲームオーバー");
        SceneManager.LoadScene("GameOverScene");
    }
}