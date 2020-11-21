using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TextOutputHandler(string text);

public class SceneController : MonoBehaviour
{
    private HUDController hUDController;
    private int totalPoints;


    [SerializeField]
    internal float playerSpeed;

    [SerializeField]
    public Vector3 screenBounds;

    [SerializeField]
    public EnemyController enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        hUDController = FindObjectOfType<HUDController>();
        playerSpeed = 10;
        screenBounds = GetScreenBounds();
        StartCoroutine(SpawnEnemies());
    }

    private Vector3 GetScreenBounds()
    {
        var mainCamera = Camera.main;
        var screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);

        return mainCamera.ScreenToWorldPoint(screenVector);
    }

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSeconds(2);

        while (true)
        {
            var horizontalPosition = UnityEngine.Random.Range(-screenBounds.x, screenBounds.x);
            var spawnPosition = new Vector2(horizontalPosition, screenBounds.y);

            var enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            enemy.EnemyEscaped += EnemyAtBottom;
            enemy.EnemyKilled += EnemyKilled; 

            yield return wait;
        }
    }

    private void EnemyKilled(int pointValue)
    {
        totalPoints += pointValue;
    }

    private void EnemyAtBottom(EnemyController enemy)
    {
        Destroy(enemy.gameObject);
        hUDController.scoreText.text = totalPoints.ToString();
    }

    public void KillObject(IKillable killable)
    {
        killable.Kill();
    }

    public void OutputText(string output)
    {
        Debug.LogFormat("{0} output by Scene Controller", output);
    }
}
