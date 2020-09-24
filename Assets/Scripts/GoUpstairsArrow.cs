using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUpstairsArrow : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private MinigameRequester minigameRequester;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        minigameRequester = GetComponentInParent<MinigameRequester>();
    }

    private void Update()
    {
        bool enable = false;
        foreach (var interactable in minigameRequester.interactables)
        {
            if (interactable.isUpstairs && interactable.IsInteractable)
            {
                enable = true;
            }
        }

        spriteRenderer.enabled = enable;
    }
}
    
