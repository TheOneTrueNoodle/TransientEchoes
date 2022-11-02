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

    public PlayerMovement currentNearbyPlayer;
    public int numPlayerInRange;
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
                Player1cam = players[i].cam;
            }
            else
            {
                Player2 = players[i];
                Player2cam = players[i].cam;
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (numPlayerInRange == 1)
            {
                PlayerMovement pMovement = currentNearbyPlayer;
                if(InventoryActive != true)
                {
                    if (pMovement.PlayerNum == PlayerNum.Player1)
                    {
                        usingCam = Player1cam;
                        Player1.CanMove = false;
                    }
                    else
                    {
                        usingCam = Player2cam;
                        Player2.CanMove = false;
                    }

                    InventoryActive = true;
                    InventoryCanvas.gameObject.SetActive(true);
                    InventoryCanvas.worldCamera = usingCam;
                }
                else
                {
                    InventoryActive = false;
                    Player1.CanMove = true;
                    Player2.CanMove = true;
                    InventoryCanvas.gameObject.SetActive(false);
                }
            }
            else if (numPlayerInRange == 2)
            {
                if (InventoryActive == true)
                {
                    InventoryActive = false;
                    Player1.CanMove = true;
                    Player2.CanMove = true;
                    InventoryCanvas.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() == true)
        {
            numPlayerInRange++;
            if(numPlayerInRange == 1)
            {
                PlayerMovement pMovement = collision.GetComponent<PlayerMovement>();
                if (pMovement.PlayerNum == PlayerNum.Player1)
                {
                    currentNearbyPlayer = Player1;
                }
                else
                {
                    currentNearbyPlayer = Player2;
                }
            }
        }
        OpenInventoryPrompt.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() == true)
        {
            numPlayerInRange--; 
            if (numPlayerInRange == 1)
            {
                PlayerMovement pMovement = collision.GetComponent<PlayerMovement>();
                if (pMovement.PlayerNum == PlayerNum.Player1)
                {
                    currentNearbyPlayer = Player2;
                }
                else
                {
                    currentNearbyPlayer = Player1;
                }
            }
        }
        OpenInventoryPrompt.SetActive(false);
    }
}
