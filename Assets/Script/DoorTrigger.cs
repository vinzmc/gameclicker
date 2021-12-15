using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator1;
    public Animator doorAnimator2;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        doorAnimator1.SetBool("isOpening", true);
        doorAnimator2.SetBool("isOpening", true);

        Invoke("changeScene", 1.3f);
    }

    public void changeScene(){
        SceneManager.LoadScene("Map1");
    }

}
