using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    // no need
    private string roomName;

    // no need
    private LobbyPlayer owner;

    // need
    private int level;

    // no need
    private LinkedList<LobbyPlayer> players;

    // Need
    public LinkedList<Color> availableColors;

    // Start is called before the first frame update
    public Room()
    {
        availableColors = new LinkedList<Color>(new[] { Color.blue, Color.red, Color.green, Color.yellow});
        players = new LinkedList<LobbyPlayer>();
    }
    public Color GetRandomAvailableColor()
    {
        Color color = availableColors.First.Value;
        availableColors.RemoveFirst();
        return color;
    }

    public void CancelColorAttribution(LobbyPlayer player)
    {
        availableColors.AddFirst(player.GetColor());
    }

    public LobbyPlayer GetOnwer()
    {
        return owner;
    }
    public LinkedList<LobbyPlayer> GetPlayers()
    {
        return players;
    }
    public string GetRoomName()
    {
        return roomName;
    }

    public int GetLevel()
    {
        return this.level;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public void SetOnwer(LobbyPlayer owner)
    {
        this.owner = owner;
    }
    public void SetPlayers(LinkedList<LobbyPlayer> players)
    {
        this.players = players;
    }
    public void SetRoomName(string name)
    {
        this.roomName = name;
    }
}
