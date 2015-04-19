using UnityEngine;
using System.Collections;

public class ChaseController : MonoBehaviour
{

    public float WingDelay = 1;
    public Component EnemyToChase;
    private float _nextMoveTime;

    // Use this for initialization
    void Start ()
    {
        _nextMoveTime = WingDelay;
    }
    
    // Update is called once per frame
    void Update ()
    {
        _nextMoveTime -= Time.deltaTime;
        if (!(this._nextMoveTime <= 0))
        {
            return;
        }

        var enemyBody = this.EnemyToChase.GetComponent<Rigidbody2D>();
        var body = this.GetComponent<Rigidbody2D>();

        body.velocity = (transform.position - 
            enemyBody.transform.position).normalized
               * (-7);

        this._nextMoveTime = this.WingDelay;
    }


}
