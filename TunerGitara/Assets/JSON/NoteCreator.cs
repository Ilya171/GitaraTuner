using System;
using System.IO;
using Json.Song1;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NoteCreator : MonoBehaviour
{
    public float bpm;
    [SerializeField] private float mesureCoefficient;

    [SerializeField] private Transform _beat;
    [SerializeField] private GameObject notePrefab;
    public static ScoreJson json;
    public float timer = 0;
    public int Note = 1;
    //public TextAsset Json;

    [Header("NotePossition")]
    [SerializeField] private Transform note6;
    [SerializeField] private Transform note5;
    [SerializeField] private Transform note4;
    [SerializeField] private Transform note3;
    [SerializeField] private Transform note2;
    [SerializeField] private Transform note1;
    public enum FingerColor
    {
        red,
        blue,
        green,
        yeloww,
        thumb
    }
    //public enum Finger{
    [SerializeField] private Sprite FingerRed;
    [SerializeField] private Sprite FingerBlue;
    [SerializeField] private Sprite FingerYelow;
    [SerializeField] private Sprite FingerGreen;
    [SerializeField] private Sprite FingerThumb;
    public Transform Frets;
    private Vector3 _notePossition;
    public string jsonText;
    string jsonString;
    public bool tiedString;
    
    #region Tied String
    private string tied_Strings;
    private bool tiedStringsCounter;
   
   
    #endregion
    void Start()
    {
        if (LevelAbstract.lev == 1)
        {
            var jsonString = Resources.Load<TextAsset>("FF7").text;
            json = ScoreJson.FromJson(jsonString);
            bpm = 60F / (float)json.score.Measure["1"].Bpm * (float)json.score.Measure["1"].Beat;
            Debug.Log($"bpm = {bpm}");


        }
        else if(LevelAbstract.lev==2)
        {
            var jsonString = Resources.Load<TextAsset>("Seven_Nation_Army_12").text;
            json = ScoreJson.FromJson(jsonString);
            bpm = 60F / (float)json.score.Measure["1"].Bpm * (float)json.score.Measure["1"].Beat;
            Debug.Log($"bpm = {bpm}");
        }
        else if(LevelAbstract.lev==3)
        {
            Debug.Log(LevelAbstract.lev);

            var jsonString = CanvasSampleOpenFileTextMultiple.ClientJson;
            json = ScoreJson.FromJson(jsonString.ToString());
            bpm = 60F / (float)json.score.Measure["1"].Bpm * (float)json.score.Measure["1"].Beat;
            Debug.Log($"bpm = {bpm}");
        }


        Debug.Log($"Level  {LevelAbstract.lev}");
        //string jsonString = Json.ToString();
        StartCoroutine(routine: StartCreate());
    }


    void MesureInstantaiate(string meseareIndex)
    {
        string _meseareIndex = meseareIndex;
        float xPoss = 0;

        Debug.Log($"<color=green>MEASURE {meseareIndex} </color>");//mesure number

        Debug.Log($"<color=blue>NOTES COUNT {json.score.Measure[_meseareIndex].Notes.Length} </color>");

        for (int note = json.score.Measure[_meseareIndex].Notes.Length - 1; note > -1; note--)
        {
           
            if (json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].TiedString.Length > 0 && tiedString)// если tiedString.Length > 0
                {
                    

  tied_Strings = json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].TiedString[0].ToString();

Debug.Log($"tiedString {tied_Strings}");


 //var _string = json.score.RightHand[Strings].String.ToString();
 //Debug.Log($"_strring {_string}");

                }

            

            var time = (float)json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].Time * bpm / 4; // 0.6f - beat
            xPoss += time;

            Debug.Log("Note : " + json.score.Measure[_meseareIndex].Notes[note]);
            Debug.Log($"POSSITION {xPoss}");


            Debug.Log("note time : " + json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].Time);

            if (json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].RightHand.Length > 0)// если есть правая рука
            {
                Debug.Log("rightHand : " + json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].RightHand[0]);
                Debug.Log("rightHand String" + json.score.RightHand[json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].RightHand[0].ToString()].String);
                var _string = json.score.RightHand[json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].RightHand[0].ToString()].String;
                switch (_string)
                {

                    case 1:
                        _notePossition = note1.transform.position;
                        break;
                    case 2:
                        _notePossition = note2.transform.position;
                        break;
                    case 3:
                        _notePossition = note3.transform.position;
                        break;
                    case 4:
                        _notePossition = note4.transform.position;
                        break;
                    case 5:
                        _notePossition = note5.transform.position;
                        break;
                    case 6:
                        _notePossition = note6.transform.position;
                        break;
                    default:
                        Debug.Log("НЕТ ТАКОЙ СТРУНЫ");
                        break;
                }
                
                var _note = Instantiate(notePrefab, new Vector3(_beat.position.x - xPoss * mesureCoefficient, _notePossition.y, -6f), Quaternion.identity);
                NoteData _notescript = _note.GetComponent<NoteData>();
                _notescript.NumberFret = 0;
                _notescript._String = (byte)json.score.RightHand[json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].RightHand[0].ToString()].String;
                _notescript.Finger = FingerRed;
                _notescript._color = NoteData.FingerColor.red;
                _notescript.duration = 0.6f * (float)json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].Time;
                _note.tag = "NoteDeleat";

            }
            if (json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].LeftHand.Length > 0)// если левая рука
            {
                var _string = json.score.LeftHand[json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].LeftHand[0].ToString()].String;
                var _fret = json.score.LeftHand[json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].LeftHand[0].ToString()].Fret;
                string _finger = json.score.LeftHand[json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].LeftHand[0].ToString()].Fingering.ToString();
                var _note = Instantiate(notePrefab, new Vector3(_beat.position.x - xPoss * mesureCoefficient, _notePossition.y, -7.4f), Quaternion.identity);
                _note.layer = 2;

                Debug.Log("leftHand" + json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].LeftHand[0]);
                Debug.Log("leftHand String" + json.score.LeftHand[json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].LeftHand[0].ToString()].String);
                Debug.Log("Fret" + json.score.LeftHand[json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].LeftHand[0].ToString()].Fret);
                Debug.Log("Finger" + json.score.LeftHand[json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].LeftHand[0].ToString()].Fingering);

                switch (_string)  // струна
                {

                    case 1:
                        _notePossition = note1.transform.position;
                        break;
                    case 2:
                        _notePossition = note2.transform.position;
                        break;
                    case 3:
                        _notePossition = note3.transform.position;
                        break;
                    case 4:
                        _notePossition = note4.transform.position;
                        break;
                    case 5:
                        _notePossition = note5.transform.position;
                        break;
                    case 6:
                        _notePossition = note6.transform.position;
                        break;
                    default:
                        Debug.Log("НЕТ ТАКОЙ СТРУНЫ");
                        break;
                }
                NoteData _notescript = _note.GetComponent<NoteData>();
                _notescript.NumberFret = (byte)_fret;
                _notescript.duration = bpm / 4f * (float)json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].Time;
                _notescript._String = (byte)json.score.LeftHand[json.score.Note[(json.score.Measure[_meseareIndex].Notes[note].ToString())].LeftHand[0].ToString()].String;
                _notescript.startRay = true;

                switch (_finger)// палец
                {

                    case "A":
                        //  Debug.Log("green");
                        _notescript.Finger = FingerGreen;
                        _notescript._color = NoteData.FingerColor.green;


                        break;

                    case "M":
                        // Debug.Log("blue");
                        _notescript.Finger = FingerBlue;
                        _notescript._color = NoteData.FingerColor.blue;
                        break;
                    case "I":
                        //  Debug.Log("red");
                        _notescript.Finger = FingerRed;
                        _notescript._color = NoteData.FingerColor.red;
                        break;
                    case "P":
                        //  Debug.Log("голубой");
                        _notescript.Finger = FingerThumb;
                        _notescript._color = NoteData.FingerColor.thumb;
                        break;
                    case "C":
                        // Debug.Log("yeloww");
                        _notescript.Finger = FingerYelow;
                        _notescript._color = NoteData.FingerColor.yeloww;
                        break;
                    default:
                        //  Debug.Log("НЕТ ТАКОГО ПАЛЬЦА");
                        break;

                }
            }
        }
    }
    IEnumerator StartCreate()
    {

        for (int i = 0; i < json.score.Timeline.Length; i++)
        {

            string _timelength = json.score.Timeline[i].ToString();
            MesureInstantaiate(_timelength);
            if (i > 1)
            {
                yield return new WaitForSeconds(bpm);// время через которое повторяется
            }
            else yield return new WaitForFixedUpdate();
        }
    }
}


