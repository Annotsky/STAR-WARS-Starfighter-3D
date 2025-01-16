using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float controlSpeed = 10f;
    [Header("Clamping")]
    [SerializeField] private float xClampRange = 10f;
    [SerializeField] private float yClampRange = 10f;
    [Header("Rotation")]
    [SerializeField] private float rotationAngle = 20f;
    [SerializeField] private float rotationSpeed = 10f;
    [Header("Pitch")]
    [SerializeField] private float pitchAngle = 20f;

    private Vector2 _movement;

    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }
    
    private void ProcessTranslation()
    {
        float xOffset = _movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        
        float yOffset = _movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);
        
        transform.localPosition = new Vector3(clampedXPos,clampedYPos, 0f);
    }

    private void ProcessRotation()
    {
        float pitch = -pitchAngle * _movement.y;
        float roll = -rotationAngle * _movement.x;
        
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll); 
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation,
                                                rotationSpeed * Time.deltaTime);
    }
}
