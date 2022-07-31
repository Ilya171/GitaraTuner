using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JulianSchoenbaechler.MicDecode;
using System;
using UnityEngine.Android;
public class NoteFreqency : MonoBehaviour
{

    private int audioError = 50; // погрешность
    [SerializeField] private int e, A, D, G, B, E;
    public float myFreqency, myNote;

    public void OnEnable()
    {

        MicDecode.notePlayed += Сhange;

    }

    private void OnDisable()
    {

        MicDecode.notePlayed -= Сhange;

    }
    void Сhange(float freqency)
    {

        myFreqency = freqency;
        if (/*freqency > e - audioError &&*/ freqency < e + audioError)
        {

            Debug.Log(e + "e");
            BasicUsage.note = BasicUsage.Note.e;
            myNote = e;



        }
        else if (freqency > (A - (A-e)/2) && freqency < (A + (D-A)/2))
        {
            Debug.Log(A + "A");
            BasicUsage.note = BasicUsage.Note.A;
            myNote = A;

        }
        else if (freqency > (D - (D - A) / 2) && freqency < (D + (G-D)/2))
        {
            Debug.Log(D + "D");
            BasicUsage.note = BasicUsage.Note.D;
            myNote = D;

        }
        else if (freqency > (G - (G - D) / 2) && freqency < (G + (B-G)/2))
        {
            Debug.Log(G + "G");
            BasicUsage.note = BasicUsage.Note.G;
            myNote = G;

        }
        else if (freqency > (B - (B - G) / 2) && freqency < (B + (E-B)/2))
        {
            Debug.Log(B + "B");
            BasicUsage.note = BasicUsage.Note.B;
            myNote = B;
        }
        else if (freqency > E - audioError /*&& freqency < E + audioError*/)
        {
            Debug.Log(E + "E");
            BasicUsage.note = BasicUsage.Note.E;
            myNote = E;

        }
        /////////////////////
        //if (freqency > e - audioError && freqency < e + audioError)
        //{

        //    Debug.Log(e + "e");
        //    BasicUsage.note = BasicUsage.Note.e;
        //    myNote = e;



        //}
        //else if (freqency > A - audioError && freqency < A + audioError)
        //{
        //    Debug.Log(A + "A");
        //    BasicUsage.note = BasicUsage.Note.A;
        //    myNote = A;

        //}
        //else if (freqency > D - audioError && freqency < D + audioError)
        //{
        //    Debug.Log(D + "D");
        //    BasicUsage.note = BasicUsage.Note.D;
        //    myNote = D;

        //}
        //else if (freqency > G - audioError && freqency < G + audioError)
        //{
        //    Debug.Log(G + "G");
        //    BasicUsage.note = BasicUsage.Note.G;
        //    myNote = G;

        //}
        //else if (freqency > B - audioError && freqency < B + audioError)
        //{
        //    Debug.Log(B + "B");
        //    BasicUsage.note = BasicUsage.Note.B;
        //    myNote = B;
        //}
        //else if (freqency > E - audioError && freqency < E + audioError)
        //{
        //    Debug.Log(E + "E");
        //    BasicUsage.note = BasicUsage.Note.E;
        //    myNote = E;

        //}

    }


    public GameObject strelka;
    public bool start = false;

    public float zRot;
    public Quaternion targetRot;



    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        strelka.transform.rotation = Quaternion.Euler(0, 180, 90);
        targetRot = strelka.transform.rotation;
        myNote = e;

        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Debug.Log("mircoON!");
        }
        else
        {
            bool useCallbacks = false;
            if (!useCallbacks)
            {
                Permission.RequestUserPermission(Permission.Microphone);
            }
        }
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);

        }
    }

    void Update()
    {
        //Debug.Log(zRot);
        if (start)
        {
            //Debug.Log("myNot="+myNote);
            //Debug.Log("freq=" + myFreqency);     


            zRot = 90f * myFreqency / myNote;
            if (zRot <= -15f) zRot = -15f;
            if (zRot >= 195f) zRot = 195f;

            targetRot = Quaternion.Euler(0, 180, zRot);
            strelka.transform.rotation = Quaternion.Lerp(strelka.transform.rotation, targetRot, Time.deltaTime * 3f);




        }
    }
    public void ClickStart()
    {
        if (start) start = false;
        else start = true;
    }


}