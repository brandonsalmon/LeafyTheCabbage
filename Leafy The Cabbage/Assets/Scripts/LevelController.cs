using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{

    private Vector2 LastCheckpoint { get; set; }

    public void SetLastCheckpoint(Vector2 position)
    {
        LastCheckpoint = position;
    }

    public void ReloadPlayerAtCheckpoint(GameObject player)
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        player.transform.position = LastCheckpoint;
        var body = player.GetComponent<Rigidbody2D>();
        body.velocity = Vector2.zero;
    }
}
