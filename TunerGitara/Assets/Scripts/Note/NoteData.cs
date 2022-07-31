using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;




public class NoteData : RayInput
{

    public bool startRay;

    [SerializeField] private Transform RedFingher;

    /*    [SerializeField] private Transform BlueFingher;
       [SerializeField] private Transform GreenFingher;
       [SerializeField] private Transform YellowFingher;
       [SerializeField] private Transform TurquoiseFingher; */




    public GameObject lowerFretXPossitionData;
    public int NumberFret;
    public int _String;

    public enum FingerColor
    {
        red,
        blue,
        green,
        yeloww,
        thumb
    }
    public FingerColor _color;
    private readonly Vector3 startPos = new Vector3(-20, -25f, -7);

    public Sprite Finger;
    public float duration;
    [SerializeField] private GameObject RayFinger;
    [SerializeField] private GameObject Red_Finger;
    [SerializeField] private GameObject Blue_Finger;
    [SerializeField] private GameObject Green_Finger;
    [SerializeField] private GameObject Yellow_Finger;
    [SerializeField] private GameObject Torquoise_Finger , _light;

    [SerializeField] private GameObject triangle;
    [SerializeField] private TMP_Text _numberFret;
    [SerializeField] private Image FingerPlase;
    [SerializeField] private SpriteRenderer BackGround;


    public /* static */ float spead = 1.3f;
    
    [Header("на сколько увуличивается размер ноты")][SerializeField] float scaleboost = 0.2f;

    [SerializeField] private bool a;


    [HideInInspector] public bool playingNow = false;

    LowerFretPossition data;


    [Range(0, 6)] public int String;
    /*    public CreateNote(int _numberFret, int Finger, int String)
    {

    } */

    private void Start()
    {
        Fret._sp = spead;
        Red_Finger = GameObject.FindGameObjectWithTag("1finger");
        triangle = GameObject.FindGameObjectWithTag("Triangle");
        RayFinger= GameObject.FindGameObjectWithTag("RayFinger");
        _light = GameObject.FindGameObjectWithTag("Light");
        
        Blue_Finger = GameObject.FindGameObjectWithTag("2finger");
        Green_Finger = GameObject.FindGameObjectWithTag("3finger");
        Yellow_Finger = GameObject.FindGameObjectWithTag("4finger");
        Torquoise_Finger = GameObject.FindGameObjectWithTag("5finger");
        



        


        lowerFretXPossitionData = GameObject.FindGameObjectWithTag("Data");



        data = lowerFretXPossitionData.GetComponent<LowerFretPossition>();
        //FingerPlase.sprite = FingerA;
        _numberFret.text = NumberFret.ToString();
        FingerPlase.sprite = Finger;
    }



    private void Update()
    {
        if (startRay)
        {

           RayStart();
        

        }

        CheckPlaingNote();





        transform.Translate(Vector3.left * spead * Time.deltaTime, Space.World);

        if (transform.position.x < -7f /* finishpossition */)
        {
            
            
            BackGround.GetComponent<SpriteRenderer>()
            .DOColor(Color.magenta,2)
            .SetLoops(2);


          

       

         

           
           // Destroy(gameObject, 5f);

            if (!a)
            {
                 switch (_color)
                {
                    case FingerColor.red:
                       
                        PlayNote(_String, NumberFret,  Red_Finger, duration);
                        break;
                    case FingerColor.blue:
                        
                        PlayNote(_String, NumberFret,  Blue_Finger, duration);
                        break;
                    case FingerColor.green:
                        
                        PlayNote(_String, NumberFret,  Green_Finger, duration);
                        break;

                    case FingerColor.yeloww:
                       
                        PlayNote(_String, NumberFret,  Yellow_Finger, duration);
                        break;
                    case FingerColor.thumb:
                        
                        PlayNote(_String, NumberFret,  Torquoise_Finger, duration);
                        break;
                }

                Play();
                _numberFret.DOColor(Color.white,0.5f)
                .SetLoops(2,LoopType.Yoyo)
          ;

               


                a = true;
            }




        }





    }


    public void Play()
    {
        BackGround.transform
        .DOScale(new Vector3(BackGround.transform.localScale.x + scaleboost, BackGround.transform.localScale.y + scaleboost, BackGround.transform.localScale.z + scaleboost), 0.4f/* время */)
        .SetEase(Ease.InSine)
        .SetLoops(2, LoopType.Yoyo);

    }

    void FirstFretMarkerAnim( GameObject marker,float yPos){
        
      
        marker.transform
        .DOMoveY(yPos - 0.15f,0.2f)
        .SetEase(Ease.InSine);
        Invoke("KillTriangke",0.25f);


    }
     void KillTriangke () 
     {
         triangle.transform.position = startPos;
         _light.transform.position = new Vector3(0,-10f,1);
         }






    void PlayNote(int _string, int fret,  GameObject _gameobj, float noteDuration)
    {
        _gameobj.transform.position = startPos;
        if (fret == 0)
        { // функция для первого лада

            float y = data.YpossitionFret[_string - 1].transform.position.y;
            RayFinger.transform.position = new Vector3(-7, y, -7);
            triangle.transform.position = new Vector3(-7, y, -7);
             StartCoroutine(ToStartPossition(triangle, noteDuration));
             FirstFretMarkerAnim( triangle,y);
             Invoke("KillTriangke",0.25f);
           
              _light.transform.position = new Vector3(0,y,-1);
           
                StartCoroutine(ToStartPossition(RayFinger, 0.04f));
           
        }
        else if (fret > 0)
        {
            float x = data.XpossitionFret[fret - 1].transform.position.x;
            float y = data.YpossitionFret[_string - 1].transform.position.y;
            
          
           triangle.transform.position = new Vector3(-7, y, -7);
           FirstFretMarkerAnim( triangle , y);
            
            
             

            RayFinger.transform.position = new Vector3(x, y, -7);
            _gameobj.transform.position = startPos;
            _gameobj.transform.position = new Vector3(x, y, -7);

            StartCoroutine(ToStartPossition(_gameobj, noteDuration-0.25f));
            StartCoroutine(ToStartPossition(RayFinger, 0.01f));

       
        }
    }










    IEnumerator ToStartPossition(GameObject _gameObject, float _delay)
    {
        Debug.Log("ToStartPossition");

        yield return new WaitForSeconds(_delay);
        _gameObject.transform.position = startPos;
    }


    public override void RayStart()
    {
            Ray ray1 = new Ray(transform.position,new Vector3 (0,0,1)*100);
        Debug.DrawLine(ray1.origin, ray1.direction * 10, Color.black);
        RaycastHit2D hit = Physics2D.Raycast(ray1.origin, ray1.direction);
        if (hit)
        {
            Debug.Log("000");
          Destroy(hit.collider.gameObject);

        }
        

    }

    void CheckPlaingNote() {
        if (transform.position.x < -6 && transform.position.x > -8)
        {
            playingNow = true;
        }
        else {
            playingNow = false;
        }
    }


    

}




