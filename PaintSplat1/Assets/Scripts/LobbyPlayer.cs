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
    public void SetUsername(string username)
    {
        this.username = username;
    }
    public string GetUsername()
    {
        return this.username;
    }
    public void SetColor(Color color)
    {
        this.color = color;
    }
    public Color GetColor()
    {
        return this.color;
    }
}
