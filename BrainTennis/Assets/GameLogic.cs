using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    public static int atLevel = 0;

    public GUISkin layout;

    GameObject theBall;

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");


    }
    public static void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
    }
    void OnGUI()
    {
        GUILayout.BeginHorizontal();

        /*for (int i = 0; i < 100; i++)
            signalIcons[i] = new Texture2D(2, 2);
        signalIcons[1].LoadImage(binaryImageData1);*/
        Texture2D t = new Texture2D(4, 4);
        byte[] binaryImageData1 = File.ReadAllBytes("Assets/signal_connected.png");

        t.LoadImage(binaryImageData1);
        

        if (GUILayout.Button("Connect"))
        {
            //controller.Connect();
            print("CLICKE CONNECT BUTTON");
        }
        if (GUILayout.Button("DisConnect"))
        {
           // controller.Disconnect();
            //indexSignalIcons = 1;
        }

        GUILayout.Space(Screen.width - 250);

        GUILayout.Label(t);

        GUILayout.EndHorizontal();

        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);
        //GUI.Label(new Rect(Screen.width / 2 + -60, 55, 120, 53), "Attention:");
       // GUILayout.Label("Attention:" + 45);
       // GUILayout.Label("Meditation1:" + 23);
       // GUILayout.Label("Eye Blink Strentgh" + 75);
        //       GUI.Label(new Rect(Screen.width / 2 + -60, 35, 120, 53), "Direction:"); 




        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
