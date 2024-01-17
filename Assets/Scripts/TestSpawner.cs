using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestSpawner : MonoBehaviour
{
    public GameObject[] lanes; // Şerit nesnelerini içeren dizi
    private GameObject tempLane; // Geçici şerit nesnesi

    public int baslangicUzakligi = 2; // Başlangıç z konumu
    public int kacAdet = 20; // Kaç şerit üretileceği
    public int laneSpacing = 2; // Şeritler arası mesafe

    private GameObject previousLane; // Önceki seçilen şerit

    public void CreateLanes()
    {
        int i;
        for (i = baslangicUzakligi; i < baslangicUzakligi + kacAdet;)
        {
            GameObject selectedLane = null;

            // Aynı şerit seçilene kadar döngüyü tekrarla
            do
            {
                selectedLane = lanes[Random.Range(0, lanes.Length)];
            } while (selectedLane == previousLane);

            // Seçilen şeriti sahneye ekle
            tempLane = Instantiate(selectedLane, new Vector3(0, -0.5f, i), Quaternion.identity) as GameObject;
            tempLane.transform.SetParent(gameObject.transform);
            i += tempLane.GetComponent<Lanes>().numberOfLanes - 1 + laneSpacing;

            // Önceki şeriti güncelle
            previousLane = selectedLane;
        }

        baslangicUzakligi = i; // Başlangıç z konumunu güncelle
    }

    private void Start()
    {
        CreateLanes(); // Şeritleri oluştur
    }
}