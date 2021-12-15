using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCamera : MonoBehaviour
{

    public Transform currentMount;
    public float speedFactor = 0.1f;
    public float zoomFactor = 1.0f;
    Vector3 lastPosition;
    public Camera cameraComp;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentMount.position, speedFactor);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speedFactor);

        var velocity = Vector3.Magnitude(transform.position - lastPosition);
        cameraComp.fieldOfView = 60 + velocity * zoomFactor;

        lastPosition = transform.position;
    }

    public void setMount(Transform newMount){
        currentMount = newMount;
        Debug.Log("testing");
    }

    public void changeScene(){
        SceneManager.LoadScene("Map1");
    }

    public void CallLoadNextScene()
    {
        Invoke("changeScene", 0.3f);
    }
}
