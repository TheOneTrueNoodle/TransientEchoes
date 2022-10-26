using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedestal : MonoBehaviour
{
    [SerializeField] private Canvas InventoryCanvas;
    public Camera Player1cam;
    private PlayerMovement Player1;
    public Camera Player2cam;
    private PlayerMovement Player2;
    private Camera usingCam;

    private PlayerMovement playerWithInventoryOpen;

    private bool InventoryActive = false;
    [SerializeField] private GameObject OpenInventoryPrompt;

    private void Start()
    {
        PlayerMovement[] players = FindObjectsOfType<PlayerMovement>();
        for(int i = 0; i < players.Length; i++)
        {
            if(players[i].PlayerNum == PlayerNum.Player1)
            {
                Player1 = players[i];
            }
            else
            {
                Player2 = players[i];
            }
        }
    }

    private void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OpenInventoryPrompt.SetActive(true);
        if (collision.GetComponent<PlayerMovement>() && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMovement pMovement = collision.GetComponent<PlayerMovement>();
            if(InventoryActive == false)
            {
                if (pMovement.PlayerNum == PlayerNum.Player1)
                {
                    usingCam = Player1cam;
                    Player1.CanMove = false;
                    playerWithInventoryOpen = Player1;
                }
                else
                {
                    usingCam = Player2cam;
                    Player2.CanMove = false;
                    playerWithInventoryOpen = Player2;
                }

                InventoryCanvas.gameObject.SetActive(true);
                InventoryCanvas.worldCamera = usingCam;
            }
            else if(InventoryActive == true)
            {
                playerWithInventoryOpen.CanMove = true;
                InventoryCanvas.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OpenInventoryPrompt.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OpenInventoryPrompt.SetActive(false);
    }
}
