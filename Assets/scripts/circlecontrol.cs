using UnityEngine;

// z ekseni etrafında dönmesini 
public class circlecontrol : MonoBehaviour
{
    // Nesnenin dönme hızı 
    public float rotateSpeed;

    
    void Update()
    {
        SetcircleRotate(); // Dönme fonksiyon 
    }

    //  z ekseni etrafında döndürür
    public void SetcircleRotate()
    {
        // Vector3.forward, z ekseni yönünü ifade eder (0,0,1)
        
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
