using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInHome : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       if (other.GetComponentInParent<Character_Pawn>() != null)
        {
            Character_Pawn character_pawn = other.GetComponentInParent<Character_Pawn>();
            character_pawn.stateCharacter.is_in_home = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Character_Pawn>() != null)
        {
            Character_Pawn character_pawn = other.GetComponentInParent<Character_Pawn>();
            character_pawn.stateCharacter.is_in_home = false;
        }
    }
}
