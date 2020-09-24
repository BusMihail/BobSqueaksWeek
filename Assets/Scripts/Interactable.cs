using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactable : MonoBehaviour
{
    public MinigameType minigame = MinigameType.Laptop;

    public bool MinigameStarted { get; set; }
    public bool InMinigame { get; set; }

    public bool IsInteractable { get { return isInteractable; } }

    private bool isInteractable;
    [SerializeField]
    private Player player = null;

    private SpriteRenderer arrow;

    public bool isUpstairs;

    private void Awake()
    {
        arrow = GetComponentInChildren<SpriteRenderer>();
        arrow.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Player>();

            if (isInteractable)
            {
                player.SetInteractable(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.SetInteractable(null);
            this.player = null;
        }
    }

    public void Interact()
    {
        MinigameManager.Instance.LoadMinigame(minigame, this);
        MinigameStarted = true;
        InMinigame = true;
        SetInteractable(false);
    }

    public void SetInteractable(bool isInteractable)
    {
        this.isInteractable = isInteractable;
        if (isInteractable == true)
        {
            if(player!=null)
            {
                player.SetInteractable(this);
            }

            arrow.enabled = true;
        }
        else
        {
            if(player!=null)
            {
                player.SetInteractable(null);
            }

            arrow.enabled = false;
        }
    }

}
