using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public GameObject lobby;
    public GameObject lobby2;
    public GameObject lobby3;

    private GameObject currentLobby;

    public InputField createRoomInput;
    public InputField usernameInput;

    public SpriteRenderer userColorLobby2;

    private LobbyPlayer currentPlayer;
    private Room room;

    // Start is called before the first frame update
    void Start()
    {
        currentLobby = lobby;
        lobby.SetActive(true);
        lobby2.SetActive(false);
        lobby3.SetActive(false);

        room = new Room();
        currentPlayer = new LobbyPlayer();
    }

    public void ChangeLobby(GameObject newLobby)
    {
        // Means we are in the lobby 1 and we go to lobby 2
        if (currentLobby == lobby)
        {
            // Take the room name
            if (createRoomInput.text != "")
            {
                setRoomName(createRoomInput.text);
                Debug.Log("Room name :" + room.getRoomName());
            }
            else
            {
                // COULD GIVE A RANDOM NAME
                return;
            }

            // Assign a color to the current player (Not taken by another one)
            this.currentPlayer.setColor(room.getRandomAvailableColor());
            userColorLobby2.color = this.currentPlayer.getColor();
        }

        currentLobby.SetActive(false);
        currentLobby = newLobby;
        currentLobby.SetActive(true);

    }
    public void setRoomName(string name)
    {
        room.setRoomName(name);
    }
    public void setCurrentPlayerUsername()
    {
        currentPlayer.setUsername(createRoomInput.text);
    }
}
