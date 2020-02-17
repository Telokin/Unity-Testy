using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceil : MonoBehaviour
{
    public GameObject leftWall, rightWall, topWall, bottomWall;

    public byte state;
    public List<Dirs> dirs = new List<Dirs>() { Dirs.Left, Dirs.Right, Dirs.Top, Dirs.Bottom };
    public Vector2 backWay = Vector2.zero;

    public void CreateDir(Dirs dir)
    {
        state = 1;
        dirs.Remove(dir);

        switch (dir)
        {
            case Dirs.Left: leftWall.SetActive(false); break;
            case Dirs.Right: rightWall.SetActive(false); break;
            case Dirs.Top: topWall.SetActive(false); break;
            case Dirs.Bottom: bottomWall.SetActive(false); break;
        }
    }
}