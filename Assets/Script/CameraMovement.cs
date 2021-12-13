using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float negativePanLimit = 352;
    float plusPanLimit = 8;
    private Vector3 rotateValue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse X");
        float x = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(x, y * -1, 0);
        float xDiff = transform.localEulerAngles.x - rotateValue.x;
        float yDiff = transform.localEulerAngles.y - rotateValue.y;

        //membatasi berdasarkan nilai yang ditentukan
        rotateValue.x = (xDiff < 180 && xDiff > plusPanLimit) || (xDiff >= 180 && xDiff < negativePanLimit) ? 0 : rotateValue.x;
        rotateValue.y = (yDiff < 180 && yDiff > plusPanLimit) || (yDiff >= 180 && yDiff < negativePanLimit) ? 0 : rotateValue.y;

        transform.eulerAngles = transform.eulerAngles - rotateValue;
    }
}
