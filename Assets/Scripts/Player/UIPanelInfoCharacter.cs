using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIPanelInfoCharacter : MonoBehaviour
{
    public static UIPanelInfoCharacter singleon;
    public GameObject icon_character;
    public TextMeshProUGUI text_mesh_name_character;
    public GameObject icon_now_in_menu;
    public void SetParametersCharacterInMenu(Character_Pawn character)
    {
        //icon_character.overrideSprite = character.icon.sprite;
        if (icon_now_in_menu != null)
            Destroy(icon_now_in_menu);
        CreateIcon(character);
        text_mesh_name_character.text = character.second_name + " " + character.first_name;
    }
    public void CreateIcon(Character_Pawn character)
    {
        icon_now_in_menu = Instantiate(character.icon_obj, icon_character.transform);
        icon_now_in_menu.GetComponent<BoxCollider2D>().enabled = false;
        icon_now_in_menu.AddComponent<RectTransform>();
        icon_now_in_menu.AddComponent<CanvasRenderer>();
        icon_now_in_menu.GetComponent<RectTransform>().localScale = new Vector3(50, 50, 1);
        icon_now_in_menu.GetComponent<RectTransform>().localPosition = Vector3.zero;
        SpriteRenderer[] components_other = icon_now_in_menu.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in components_other) 
        {
            ConvertGameObjectToCanvasObject(child.gameObject);
        }
 
    }
    public void ConvertGameObjectToCanvasObject(GameObject icon)
    {
        icon.layer = 5;
        icon.AddComponent<CanvasRenderer>();
        icon.AddComponent<RectTransform>();
        icon.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        Image icon_image = icon.AddComponent<Image>();
        icon_image.overrideSprite = icon.GetComponent<SpriteRenderer>().sprite;
        icon_image.color = icon.GetComponent<SpriteRenderer>().color;
        icon_image.material = icon.GetComponent<SpriteRenderer>().material;
        icon.GetComponent<SpriteRenderer>().enabled = false;
    }
}
