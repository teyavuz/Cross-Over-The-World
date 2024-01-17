using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public GameObject ourPlayer;
    public float cameraSpeed = 5f;
    public float minX = -10f; // Minimum X pozisyon
    public float maxX = 10f;  // Maksimum X pozisyon
    public float heightGap = 1f;

    private Vector3 _position;

    void Update()
    {
        // Yeni kamera pozisyonunu hesapla
        _position = Vector3.Lerp(gameObject.transform.position, ourPlayer.transform.position, Time.deltaTime * cameraSpeed);

        // Kamera pozisyonunu sınırla
        _position.x = Mathf.Clamp(_position.x, minX, maxX);

        // Yükseklik değerini sabit tut
        _position.y = heightGap;

        // Kameranın pozisyonunu güncelle
        gameObject.transform.position = _position;
        
    }
}