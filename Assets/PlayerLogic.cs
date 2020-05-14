using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    PlayerInputHandler playerInputHandler;
    // Start is called before the first frame update
    void Start()
    {
        playerInputHandler = GetComponent<PlayerInputHandler>();
        playerInputHandler.OnMove += move => MoveMe(move);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputHandler.AttackPressed)
        {
            Debug.Log("Player has just pressed the attack button");
        }
        if (playerInputHandler.AttackPressing)
        {
            Debug.Log("Charge my super attack");
        }
    }
    void MoveMe(Vector2 move)
    {
        Debug.Log("The player is moving: " + move);
        transform.Translate(move * Time.deltaTime * 20);
    }
}
