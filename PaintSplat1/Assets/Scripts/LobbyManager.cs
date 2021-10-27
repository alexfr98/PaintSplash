using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

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

    private System.Tuple<string, Color> playerColor;
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
        List<string> allowedColors = new List<string> { "red", "green", "blue", "yellow" };
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            string playerColor = (string)player.CustomProperties["playerColor"];
            if (allowedColors.Contains(playerColor))
            {
                allowedColors.Remove(playerColor);
            }
        }
        int randomColor = Random.Range(0, allowedColors.Count);
        string randomColorString = allowedColors[randomColor];
        PhotonNetwork.LocalPlayer.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() { { "playerColor", randomColorString } });

        if (randomColorString == "red") {
            this.playerColor = new System.Tuple<string, Color>("red", Color.red);
            userColorLobby2.color = Color.red;
        }
        else if (randomColorString == "green")
        {
            this.playerColor = new System.Tuple<string, Color>("green", Color.green);
            userColorLobby2.color = Color.green;
        }
        else if (randomColorString == "blue")
        {
            this.playerColor = new System.Tuple<string, Color>("blue", Color.blue);
            userColorLobby2.color = Color.blue;
        }
        else
        {
            this.playerColor = new System.Tuple<string, Color>("yellow", Color.yellow);
            userColorLobby2.color = Color.yellow;
        }

        ChangeLobby(lobby2);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Join room failed: " + message);
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player other)
    {
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
        string line = "";
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            line += player.NickName;
        }
        this.levelLabel.text = line;
        if (playerCount < 1) { this.player1Label.text = ""; }
        if (playerCount < 2) { this.player2Label.text = ""; }
        if (playerCount < 3) { this.player3Label.text = ""; }
        if (playerCount < 4) { this.player4Label.text = ""; }
        this.levelLabel.text = "Number of players: " + PhotonNetwork.CurrentRoom.PlayerCount;
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player player, Hashtable changedProps)
    {
        Debug.Log("Player: "+player+" Changed properties: "+changedProps);
        this.levelLabel.text = "Number of players: " + PhotonNetwork.CurrentRoom.PlayerCount;
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
        if (playerCount >= 1) { this.player1Label.text = players[0].NickName; this.player1Label.color = getColor((string)players[0].CustomProperties["playerColor"]); }
        if (playerCount >= 2) { this.player2Label.text = players[1].NickName; this.player2Label.color = getColor((string)players[1].CustomProperties["playerColor"]); }
        if (playerCount >= 3) { this.player3Label.text = players[2].NickName; this.player3Label.color = getColor((string)players[2].CustomProperties["playerColor"]); }
        if (playerCount >= 4) { this.player4Label.text = players[3].NickName; this.player4Label.color = getColor((string)players[3].CustomProperties["playerColor"]); }
    }

    private Color getColor(string colorSrting)
    {
        if (colorSrting == "red")
        {
            return Color.red;
        }
        else if (colorSrting == "green")
        {
            return Color.green;
        }
        else if (colorSrting == "blue")
        {
            return Color.blue;
        }
        else
        {
            return Color.yellow;
        }
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
            PhotonNetwork.LocalPlayer.NickName = usernameInput.text;
            Hashtable hash = new Hashtable();
            hash.Add("playerName", usernameInput.text);
            hash.Add("playerColor", this.playerColor.Item1);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);

            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
            if (playerCount >= 1) { this.player1Label.text = players[0].NickName; }
            if (playerCount >= 2) { this.player2Label.text = players[1].NickName; }
            if (playerCount >= 3) { this.player3Label.text = players[2].NickName; }
            if (playerCount >= 4) { this.player4Label.text = players[3].NickName; }

            this.currentPlayer.SetUsername(usernameInput.text);
            this.room.GetPlayers().AddLast(this.currentPlayer);
            this.room.SetLevel(levelInput.value);

            this.roomNumberLabel.text = "GAME ROOM: " + PhotonNetwork.CurrentRoom.Name;
            this.levelLabel.text = "Number of players: " + PhotonNetwork.CurrentRoom.PlayerCount;

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
        PhotonNetwork.LeaveRoom();

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

        PhotonNetwork.LeaveRoom();

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
