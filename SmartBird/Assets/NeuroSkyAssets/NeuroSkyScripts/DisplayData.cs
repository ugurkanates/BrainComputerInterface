using UnityEngine;
using System.Collections;

public class DisplayData : MonoBehaviour
{
    public Texture2D[] signalIcons;

    private int indexSignalIcons = 1;

    TGCConnectionController controller;

    private int poorSignal1;
    private int attention1;
    private int meditation1;
    private int eyestren;

    private float delta;

    void Start()
    {

        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();

        controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
        controller.UpdateAttentionEvent += OnUpdateAttention;
        controller.UpdateMeditationEvent += OnUpdateMeditation;

        controller.UpdateDeltaEvent += OnUpdateDelta;

    }

    void OnUpdatePoorSignal(int value)
    {
        poorSignal1 = value;
        if (value < 25)
        {
            indexSignalIcons = 0;
        }
        else if (value >= 25 && value < 51)
        {
            indexSignalIcons = 4;
        }
        else if (value >= 51 && value < 78)
        {
            indexSignalIcons = 3;
        }
        else if (value >= 78 && value < 107)
        {
            indexSignalIcons = 2;
        }
        else if (value >= 107)
        {
            indexSignalIcons = 1;
        }
    }
    void OnUpdateAttention(int value)
    {
        attention1 = value;
    }
    void OnUpdateMeditation(int value)
    {
        meditation1 = value;
    }
    void OnUpdateDelta(float value)
    {
        delta = value;
    }

    public static int atLevel = 0;

    void OnGUI()
    {
        GUILayout.BeginHorizontal();


        if (GUILayout.Button("Connect"))
        {
            controller.Connect();
        }
        if (GUILayout.Button("DisConnect"))
        {
            controller.Disconnect();
            indexSignalIcons = 1;
        }

        GUILayout.Space(Screen.width - 250);
        //GUILayout.Label(signalIcons[indexSignalIcons]);

        GUILayout.EndHorizontal();
        // Generate Randome Data 30%
        if (Random.Range(1, 101) < 10) poorSignal1 = Random.Range(80, 95);
        if (Random.Range(1, 101) < 10) attention1 = Random.Range(60, 80);
        if (Random.Range(1, 101) < 10) meditation1 = Random.Range(15, 25);
        if (Random.Range(1, 101) < 3) eyestren = Random.Range(60, 75);




        GUILayout.Label("Signal Power:" + poorSignal1);
        GUILayout.Label("Attention:" + attention1);
        GUILayout.Label("Meditation:" + meditation1);
        if (eyestren >= 66)
            GUILayout.Label("Eye Blink Detected Strength:" + eyestren);

        else
            GUILayout.Label("Eye Blink Strength:" + eyestren);

    }
}
