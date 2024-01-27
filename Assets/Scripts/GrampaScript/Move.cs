using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Task
{
    [SerializeField] public float speed;
    [SerializeField] public Vector3 Destination;
    private float magnatued, old_magnatued;
    private Vector3 Velocity;

    protected override void OnStart()
    {
        Destination.y = context.transform.position.y;
        magnatued = Vector3.Magnitude(Destination - context.transform.position);
        old_magnatued = magnatued;
        Vector3 LocalDis = Destination - context.transform.position;
        Velocity = Vector3.Normalize(LocalDis) * speed;
    }

    protected override void OnStop()
    {
        reset();
    }

    protected override State OnUpdate()
    {
        old_magnatued = magnatued;
        magnatued = Vector3.Magnitude(Destination - context.transform.position);
        if (magnatued - old_magnatued > 0 || magnatued < speed * Time.deltaTime)
        {
            context.animator.SetBool("Walking", false);
            context.transform.position = Destination;
            return State.Success;
        }
        else
        {
            context.animator.SetBool("Walking", true);
            context.transform.position += Velocity * Time.deltaTime;
            return State.Running;
        }
    }
}
