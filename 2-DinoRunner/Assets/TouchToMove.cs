using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToMove : MonoBehaviour
{
    public GameObject foodPrefab;
    public float speed = 1.0f;
    public float rotSpeed = 0.5f;
    public float accuracy = 0.25f;

    GameObject food;
    Vector3 goalPosition;
    Animator anim;

    void Start () {
        anim = this.gameObject.GetComponent<Animator>();
	}
	
	void Update () {
		if(Input.GetMouseButtonDown(0) && food == null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 1000.0f))
            {
                if(hit.collider.tag == "ground")
                {
                    goalPosition = hit.point;
                    food = Instantiate(foodPrefab, goalPosition, Quaternion.identity);
                    Invoke("RemoveFood", 4.0f);
                }
            }
        }
	}

    private void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goalPosition.x, this.transform.position.y, goalPosition.z);
        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        if(Vector3.Distance(transform.position, lookAtGoal) > accuracy)
        {
            this.transform.Translate(0, 0, speed * Time.deltaTime);
            anim.SetBool("isRunning", true);
            anim.SetFloat("speed", 1.0f);
        }
        else
        {
            anim.SetBool("isRunning", false);

            if(food != null)
            {
                anim.SetBool("isEating", true);
            }
        }

        if(food == null)
        {
            anim.SetBool("isEating", false);
        }
    }

    void RemoveFood()
    {
        Destroy(food);
    }
}
