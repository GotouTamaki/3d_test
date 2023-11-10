using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewTest : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Sprite[] _sprite;
    [SerializeField] GameObject targetObject;
    [SerializeField] Vector2 rotationSpeed = new Vector2(0.1f, 0.2f);
    [SerializeField] bool reverse;

    Camera mainCamera;
    Vector2 lastMousePosition;

    void Start()
    {
        //mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            if (!reverse)
            {
                var x = (Input.mousePosition.y - lastMousePosition.y);
                var y = (lastMousePosition.x - Input.mousePosition.x);

                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                targetObject.transform.Rotate(newAngle);
                lastMousePosition = Input.mousePosition;

                Debug.Log($"XMove : {x}\nYMove : {y}");
            }
            else
            {
                var x = (lastMousePosition.y - Input.mousePosition.y);
                var y = (Input.mousePosition.x - lastMousePosition.x);

                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                targetObject.transform.Rotate(newAngle);
                lastMousePosition = Input.mousePosition;

                Debug.Log($"XMove : {x}\nYMove : {y}");
            }
        }
    }
}
