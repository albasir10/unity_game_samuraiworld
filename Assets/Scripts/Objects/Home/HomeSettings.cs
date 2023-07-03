using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class HomeSettings : NetworkBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Character character = collision.collider.GetComponentInParent<Character>();
        if (character != null && character.home == gameObject)
        {
            Debug.LogWarning("InHome");
            character.attributes.isInHome = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Character character = collision.collider.GetComponentInParent<Character>();
        if (character != null && character.home == gameObject)
        {
            character.attributes.isInHome = false;
        }
    }
}
