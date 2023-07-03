using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartOptionsPlayer
{
    CameraController cameraController;
    public StartOptionsPlayer(CameraController cameraController)
    {
        this.cameraController = cameraController;
    }
    public void SetAllOptions()
    {
        EnabledParameters();
        StartOptions();
    }
    public void EnabledParameters()
    {
        cameraController.GetComponent<Camera>().enabled = true;
        cameraController.GetComponent<AudioListener>().enabled = true;
        cameraController.GetComponentInChildren<Canvas>().enabled = true;
        cameraController.GetComponentInChildren<CanvasScaler>().enabled = true;
        cameraController.GetComponentInChildren<GraphicRaycaster>().enabled = true;
        cameraController.GetComponentInChildren<EventSystem>().enabled = true;
        cameraController.GetComponentInChildren<StandaloneInputModule>().enabled = true;
        cameraController.GetComponentInChildren<UIPlayer>().enabled = true;
    }
    public void StartOptions()
    {
        UIPlayer.singleon = cameraController.GetComponentInChildren<UIPlayer>();
        UIPanelInfoCharacter.singleon = cameraController.GetComponentInChildren<UIPanelInfoCharacter>();
        UIPanelInfoCharacter.singleon.gameObject.SetActive(false);
        // настраиваем пешки
        Character[] NPCs = Object.FindObjectsOfType<Character>();
        foreach (Character npc in NPCs)
        {
            Canvas npcCanvas = npc.GetComponentInChildren<Canvas>();
            npcCanvas.worldCamera = cameraController.GetComponent<Camera>();
            npc.textMeshProNameCharacter = npcCanvas.GetComponentInChildren<TextMeshProUGUI>();
            npc.textMeshProNameCharacter.SetText(npc.attributes.secondName + " " + npc.attributes.firstName);
        }
    }
}
