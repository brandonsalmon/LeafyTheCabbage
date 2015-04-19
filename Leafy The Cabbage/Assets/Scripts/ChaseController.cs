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
        var positionToChase = enemyBody.position;
        var body = this.GetComponent<Rigidbody2D>();
        var destination = positionToChase - body.position;

        body.AddForce(destination, ForceMode2D.Impulse);

        this._nextMoveTime = this.WingDelay;
    }


}
