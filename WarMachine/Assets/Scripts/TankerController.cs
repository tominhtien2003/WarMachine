using UnityEngine;

public class TankerController : MonoBehaviour
{
    [SerializeField] Transform[] wheels;
    [SerializeField] float speedRotateWheel;
    [SerializeField] GameInput gameInput;


    private Vector2 inputVector;
    private void Start()
    {
        
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
}
