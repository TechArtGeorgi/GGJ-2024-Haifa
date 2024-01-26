using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context
{
    public GameObject gameObject;
    public Transform transform;
    public Animator animator;
    public Rigidbody physics;
    public SphereCollider sphereCollider;
    public BoxCollider boxCollider;
    public CapsuleCollider capsuleCollider;
    public CharacterController characterController;

    // Add other game specific systems here
    public GameObject Player;
    public Vector3 SponePositon;

    public static Context CreateFromGameObject(GameObject gameObject)
    {
        // Fetch all commonly used components
        Context context = new Context();
        context.gameObject = gameObject;
        context.transform = gameObject.transform;
        context.animator = gameObject.GetComponent<Animator>();
        context.physics = gameObject.GetComponent<Rigidbody>();
        context.sphereCollider = gameObject.GetComponent<SphereCollider>();
        context.boxCollider = gameObject.GetComponent<BoxCollider>();
        context.capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        context.characterController = gameObject.GetComponent<CharacterController>();

        // Add whatever else you need here...
        return context;
    }
}
