using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movenemt : MonoBehaviour
{
    Vector3 CurPostion;
    Vector3 LastPostion;

    [SerializeField] Animator anim;

    private void Awake()
    {
        CurPostion = this.transform.position;
        LastPostion = this.transform.position;

        anim = GetComponent<Animator>();
    }

    private void TurningLeftRight()
    {
        float x = CurPostion.x - LastPostion.x;
        if(x >= -0.01)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }


    private void Update()
    {
        LastPostion = CurPostion;
        CurPostion = this.transform.position;
        TurningLeftRight();
    }
}
