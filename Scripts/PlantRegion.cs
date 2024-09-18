using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRegion : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public bool DisplayStatus { get; set; } = true;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Press Z to plant");
        return true;
    }
}
