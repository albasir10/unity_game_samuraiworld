using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayer : MonoBehaviour
{
    public static UIPlayer singleon;
    public GameObject panel_main_info_character;
    public bool is_opened_info_character_panel = false;
    public void OpenPanelInfoCharacter(Character_Pawn character)
    {
        is_opened_info_character_panel = true;
        UIPanelInfoCharacter.singleon.gameObject.SetActive(true);
        UIPanelInfoCharacter.singleon.SetParametersCharacterInMenu(character);
    }
    public void ClosePanelInfoCharacter()
    {
        is_opened_info_character_panel = false;
        UIPanelInfoCharacter.singleon.gameObject.SetActive(false);
    }
}
