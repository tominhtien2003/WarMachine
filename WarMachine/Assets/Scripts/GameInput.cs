using UnityEngine;

public class GameInput : MonoBehaviour
{
    public PlayerInputAction playerInputAction { get;private set; }
    private void Start()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();
    }
    public Vector2 GetInputVectorNormalizeOfPlayer()
    {
        return playerInputAction.Player.Movement.ReadValue<Vector2>().normalized;
    }
}
