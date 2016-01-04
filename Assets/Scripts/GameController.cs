using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;

    public float spawnWait;
    public float startWait;
    public float waveWait;

    /* para textos no modo console
    public GUIText scoreText;
    public GUIText resetText;
    public GUIText gameOverText;
    */

    /* para textos no celular */
    public Text scoreText;
    public GameObject restartButton;
    //public Text resetText;
    public Text gameOverText;

    private bool reset;
    private bool gameOver;

    private int score;

    void Start()
    {        
        reset = false;
        gameOver = false;
        //resetText.text = "";
        restartButton.SetActive(false);
        gameOverText.text = "";
        AddScore(0);
        StartCoroutine( SpawnWaves() );        
    }

    //void Update()
    //{
    //    if(reset)
    //    {
    //        if(Input.GetKeyDown(KeyCode.R))
    //        {
    //            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //            //Application.LoadLevel(Application.loadedLevel);
    //        }
    //    }
    //}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartButton.SetActive(true);
          //      resetText.text = "Press 'R' to restart the game";
                reset = true;
                break;
            }
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER!";
        gameOver = true;
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void RestarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
