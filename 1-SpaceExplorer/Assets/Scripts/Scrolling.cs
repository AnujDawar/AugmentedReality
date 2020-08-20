using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

    private Vector2 uvSpeed = new Vector2(0.0f, -0.1f);
    private Vector2 uvOffset = Vector2.zero;

    private void LateUpdate()
    {
        uvOffset = uvOffset + (uvSpeed * Time.deltaTime);
        this.GetComponent<Renderer>().materials[0].SetTextureOffset("_MainTex", uvOffset);
    }
}
