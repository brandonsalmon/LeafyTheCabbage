using UnityEngine;

public class OpeningCinematic : MonoBehaviour
{
    public string NextScene;

    public void HideMe()
    {
        Destroy(gameObject);
    }

    public void LoadStage()
    {
        Application.LoadLevel(NextScene);
    }
}
