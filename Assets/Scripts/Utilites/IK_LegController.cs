using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_LegController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform body;
    public float speed = 2.0f;
    public float foot_step = 0.2f;
    public float stepHeight = 0.2f;

    public IK_LegController Other_foot;
    private float leg_length = 10;
    private float timeCount =0.0f;
    private float curSpeed = 0.0f;


    private Vector3 Offset;
    private Vector3 last_pos;
    private Vector3 next_pos;
    private Vector3 cur_pos;

    private Vector3 velocity;
    private Vector3 StartDis;
    private Vector3 EndtDis;
    public bool _canMove = false;

    float footSpacing;
    [SerializeField] Vector3 footOffset = default;

    RaycastHit hit;
    Ray leg_ray;

    public void Move()      { _canMove = true;     }

    void Start()
    {
        StartDis = transform.position;
        EndtDis = transform.position;
        footSpacing = transform.localPosition.x;
        leg_length = (body.localPosition - transform.position).magnitude;
        next_pos = transform.position;
        last_pos = next_pos;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (transform.position - StartDis) / Time.deltaTime;
        curSpeed = Vector3.Magnitude(velocity)*2;

        if (curSpeed < speed)
        {
            curSpeed = speed;
        }
        leg_ray = new Ray(body.position + (body.right * footSpacing), Vector3.down);
        Debug.DrawRay(body.position + (body.right * footSpacing), Vector3.down * leg_length, Color.blue);
        transform.position = cur_pos;
        if (Physics.Raycast(leg_ray, out hit, leg_length + 1) == true)
        {

            if (Vector3.Distance(next_pos, hit.point) > foot_step)
            {
                int direction = body.InverseTransformPoint(hit.point).z > body.InverseTransformPoint(next_pos).z ? 1 : -1;
                next_pos = hit.point + (body.forward * foot_step * direction) + footOffset;
                timeCount = 0.0f;
            }
        }
        if(_canMove == true)
            if(timeCount < 1.0f)
            {
                Vector3 footPosition = Vector3.Slerp(last_pos, next_pos, timeCount);
                footPosition.y += Mathf.Sin(timeCount * Mathf.PI) * stepHeight;

                cur_pos = footPosition;
                timeCount = timeCount + Time.deltaTime* curSpeed;
            }
            else
            {
                last_pos = next_pos;
                _canMove = false;
                Other_foot.Move();
            }

        StartDis = transform.position;
    }
}
