using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Task
{
    [SerializeField] public float speed;
    [SerializeField] public Vector3 Destination;
    private Vector3 Velocity;
    protected override void OnStart()
    {
        Velocity = Vector3.Normalize(Destination - this.gameObject.transform.position) * speed;
    }

    protected override void OnStop()
    {
        reset();
    }

    protected override State OnUpdate()
    {
        if(Vector3.Magnitude(Destination - this.gameObject.transform.position) > speed * Time.deltaTime)
        {
            this.gameObject.transform.position += Velocity * Time.deltaTime;
            return State.Running;
        }
        else
        {
            this.gameObject.transform.position = Destination;
            return State.Success;
        }
    }
}
