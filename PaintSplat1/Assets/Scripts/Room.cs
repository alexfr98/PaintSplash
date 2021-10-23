using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    private string roomName;

    private LobbyPlayer owner;

    private LinkedList<LobbyPlayer> players;

    public LinkedList<Color> availableColors;

    // Start is called before the first frame update
    public Room()
    {
        availableColors = new LinkedList<Color>();
        availableColors.AddFirst(Color.blue);
        availableColors.AddFirst(Color.red);
        availableColors.AddFirst(Color.green);
        availableColors.AddFirst(Color.yellow);
    }
    public Color getRandomAvailableColor()
    {
        Color color = availableColors.First.Value;
        availableColors.RemoveFirst();
        return color;
    }

    public LobbyPlayer getOnwer()
    {
        return owner;
    }
    public LinkedList<LobbyPlayer> getPlayers()
    {
        return players;
    }
    public string getRoomName()
    {
        return roomName;
    }

    public void setOnwer(LobbyPlayer owner)
    {
        this.owner = owner;
    }
    public void setPlayers(LinkedList<LobbyPlayer> players)
    {
        this.players = players;
    }
    public void setRoomName(string name)
    {
        this.roomName = name;
    }
}
