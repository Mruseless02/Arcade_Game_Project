using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPparentObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
          if(transform.GetChild(0) == null)
        {
            Destroy(gameObject);
        }
    }
}
