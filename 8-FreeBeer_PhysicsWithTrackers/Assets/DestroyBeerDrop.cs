﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBeerDrop : MonoBehaviour {

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
