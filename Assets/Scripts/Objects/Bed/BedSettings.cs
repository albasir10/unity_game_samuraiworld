using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedSettings : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Character character = collision.collider.GetComponentInParent<Character>();
        if (character != null && character.bed == gameObject)
        {
            character.attributes.isInBed = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Character character = collision.collider.GetComponentInParent<Character>();
        if (character != null && character.bed == gameObject)
        {
            character.attributes.isInBed = false;
        }
    }
}
