using UnityEngine;

public class PlayerController : Shape
{
    [SerializeField]
    private Projectile projectilePrefab;

    protected override void Start()
    {
        base.Start();

        SetColor(Color.blue);
    }
    // Update is called once per frame
    private void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    private void MovePlayer()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon)
        {
            horizontalMovement *= Time.deltaTime * gameSceneController.playerSpeed;
            horizontalMovement += transform.position.x;

            var right = gameSceneController.screenBounds.x - halfWidht;
            var left = -right;

            var limit = Mathf.Clamp(horizontalMovement, left, right);

            transform.position = new Vector2(limit, transform.position.y);
        }
    }

    private void FireProjectile()
    {
        var spawnPosition = transform.position;

        var projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        projectile.projectileSpeed = 2;
        projectile.projectileDirection = Vector2.up;
    }
}