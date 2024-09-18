using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPropmtUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    public IInteractable _interactable;
    // Update is called once per frame
    void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        // Check if 'Z' key is pressed
        if (Keyboard.current.digit3Key.wasPressedThisFrame 
            || Keyboard.current.digit4Key.wasPressedThisFrame
            || Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            if (_interactable != null)
            {
                // Set the display status of the current interactable to false
                _interactable.DisplayStatus = false;
                if(_interactable != null) _interactable = null;
                if(_interactionPromptUI.IsDisplayed) _interactionPromptUI.close();
            }
        }


        if(_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();
            if(_interactable != null && _interactable.DisplayStatus)
            {
                if(!_interactionPromptUI.IsDisplayed) _interactionPromptUI.setUp(_interactable.InteractionPrompt);
                // if(Keyboard.current.eKey.wasPressedThisFrame) _interactable.Interact(this);
            }
        } 
        else 
        {
           if(_interactable != null) _interactable = null;
           if(_interactionPromptUI.IsDisplayed) _interactionPromptUI.close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
