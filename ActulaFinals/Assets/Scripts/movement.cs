using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    private CharacterController playerControl;
    public InputAction moves;
    public InputAction use;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControl = GetComponent<CharacterController>();
        moves.Enable();
        use.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        if(moves.IsPressed())
        {
           var moveVal = moves.ReadValue<Vector2>();
            Vector3 movesDir = new Vector3(moveVal.x, 0, moveVal.y);
            playerControl.Move(movesDir * 5 * Time.deltaTime);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("birdTask") && use.WasPressedThisFrame())
        {
            other.GetComponent<task2>().OnUse(gameObject);
        }
    }
}
