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
        Velocity = Vector3.Normalize(Destination - context.transform.position) * speed;
    }

    protected override void OnStop()
    {
        reset();
    }

    protected override State OnUpdate()
    {
        if(Vector3.Magnitude(Destination - context.transform.position) > speed * Time.deltaTime)
        {
            context.transform.position += Velocity * Time.deltaTime;
            return State.Running;
        }
        else
        {
            context.transform.position = Destination;
            return State.Success;
        }
    }
}
