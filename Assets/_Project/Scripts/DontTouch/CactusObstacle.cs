using UnityEngine;

public class CactusObstacle : ObstacleBase
{
    protected override void SetPosition()
    {
        Vector2 pos = transform.position;
        pos.y = -2f;
        transform.position = pos;
    }
}
