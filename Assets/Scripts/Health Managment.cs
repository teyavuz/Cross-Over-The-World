using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagment : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            // Çarpışma algılandığında yapılacak işlemler burada gerçekleştirilir.
            Debug.Log("Çarpışma tespit edildi!");
        }
    }
    
    
}
