using UnityEngine;

public class TankerController : MonoBehaviour
{
    [SerializeField] Transform[] wheels;
    [SerializeField] Transform gunTransform;
    [SerializeField] float speedRotateWheel;
    [SerializeField] GameInput gameInput;


    private Vector2 inputVector;
    private bool isRotatingGun;
    private Vector3 lastMousePosition;
    private void Start()
    {
        lastMousePosition = Vector3.zero;
    }
    private void Update()
    {
        RotateGun();
    }
    private void FixedUpdate()
    {
        if (IsMoving())
        {
            ActivateAnimationMoving();
        }
        else
        {
            StopAnimationMoving();
        }
    }
    private void ActivateAnimationMoving()
    {
        foreach (Transform wheel in wheels)
        {
            wheel.Rotate(speedRotateWheel * Vector3.right);
        }
        if (AudioManager.Instance.musicSource.clip == null)
        {
            AudioManager.Instance.PlayMusic("Moving");

            AudioManager.Instance.musicSource.loop = true;
        }
    }
    private void StopAnimationMoving()
    {
        if (AudioManager.Instance.musicSource != null && AudioManager.Instance.GetSoundUsing() == "Moving")
        {
            AudioManager.Instance.musicSource.loop = false;

            AudioManager.Instance.ResetMusicSoundUsing();
        }
    }
    private bool IsMoving()
    {
        inputVector = gameInput.GetInputVectorNormalizeOfPlayer();
        return inputVector != Vector2.zero;
    }
    private void RotateGun()
    {
        if (!isRotatingGun && Input.GetMouseButtonDown(0))
        {
            isRotatingGun = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRotatingGun= false;
        }
        if (isRotatingGun)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float rotateDirection = (currentMousePosition - lastMousePosition).normalized.x;
            gunTransform.Rotate(0f, rotateDirection * Time.deltaTime * 50f, 0f);
            lastMousePosition = currentMousePosition;
        }
    }
}
