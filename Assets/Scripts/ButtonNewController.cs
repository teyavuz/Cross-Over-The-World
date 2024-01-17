using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNewController : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _lerpTime = 1f;
    private float _currentLerpTime;
    private float _perc = 1f;
    [SerializeField] public bool _isMoving;
    [SerializeField] public bool animTrigger;


    public float moveDistance = 2f; // Her yönde hareket mesafesi
    public float minX = -5f; // Minimum X pozisyonu
    public float maxX = 5f; // Maksimum X pozisyonu
    public float minY = -5f; // Minimum Y pozisyonu
    public float maxY = 5f; // Maksimum Y pozisyonu
    public float moveSpeed = 5f;

    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;
    
    public AudioSource jumpAudio; // Sesi çalmak için ses kaynağı

    private void Start()
    {
        upButton.onClick.AddListener(MoveUp);
        downButton.onClick.AddListener(MoveDown);
        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
    }

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveUp()
    {
        if (!_isMoving)
        {
            _startPosition = transform.position;
            _endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
            StartMoving();
        }
    }

    private void MoveDown()
    {
        if (!_isMoving)
        {
            _startPosition = transform.position;
            _endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
            StartMoving();
        }
    }

    private void MoveLeft()
    {
        if (!_isMoving)
        {
            _startPosition = transform.position;
            _endPosition = new Vector3(Mathf.Clamp(transform.position.x - 2, minX, maxX), transform.position.y, transform.position.z);
            StartMoving();
        }
    }

    private void MoveRight()
    {
        if (!_isMoving)
        {
            _startPosition = transform.position;
            _endPosition = new Vector3(Mathf.Clamp(transform.position.x + 2, minX, maxX), transform.position.y, transform.position.z);
            StartMoving();
        }
    }

    private void StartMoving()
    {
        _lerpTime = Vector3.Distance(_startPosition, _endPosition) / moveSpeed;
        _currentLerpTime = 0;
        _perc = 0;
        _isMoving = true;
        animTrigger = true;
        
        jumpAudio.Play();
    }

    private void MoveCharacter()
    {
        if (_isMoving)
        {
            _currentLerpTime += Time.deltaTime;
            _perc = _currentLerpTime / _lerpTime;

            transform.position = Vector3.Lerp(_startPosition, _endPosition, _perc);

            if (_perc >= 0.8f)
            {
                _perc = 1;
                _isMoving = false;
            }
            if (Mathf.Round(_perc) == 1)
            {
                animTrigger = false;
            }
        }
    }
}
