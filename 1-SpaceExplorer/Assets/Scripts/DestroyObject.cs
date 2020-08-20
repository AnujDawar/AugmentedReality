using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(this.GetComponent<Renderer>().transform.root.gameObject);
    }
}
