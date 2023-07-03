using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CameraSelecting : NetworkBehaviour
{
    public Character select_character;

    [Client]
    public void PressRightClickMouse()
    {

    }


    [Client]
    public void PressLeftClickMouse()
    {
        CheckSelectCharacter();
    }

    [Client]
    public void CheckSelectCharacter()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        Character hit_character = null;
        if (hit.collider != null)
        {
            hit_character = hit.collider.GetComponentInParent<Character>();
        }
        if (hit_character != null && hit_character.gameObject == select_character)
            return;
        else if (hit_character != null)
        {
            UIPlayer.singleon.OpenPanelInfoCharacter(hit_character);
            select_character = hit_character;
        }

    }



}
