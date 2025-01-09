using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeting : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public void CombatCamera()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
    public void StandartCamera()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }
}
