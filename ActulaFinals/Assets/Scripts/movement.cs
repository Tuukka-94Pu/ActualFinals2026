using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    private CharacterController playerControl;
    public InputAction moves;
    public InputAction use;

    private Vector2 moveVal;

    private SpriteRenderer playerSprite;

    private Animator anims;

    public Sprite[] faces;

    public TMP_Text useInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControl = GetComponent<CharacterController>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        anims = GetComponent<Animator>();
        moves.Enable();
        use.Enable();
        useInfo.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (moves.IsPressed())
        {
             moveVal = moves.ReadValue<Vector2>();
            Vector3 movesDir = new Vector3(moveVal.x, 0, moveVal.y);
            playerControl.Move(movesDir * 5 * Time.deltaTime);



            switch(moveVal.y)
            {
                default:
                    break;
                case < 0:
                    playerSprite.sprite = faces[0];
                    anims.SetBool("down", true);
                    anims.SetBool("up", false);
                    anims.SetBool("left", false);
                    anims.SetBool("right", false);
                    break;
                case > 0:
                    playerSprite.sprite = faces[1];
                    anims.SetBool("up", true);
                    anims.SetBool("down", false);
                    anims.SetBool("left", false);
                    anims.SetBool("right", false);
                    break;

            }
            switch(moveVal.x)
            {
                default:
                    break;
                case < 0:
                    playerSprite.sprite = faces[2];
                    anims.SetBool("left", true);
                    anims.SetBool("right", false);
                    anims.SetBool("up", false);
                    anims.SetBool("down", false);
                    break;
                case > 0:
                    playerSprite.sprite = faces[3];
                    anims.SetBool("right", true);
                    anims.SetBool("left", false);
                    anims.SetBool("up", false);
                    anims.SetBool("down", false);
                    break;
            }

            


        }

        if(moves.WasReleasedThisFrame())
        {
            moveVal = new Vector2(0, 0);
            anims.SetBool("down", false);
            anims.SetBool("up", false);
            anims.SetBool("left", false);
            anims.SetBool("right", false);
            playerSprite.sprite = faces[0];

        }

    }



        
    


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("birdTask"))
        {
            if(use.WasPressedThisFrame())
            {
                other.GetComponent<task2>().OnUse(gameObject);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        useInfo.text = "";
    }
}
