using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Using MicDecode
using JulianSchoenbaechler.MicDecode;

public class BasicUsage : MonoBehaviour
{
	private const float Y=-4.2f;
	private const float Z =90f;
	public static GameObject CirclePos;
    public MicDecode microphone;        // The MicDecode component (assign in inspector)
    public Text buttonText;             // The Text component of the start/stop button (assign in inspector)
    public Text displayText;            // The Text component of the displayed text (assign in inspector)

    public enum Note { e, A, D, G, B, E }
    static Note _note;
    public static Note note
    {

        get
        {
            return _note;
        }
        set
        {

            _note = value;
			switch (_note)
			{
				case Note.e:
				CirclePos.transform.localPosition = new Vector3(-6.7f,Y,Z)  ;
				break;
				case Note.A:
				CirclePos.transform.localPosition = new Vector3(-5.79f,Y,Z)  ;
				break;
				case Note.D:
				CirclePos.transform.localPosition = new Vector3(-4.846f,Y,Z)  ;
				break;
				case Note.G:
				CirclePos.transform.localPosition = new Vector3(-3.926f,Y,Z)  ;
				break;
				case Note.B:
				CirclePos.transform.localPosition = new Vector3(-2.92F,Y,Z)  ;
				break;
				case Note.E:
				CirclePos.transform.position = new Vector3(-2.01f,Y,Z)  ;
				break;

			}


			
        }
    }

    private int frequencyError = 10;

    // Initialization
    void Start()
    {
		

        buttonText.text = "Start";
		CirclePos = GameObject.Find("SelectedCircle");
    }

    // Every frame
    void Update()
    {

        if (microphone.Frequency > frequencyError)
        {
            //note = Note.e;
        }



        // Display calculated values
        displayText.text = "Volume: " + microphone.VolumeDecibel.ToString("F1") + "dB\n" +
                            "Frequency: " + (microphone.Frequency/* /3.6990881459f */).ToString("F0") + "Hz\n" +
                            "Note:" + note;
    }

    // Button pressed
    public void ButtonPressed()
    {
        if (microphone.IsRecording)
        {
            // Stop recording
            microphone.StopRecording();
            buttonText.text = "Start";
        }
        else
        {
            // Start recording
            microphone.StartRecording();
            buttonText.text = "Stop";
        }
    }

    
    public Note GetNote() {
        return _note;
    }

}
