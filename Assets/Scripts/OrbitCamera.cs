using GLTFast;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target; // The target GameObject to orbit around.
    public float rotationSpeed = 120.0f; // Speed for horizontal and vertical rotation.

    private float currentVerticalAngle = 0f; // Current vertical rotation angle.
    private bool isRotating = false; // Flag to manage rotation state.
    private bool isZooming = false; // Flag to manage zooming state.
    private float initialPinchDistance; // Distance between touches at the start of a pinch.
    private float initialDistanceToTarget; // Initial distance from the camera to the target.

    public GameObject loadedGameObject;

    bool a = true;

    void Start()
    {
        try
        {
            loadedGameObject = FindAnyObjectByType<GltfAsset>().gameObject;
            // Initialize the vertical angle based on the current rotation.
            Vector3 angles = transform.eulerAngles;
            currentVerticalAngle = angles.x;
            // Calculate initial distance to the target.
            initialDistanceToTarget = Vector3.Distance(transform.position, target.position);
            // Ensure the camera looks at the target initially.
            transform.LookAt(target.position);
          
        }
        catch (System.Exception e) {
            Debug.Log(e);
        }
       


    }


    void Update()
    {
        if (a)
            try
            {

                Transform childTransform = loadedGameObject.transform.GetChild(0);


                if (childTransform != null)
                {
                    target = childTransform;
                    initialDistanceToTarget = Vector3.Distance(transform.position, target.position);
                    a = false;
                    print("lol");
                }
                else
                {
                    Debug.LogError("No child objects found!");
                }
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
            }


        if (Input.touchCount == 1 && !isZooming)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                isRotating = true;
                float horizontal = touch.deltaPosition.x * rotationSpeed * 0.02f;
                float vertical = -touch.deltaPosition.y * rotationSpeed * 0.02f;

                // Accumulate vertical angle change.
                currentVerticalAngle += vertical;
                // Clamp the vertical angle to avoid flipping.
                currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, -20f, 80f);

                // Apply rotation around the target horizontally and vertically.
                ApplyRotation(horizontal);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                isRotating = false;
            }
        }
        else if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            float currentPinchDistance = Vector2.Distance(touchZero.position, touchOne.position);

            if (!isRotating)
            {
                if (!isZooming)
                {
                    // Start of the pinch gesture.
                    isZooming = true;
                    initialPinchDistance = currentPinchDistance;
                }
                else
                {
                    // Continue pinch gesture, calculate and apply zoom.
                    float pinchFactor = initialPinchDistance / currentPinchDistance;
                    ZoomCamera(pinchFactor);
                    initialPinchDistance = currentPinchDistance; // Update pinch distance for next frame.
                }
            }
        }
        else
        {
            // Reset states when no or one touch is detected.
            isRotating = false;
            isZooming = false;
        }
    }

    void ApplyRotation(float horizontal)
    {
        // Horizontal rotation around the target.
        transform.RotateAround(target.position, Vector3.up, horizontal);

        // Vertical rotation adjustment.
        Quaternion rotation = Quaternion.Euler(currentVerticalAngle, transform.eulerAngles.y, 0);
        transform.position = target.position - rotation * Vector3.forward * initialDistanceToTarget;

        // Always look at the target.
        transform.LookAt(target.position);
    }

    void ZoomCamera(float pinchFactor)
    {
        Debug.Log($"Before Zoom: Distance: {initialDistanceToTarget}, Position: {transform.position}");

        // Adjust initial distance based on pinch factor. Invert direction if necessary.
        initialDistanceToTarget *= pinchFactor;
        // Clamp the distance to prevent the camera from going too close or too far.
        initialDistanceToTarget = Mathf.Clamp(initialDistanceToTarget, 2f, 5f);

        // Apply the updated distance to position the camera accordingly.
        Quaternion rotation = Quaternion.Euler(currentVerticalAngle, transform.eulerAngles.y, 0);
        transform.position = target.position - rotation * Vector3.forward * initialDistanceToTarget;

        // Ensure the camera looks at the target.
        transform.LookAt(target.position);
        Debug.Log($"After Zoom: Distance: {initialDistanceToTarget}, Position: {transform.position}");

    }
}