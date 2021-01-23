using UnityEngine;
using System.Collections;
public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
    public TMPro.TextMeshProUGUI interactionText;
    public MyBehaving inputAction;
    public Animator animator;
     private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(transform.position + Vector3.up, forward * interactionDistance);
        Debug.DrawRay(transform.position + Vector3.up, forward * interactionDistance, Color.cyan);
        RaycastHit hit;
        bool successfulHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance)) {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null) 
            {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfulHit = true;
            }
        }
        if (!successfulHit) interactionText.text = "";
    }
    void HandleInteraction(Interactable interactable)
    {
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
            if(inputAction.interactPressed)
            {
                interactable.Interact();
                print("interacted");
            }
            break;
            case Interactable.InteractionType.Hold:
            if(inputAction.interactPressing)
            {
                interactable.Interact();
            }
            break;
        }
    }
}
