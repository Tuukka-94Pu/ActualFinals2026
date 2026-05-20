using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    private CharacterController playerControl;
    public InputAction moves;
    public InputAction use;

    private Vector2 moveVal;

    private SpriteRenderer playerSprite;

    public Sprite[] faces;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControl = GetComponent<CharacterController>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        moves.Enable();
        use.Enable();
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
                    break;
                case > 0:
                    playerSprite.sprite = faces[1];
                    break;

            }
            switch(moveVal.x)
            {
                default:
                    break;
                case < 0:
                    playerSprite.sprite = faces[2];
                    break;
                case > 0:
                    playerSprite.sprite = faces[3];
                    break;
            }

            if(moves.WasReleasedThisDynamicUpdate())
            {
                Debug.Log("movement stopped");
                moveVal = new Vector2(0,0);
            }


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
}
