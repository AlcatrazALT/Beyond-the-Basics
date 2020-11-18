using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    internal float playerSpeed;

    [SerializeField]
    public Vector3 screenBounds;

    [SerializeField]
    public EnemyController enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
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

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            yield return wait;
        }
    }

    public void KillObject(IKillable killable)
    {
        Debug.LogWarningFormat("{0} killed by Game Scene Controller", killable.GetName());
        killable.Kill();
    }
}
