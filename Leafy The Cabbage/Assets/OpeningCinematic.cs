using UnityEngine;

public class OpeningCinematic : MonoBehaviour
{
    public void HideMe()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}
