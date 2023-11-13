using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewTest : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] GameObject targetObject;
    [SerializeField] float _interval = 1.0f;
    [SerializeField] float rotationSpeed = 0.1f;
    [SerializeField] bool reverse;

    Camera mainCamera;
    Vector2 lastMousePosition;
    int _spriteIndex = 0;
    float _timer = 0;
    bool _mouseFlag = false;

    public bool MouseFlag => _mouseFlag;

    void Start()
    {
        //mainCamera = Camera.main;
        _image = GetComponent<Image>();
        _spriteIndex = 0;
        _image.sprite = _sprites[_spriteIndex];
    }

    void Update()
    {
        //if (_mouseFlag)
        //{
            _timer += Time.deltaTime;

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

                    //var newAngle = Vector3.zero;
                    //newAngle.x = x * rotationSpeed;
                    //newAngle.y = y * rotationSpeed;

                    //targetObject.transform.Rotate(newAngle);

                    if (y > rotationSpeed && _timer > _interval)
                    {
                        _spriteIndex++;

                        if (_spriteIndex >= _sprites.Length)
                        {
                            _spriteIndex = 0;
                        }

                        _image.sprite = _sprites[_spriteIndex];
                        _timer = 0;
                    }
                    else if (y < -rotationSpeed && _timer > _interval)
                    {
                        _spriteIndex--;

                        if (_spriteIndex <= 0)
                        {
                            _spriteIndex = _sprites.Length - 1;
                        }

                        _image.sprite = _sprites[_spriteIndex];
                        _timer = 0;
                    }

                    lastMousePosition = Input.mousePosition;

                    Debug.Log($"XMove : {y} YMove : {x}\nSpriteIndex : {_spriteIndex}");
                }
                else
                {
                    var x = (lastMousePosition.y - Input.mousePosition.y);
                    var y = (Input.mousePosition.x - lastMousePosition.x);

                    //var newAngle = Vector3.zero;
                    //newAngle.x = x * rotationSpeed;
                    //newAngle.y = y * rotationSpeed;

                    //targetObject.transform.Rotate(newAngle);

                    if (y > rotationSpeed && _timer > _interval)
                    {
                        _spriteIndex++;

                        if (_spriteIndex >= _sprites.Length)
                        {
                            _spriteIndex = 0;
                        }

                        _image.sprite = _sprites[_spriteIndex];
                        _timer = 0;
                    }
                    else if (y < -rotationSpeed && _timer > _interval)
                    {
                        _spriteIndex--;

                        if (_spriteIndex <= 0)
                        {
                            _spriteIndex = _sprites.Length - 1;
                        }

                        _image.sprite = _sprites[_spriteIndex];
                        _timer = 0;
                    }

                    lastMousePosition = Input.mousePosition;

                    Debug.Log($"XMove : {y} YMove : {x}\nSpriteIndex : {_spriteIndex}");
                }
            }
        //}
    }
}
