using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPparentObject : MonoBehaviour
{
    [SerializeField] private GameObject child;
    // Update is called once per frame
    void Update()
    {
         if(child == null)
        {
            Destroy(this.gameObject);
        }
    }
}
