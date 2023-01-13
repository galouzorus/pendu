using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenduStarter : MonoBehaviour
{
    public PenduManager penduManager;
    public UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        penduManager = new PenduManager(this);
    }
}


