using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedestal : MonoBehaviour
{
    [SerializeField] private Canvas InventoryCanvas;
    public Camera Player1cam;
    public Camera Player2cam;

    private bool InventoryActive = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InventoryActive == false)
        {

        }


    }

}
