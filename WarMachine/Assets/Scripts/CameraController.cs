using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;


    private Vector3 offset;
    private Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
        offset = target.position - mainCamera.transform.position;
    }
    private void LateUpdate()
    {
        mainCamera.transform.position = target.position - offset;
    }

}
