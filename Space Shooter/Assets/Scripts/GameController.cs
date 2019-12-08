using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public BGSCroller scrollerScript;
    public ParticleSpeed particleScript;
    public ParticleSpeed particleScript2;
    public AudioSource musicSource;
    public AudioClip clipOne;
    public AudioClip clipTwo;
    public Mover moveScript;
    public Mover moveScript2;
    public Mover moveScript3;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text hardMode;

    private int score;
    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        hardMode.text = "Press 'H' for Hard Mode";
        moveScript.speed = -5;
        moveScript2.speed = -5;
        moveScript3.speed = -5;
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.F))
            {
                SceneManager.LoadScene("main");
            }

        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (score >= 100)
        {
            Destroy(GameObject.FindWithTag("Enemy"));
            Destroy(GameObject.FindWithTag("Pickup"));
            hardMode.text = "";
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            moveScript.speed = -15;
            moveScript2.speed = -15;
            moveScript3.speed = -15;
            hardMode.text = "HARD MODE";
        }
    }

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
                restartText.text = "Press 'F' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            winText.text = "You win! Created By Raymond Boysel";
            gameOver = true;
            restart = true;
            scrollerScript.scrollSpeed -= 50;
            particleScript.hSliderValue += 250;
            particleScript2.hSliderValue += 250;
            musicSource.clip = clipOne;
            musicSource.Play();
        }
    }
    public void GameOver()
    {
        hardMode.text = "";
        gameOverText.text = "Game Over! Created By Raymond Boysel";
        gameOver = true;
        musicSource.clip = clipTwo;
        musicSource.Play();
    }
}