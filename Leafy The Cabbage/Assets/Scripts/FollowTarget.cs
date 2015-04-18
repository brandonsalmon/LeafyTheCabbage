using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Component ComponentToFollow;

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        gameObject.transform.position = this.GetTarget();
    }

    private Vector3 GetTarget()
    {
        return new Vector3(
            this.ComponentToFollow.transform.position.x,
            this.ComponentToFollow.transform.position.y,
            this.gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        var followCamera = GetComponent<Camera>();

        if (this.ComponentToFollow.transform)
        {
            Vector3 point = followCamera.WorldToViewportPoint(this.ComponentToFollow.transform.position);
            Vector3 delta = this.ComponentToFollow.transform.position - followCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref this.velocity, this.dampTime);
        }
    }
}
