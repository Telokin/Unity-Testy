using System;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public string seed;
    public GameObject prefab;
  //  public GameObject prefabend;
    public Vector2 mapSize = new Vector2(10, 10);

    Ceil[,] ceils;
//    End[,] end;
    System.Random random;

    void Awake()
    {
        ceils = new Ceil[(int)(mapSize.x), (int)(mapSize.y)];
    //    end = new Ceil[(int)(mapSize.x), (int)(mapSize.y)];
    }

    void Start()
    {
        random = new System.Random((!string.IsNullOrEmpty(seed)) ? seed.GetHashCode() : System.Guid.NewGuid().GetHashCode());
        BuildCeils();
        SetCeils();
    }

    void BuildCeils()
    {
        for (int y = 0; y < mapSize.y; y++)
        {
            for (int x = 0; x < mapSize.x; x++)
            {
          //      int pierwszy = Random.Range(0, 10);
          //      int drugi = Random.Range(0, 10);
                GameObject newCeil = Instantiate(prefab, new Vector3(x, 0, y), Quaternion.identity) as GameObject;
           //     GameObject endCeil = Instantiate(prefabEnd, new Vector3(x, 0, y), Quaternion.identity) as GameObject;
                newCeil.name = string.Format("_Ceil({0},{1})", x, y);
           //     newCeil.name = string.Format("_End({0},{1})", pierwszy, drugi);
                newCeil.transform.parent = this.transform;
                ceils[x, y] = newCeil.GetComponent<Ceil>();
           //     end[pierwszy, drugi] = newCeil.GetComponent<End>();
            }
        }
    }

    void SetCeils()
    {
        int x = 0, y = 0;

        while (ceils[x, y].state != 2)
        {
            Ceil myCeil = ceils[x, y];
            Dirs myDir = (myCeil.dirs.Count > 0) ? myCeil.dirs[random.Next(0, myCeil.dirs.Count)] : Dirs.None;
            if (myDir != Dirs.None) myCeil.dirs.Remove(myDir);

            switch (myDir)
            {
                case Dirs.Left:
                    if (x > 0)
                    {
                        x--;
                        Ceil addCeil = ceils[x, y];

                        if (addCeil.state == 0)
                        {
                            myCeil.CreateDir(Dirs.Left);
                            addCeil.CreateDir(Dirs.Right);
                            addCeil.backWay = new Vector2(x + 1, y);
                        }
                    }

                    break;
                case Dirs.Right:

                    if (x < mapSize.x - 1)
                    {
                        x++;
                        Ceil addCeil = ceils[x, y];

                        if (addCeil.state == 0)
                        {
                            myCeil.CreateDir(Dirs.Right);
                            addCeil.CreateDir(Dirs.Left);
                            addCeil.backWay = new Vector2(x - 1, y);
                        }
                    }

                    break;
                case Dirs.Top:

                    if (y < mapSize.y - 1)
                    {
                        y++;
                        Ceil addCeil = ceils[x, y];

                        if (addCeil.state == 0)
                        {
                            myCeil.CreateDir(Dirs.Top);
                            addCeil.CreateDir(Dirs.Bottom);
                            addCeil.backWay = new Vector2(x, y - 1);
                        }
                    }

                    break;
                case Dirs.Bottom:

                    if (y > 0)
                    {
                        y--;
                        Ceil addCeil = ceils[x, y];

                        if (addCeil.state == 0)
                        {
                            myCeil.CreateDir(Dirs.Bottom);
                            addCeil.CreateDir(Dirs.Top);
                            addCeil.backWay = new Vector2(x, y + 1);
                        }
                    }
                    break;
                case Dirs.None:
                    myCeil.state = 2;
                    x = (int)(myCeil.backWay.x);
                    y = (int)(myCeil.backWay.y);
                    break;
            }

        }
        
    }
}
