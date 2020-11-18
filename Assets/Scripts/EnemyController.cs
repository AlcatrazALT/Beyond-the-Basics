using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Shape, IKillable
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Name = "Enemy";
        Debug.Log("Enemy Spawned");
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector2.down * Time.deltaTime, Space.World);
        var bottom = transform.position.y - halfHeight;

        if (bottom < -gameSceneController.screenBounds.y)
        {
            gameSceneController.KillObject(this);
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public string GetName()
    {
        return Name;
    }
}
