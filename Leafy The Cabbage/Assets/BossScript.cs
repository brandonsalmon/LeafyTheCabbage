using UnityEngine;

public class BossScript : MonoBehaviour
{
    public string NextScene;

    void Update()
    {
        var health = gameObject.GetComponent<HealthComponent>();
        if (health.IsDead)
        {
            Application.LoadLevel(this.NextScene);
        }
    }
}
