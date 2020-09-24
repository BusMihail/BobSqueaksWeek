using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;

    private Animator animator;

    private SpriteRenderer spriteRenderer;
    public Sprite frontSprite;
    public Sprite backSprite;
    public Sprite leftSprite;

    [SerializeField]
    private GameObject exclamationMark = null;

    public Interactable InteractableItem { get; set; }
    private bool canInteract;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = frontSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.FreezeGame == false)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            float moveVertical = Input.GetAxis("Vertical");

            animator.SetFloat("DirectionX", moveHorizontal);
            animator.SetFloat("DirectionY", moveVertical);

            if (moveVertical != 0 || moveHorizontal != 0)
            {
                animator.SetBool("isIdle", false);
            }
            else
            {
                animator.SetBool("isIdle", true);

            }

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            /*if (movement.y > 0 && movement.x == 0)
            {
                spriteRenderer.sprite = backSprite;
                spriteRenderer.flipX = false;
            }
            else if (movement.y < 0 && movement.x == 0)
            {
                spriteRenderer.sprite = frontSprite;
                spriteRenderer.flipX = false;
            }
            else if (movement.x > 0)
            {
                spriteRenderer.sprite = leftSprite;
                spriteRenderer.flipX = true;
            }
            else if (movement.x < 0)
            {
                spriteRenderer.sprite = leftSprite;
                spriteRenderer.flipX = false;
            }*/

            rb2d.velocity = movement * speed;
        }

        if (canInteract)
        {
            exclamationMark.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
        else
        {
            exclamationMark.SetActive(false);
        }
    }

    // Set the item to interactive and turn canInteract to true ( false if no interactable)
    public void SetInteractable(Interactable interactable)
    {
        InteractableItem = interactable;
        if (interactable == null)
        {
            canInteract = false;
        }
        else
        {
            canInteract = true;
        }
    }

    public void Interact()
    {
        if (canInteract)
        {
            canInteract = false;
            InteractableItem.Interact();
        }
    } 
}
