using UnityEngine;

public class BirdObstacle : ObstacleBase
{
    private float[] spawnY = { -1.5f, -1f, 0f, 1f, 2f, 3f, 4f };

    protected override void SetPosition()
    {
        Vector2 pos = transform.position;
        pos.y = spawnY[Random.Range(0, spawnY.Length)];
        transform.position = pos;
    }
}
