using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _lerpTime;
    private float _currentLerpTime;
    private float _perc = 1f;

    [SerializeField] private float lerpCount = 5f;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private bool _firstInput;
    [SerializeField] public bool animTrigger;

    public float minX = -5f; // Minimum X pozisyonu
    public float maxX = 5f; // Maksimum X pozisyonu

    // Update is called once per frame
    void Update()
    {
        // X pozisyonunu sınırlamak için Mathf.Clamp kullanın
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        if (Input.GetButtonDown("up") || Input.GetButtonDown("down") || Input.GetButtonDown("left") || Input.GetButtonDown("right"))
        {
            _lerpTime = 1;
            _currentLerpTime = 0;
            _firstInput = true;
            animTrigger = true;
        }

        _startPosition = gameObject.transform.position;
        
        
        //Right
        if (Input.GetButtonDown("right") && gameObject.transform.position == _endPosition)
        {
            _endPosition = new Vector3(Mathf.Clamp(transform.position.x + 2, minX, maxX), transform.position.y, transform.position.z);
        }
        
        
        //Left
        if (Input.GetButtonDown("left") && gameObject.transform.position == _endPosition)
        {
            _endPosition = new Vector3(Mathf.Clamp(transform.position.x - 2, minX, maxX), transform.position.y, transform.position.z);
        }
        
        
        //Up
        if (Input.GetButtonDown("up") && gameObject.transform.position == _endPosition)
        {
            _endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
        }
        
        
        //Down
        if (Input.GetButtonDown("down") && gameObject.transform.position == _endPosition)
        {
            _endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
        }

        if (_firstInput == true)
        {
            _currentLerpTime += Time.deltaTime;
            _perc = _currentLerpTime / _lerpTime * lerpCount;
            gameObject.transform.position = Vector3.Lerp(_startPosition, _endPosition, _perc);
            if (_perc >= 0.8)
            {
                _perc = 1;
            }

            if (Mathf.Round(_perc) == 1)
            {
                animTrigger = false;
            }
        }
    }
}
