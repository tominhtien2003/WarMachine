using UnityEngine;

public class TankerController : MonoBehaviour
{
    [SerializeField] Transform[] wheels;
    [SerializeField] float moveSpeed;

    private void FixedUpdate()
    {
        Moving();
    }
    private void Moving()
    {
        foreach (Transform wheel in wheels)
        {
            wheel.Rotate(moveSpeed * Vector3.right);
        }
    }
}
