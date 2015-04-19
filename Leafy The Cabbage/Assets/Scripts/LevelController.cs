using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private Vector2 LastCheckpoint { get; set; }

    public void SetLastCheckpoint(Vector2 position)
    {
        this.LastCheckpoint = position;
    }

    public void ReloadPlayerAtCheckpoint(GameObject player)
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        player.GetComponent<Renderer>().enabled = false;

        StartCoroutine(this.Delayed(player));
    }

    IEnumerator Delayed(GameObject player)
    {
        Debug.Log(player.name);

        //yield return new WaitForSeconds(Random.value);

        var randomOffset = new Vector2((Random.value * 4f) - 2f, (Random.value * 2f) + 1f);
        player.transform.position = this.LastCheckpoint + randomOffset;
        //player.transform.position = this.LastCheckpoint;

        var body = player.GetComponent<Rigidbody2D>();
        body.velocity = Vector2.zero;

        body.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);

        player.GetComponent<Renderer>().enabled = true;

        yield return null;
    }
}
