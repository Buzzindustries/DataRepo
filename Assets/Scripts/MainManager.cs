
using UnityEngine;

using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;
    

    public Text ScoreText;
    public Text HighScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = $"{GameManager.GM.GetName()} : Score : {m_Points}";
        HighScoreText.text = GameManager.GM.GethighscoreString();
    

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, i * 0.3f, 10);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SecenesManager.SM.LoadScene(0);
            }

        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"{GameManager.GM.GetName()} : Score : {m_Points}";

        if (m_Points > GameManager.GM.GetHighScore())
        { 
            GameManager.GM.SetHighscore($"Highscore : {GameManager.GM.GetName()} : {m_Points}", m_Points);
            HighScoreText.text = $"Highscore : {GameManager.GM.GetName()} : {m_Points}";            
        }
        else return;
    }

    public void GameOver()
    {
        GameManager.GM.Savehighscore();
        m_GameOver = true;
        GameOverText.SetActive(true);
    }
}
