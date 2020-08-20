using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class runner : MonoBehaviour {

    public float speed = 10.0f;
    public float rotationSpeed = 20.0f;

    Animator anim;

	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	void Update () {
        float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation > 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetFloat("speed", speed);
        }
        else if (translation < 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetFloat("speed", -1 * speed);
        }
        else
            anim.SetBool("isRunning", false);

        if(CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            anim.SetTrigger("jump");
        }
    }
}
