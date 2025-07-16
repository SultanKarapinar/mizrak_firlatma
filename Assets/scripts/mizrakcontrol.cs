using UnityEngine;
using UnityEngine.SceneManagement;

// Bu script, mızrağın hareketini ve çarpışma kontrollerini yönetir.
public class mizrakcontrol : MonoBehaviour
{
    public Rigidbody2D mizrakRigidbody;       // Mızrağın fiziksel hareketini sağlayan Rigidbody2D bileşeni
    public mizrakManager mizrakManager;     
    public float moveSpeed;                   // Mızrağın yukarıya doğru hareket hızı
    bool canshoot;                            // Mızrak fırlatıldı mı kontrolü
    AudioSource audioSource;                  // Ses efektlerini  için ses kaynağı

    void Start()
    {
        GetCommponentValues();                // Gerekli bileşenleri al
        audioSource = GetComponent<AudioSource>(); // AudioSource bileşenini al
    }

    void Update()
    {
        HandleShootInput();                   
    }

    //  tıklama giriş kontrol 
    private void HandleShootInput()
    {
        if (Input.GetMouseButtonDown(0)) // Sol mouse tuşuna basıldığında

        {   audioSource.Play();                   // Çarpışma sesini çal
            mizrakManager.SetDisablemizrakIconColor(); // Mızrak ikon rengini pasifleştir
            canshoot = true;                           // Mızrak fırlatılabilir hale gelsin
        }
    }

    void FixedUpdate()
    {
        Shoot(); 
    }

    // vızrağın yukarı doğru hareket 
    private void Shoot()
    {
        if (canshoot)
        {
            // Yukarı doğru bir kuvvet 
            mizrakRigidbody.AddForce(Vector2.up * moveSpeed * Time.fixedDeltaTime);
        }
    }

    // Mızrak bir nesneye çarptığında
    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("circle")) // Eğer dönen daireye çarparsa
        {
            mizrakManager.SetActiveMizrak();       // Yeni bir mızrak aktif hale getir
            canshoot = false;                      // Artık fırlatılmasın
            mizrakRigidbody.isKinematic = true;    // Fizik etkilerini durdur
            transform.SetParent(other.gameObject.transform); // Mızrağı çemberin alt objesi yap
        }

        if (other.gameObject.CompareTag("mizrak")) // Eğer başka bir mızrağa çarparsa
        {
            
            SceneManager.LoadScene(1);            // menü e dön
        }
    }

    
    private void GetCommponentValues()
    {
        mizrakRigidbody = GetComponent<Rigidbody2D>(); 
        mizrakManager = GameObject.FindFirstObjectByType<mizrakManager>(); // mizrakManager scriptine eriş
    }
}
