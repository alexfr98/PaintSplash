using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPlayer : MonoBehaviour
{

    private string username;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void setUsername(string username)
    {
        this.username = username;
    }
    public string getUsername()
    {
        return this.username;
    }
    public void setColor(Color color)
    {
        this.color = color;
    }
    public Color getColor()
    {
        return this.color;
    }
}
