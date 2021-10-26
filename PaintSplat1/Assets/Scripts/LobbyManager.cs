using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [Header("Lobbies objects")]
    public GameObject lobby;
    public GameObject lobby2;
    public GameObject lobby3;

    private GameObject currentLobby;

    [Header("Lobby 1 objects")]
    public InputField createRoomInput;
    public InputField joinRoomInput;

    [Header("Lobby 2 objects")]
    public InputField usernameInput;
    public SpriteRenderer userColorLobby2;
    public Dropdown levelInput;
    public GameObject gameLevelRow;

    [Header("Lobby 3 objects")]
    public Text roomNumberLabel;
    public Text levelLabel;
    public Text player1Label;
    public Text player2Label;
    public Text player3Label;
    public Text player4Label;
    public Button startGameButton;

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

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(createRoomInput.text, roomOptions);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created!");
        ChangeLobby(lobby2);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(this.joinRoomInput.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room Joined!");
        ChangeLobby(lobby2);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Join room failed: " + message);
    }
    public void ChangeLobby(GameObject newLobby)
        {
            currentLobby.SetActive(false);
            currentLobby = newLobby;
            currentLobby.SetActive(true);
        }

    public void Lobby1CreateRoomButtonClicked()
    {
        // Take the room name
        if (createRoomInput.text != "") //TODO: AND GAME ROOM DONT EXISTS ALREADY
        {
            CreateRoom();

            SetRoomName(createRoomInput.text);
            SetRoomOwner(currentPlayer);
            Debug.Log("Room name :" + room.GetRoomName());

            // Assign a color to the current player (Not taken by another one)
            this.currentPlayer.SetColor(room.GetRandomAvailableColor());
            userColorLobby2.color = this.currentPlayer.GetColor();
            this.room.GetPlayers().AddLast(currentPlayer);
            this.gameLevelRow.gameObject.SetActive(true);
            return;
        }

        //TODO: COULD GIVE A RANDOM NAME or display a message to say its wrong
        return;
    }

    public void Lobby1JoinRoomButtonClicked()
    {
        // Take the room name
        if (joinRoomInput.text != "") //TODO: AND GAME ROOM EXISTS
        {
            // Try to connect to room
            JoinRoom();

            // Assign a color to the current player (Not taken by another one)
            this.currentPlayer.SetColor(room.GetRandomAvailableColor());
            userColorLobby2.color = this.currentPlayer.GetColor();
            this.room.GetPlayers().AddLast(currentPlayer);
            this.gameLevelRow.gameObject.SetActive(false);
        return;
        }

        //TODO: display a message to say its wrong
        return;
    }

    public void Lobby2ReadyButtonClicked()
    {
        if (usernameInput.text != "") // And username is not already taken
        {
            this.currentPlayer.SetUsername(usernameInput.text);
            this.room.GetPlayers().AddLast(this.currentPlayer);
            this.room.SetLevel(levelInput.value);

            this.roomNumberLabel.text = "GAME ROOM: " + this.room.GetRoomName();
            this.levelLabel.text = "Level: " + (this.room.GetLevel() + 1);
            this.player1Label.text = this.currentPlayer.GetUsername();
            this.player1Label.color = this.currentPlayer.GetColor();

            if (this.room.GetOnwer() == this.currentPlayer)
            {
                this.startGameButton.gameObject.SetActive(true);
            }
            else
            {
                this.startGameButton.gameObject.SetActive(false);
            }

            ChangeLobby(lobby3);
        }
    }

    public void Lobby2CancelButtonClicked()
    {
        Debug.Log(PhotonNetwork.CurrentRoom);

        this.room.CancelColorAttribution(currentPlayer);
        if (this.room.GetOnwer() == this.currentPlayer)
        {
            //Destroy online room
        }

        this.room.GetPlayers().AddLast(this.currentPlayer);
        ChangeLobby(lobby);
    }

    public void Lobby3StartGameButtonClicked()
    {
        // Do stuff before game starts
    }

    public void Lobby3ExitButtonClicked()
    {
        // Do stuff to remove the player from the online game room and put back his color in it

        if (this.room.GetOnwer() == this.currentPlayer)
        {
            // Destroy the online game room
        }

        this.room = new Room();
        this.currentPlayer = new LobbyPlayer();
        ChangeLobby(lobby);
    }

    public void SetRoomOwner(LobbyPlayer player)
    {
        this.room.SetOnwer(player);
    }

    public void SetRoomName(string name)
    {
        room.SetRoomName(name);
    }
    public void SetCurrentPlayerUsername()
    {
        currentPlayer.SetUsername(createRoomInput.text);
    }
}
