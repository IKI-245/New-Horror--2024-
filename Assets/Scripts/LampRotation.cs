using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampRotation : MonoBehaviour
{
    public float RotationSpeed;
    public Transform LampAxisTransform;
    public Light flashlight;

    public float minAngle;
    public float maxAngle;
    
    public bool On_flashlight;
    public float power;
    public bool Power_Set;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Power_Set == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                On_flashlight = !On_flashlight;
            }
        }  
        if (On_flashlight == true && power > 0)
        {
            power -= Time.deltaTime;
            flashlight.intensity = 1;
        }
        else
        {
            flashlight.intensity = 0;
        }
        if (power <= 0)
        {
            Power_Set = false;
            On_flashlight = false;
        }
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"), 0);

        var newAngleX = LampAxisTransform.localEulerAngles.x - +Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngleX > 180)
            newAngleX -= 360;

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);
        LampAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    } 
}
