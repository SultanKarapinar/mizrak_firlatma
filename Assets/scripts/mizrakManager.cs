using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class mizrakManager : MonoBehaviour
{
    public List<GameObject> mizrakList = new List<GameObject>();       // Sahnedeki mızrak objeleri listesi
    public List<GameObject> mizrakIconList = new List<GameObject>();   //  mızrak ikonları listesi

    public GameObject mizrakPrefab;         // Mızrak prefabı 
    public GameObject mizrakIconPrefab;     // Mızrak ikonu prefabı 
    public Color activeColor;               // Aktif mızrak ikonu rengi
    public Color disableColor;              //  (pasif) mızrak ikonu rengi
    public Vector2 mizrakIconPosition;      // İlk mızrak ikonunun pozisyonu
    public int mizrakCount;                 // Toplam mızrak sayısı

    private int mizrakIndex = 0;            // aktif olan mızrak indeksi

    void Start()
    {
        CreatMizrak();       // Mızrakları oluştur
        createMizrakIcon();  // Mızrak ikonlarını oluştur
    }

    
    private void CreatMizrak()
    {
        for (int i = 0; i < mizrakCount; i++)
        {
            GameObject newmizrak = Instantiate(mizrakPrefab, transform.position, quaternion.identity);
            newmizrak.SetActive(false);           // Başlangıçta tüm mızraklar pasif
            mizrakList.Add(newmizrak);            // Listeye eklenir
        }

        mizrakList[0].SetActive(true);            // İlk mızrak aktif hale getirilir
    }


    public void SetActiveMizrak()
    {
        if (mizrakIndex < mizrakCount - 1)
        {
            mizrakIndex++;                                 // İndeksi artır
            mizrakList[mizrakIndex].SetActive(true);       // İlgili mızrağı aktif et
        }
    }

    
    public void SetDisablemizrakIconColor()
    {
        mizrakIconList[(mizrakIconList.Count - 1) - mizrakIndex]
            .GetComponent<SpriteRenderer>().color = disableColor;
    }

    
    private void createMizrakIcon()
    {
        for (int i = 0; i < mizrakCount; i++)
        { Vector3 center = new Vector3(0, 0, 0); 

            GameObject newmizrakIcon = Instantiate(mizrakIconPrefab, mizrakIconPosition, mizrakIconPrefab.transform.rotation);
            newmizrakIcon.GetComponent<SpriteRenderer>().color = activeColor; // Başlangıçta tüm ikonlar aktif renkte
            mizrakIconPosition.y += 0.5f;  // İkonları dikey olarak sıralar
            mizrakIconList.Add(newmizrakIcon); // Listeye ekle 
        }
    }


}
