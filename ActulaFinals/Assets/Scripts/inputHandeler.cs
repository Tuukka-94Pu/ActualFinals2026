using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class inputHandeler : MonoBehaviour
{
    private PlayerInput inputs;
    private movement move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputs = GetComponent<PlayerInput>();

        move = GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
