using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This interface (Abstract Class) insure that all member that inharent this class can damage the object the object.
 */
public interface Damageable 
{
    //The TakeDamage Method is called by the attacker and is resposible for damaging the attanded target
    void TakeDamage(Damageable  obj, DamageLog log);

    //The Respond Methond is a reaction mathond that the one been attacked calls if the surten condidion are meet. Example: the player is blocking, any enemy that attacks player get stuned.
    void Respond(Damageable  obj, DamageLog log);
}


/*
 * This Struct is a log sending a report on the status of the character durring an attack 
 * Allowing the chararcter to react acording to the attack type
 * 
 * this struck will be expended apon when more of the game machanice is ready.
 */

public struct DamageLog
{
    public int index;
    public GameObject obj;
    public float DamageAmount;
    public bool blocking;
}

