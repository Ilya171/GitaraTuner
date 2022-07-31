using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fret : MonoBehaviour
{
    // Start is called before the first frame update
    public static float _sp;
    void Start()
    {
  
        
    }

    // Update is called once per frame
    void Update()
    { 
        transform.Translate(Vector3.left * _sp * Time.deltaTime, Space.World);
        if (transform.position.x < -12.92 /* finishpossition */)
        {
            ToStart();
    }
}

void ToStart(){
    gameObject.transform.position = new Vector3 (21.48f,1.36f,-7.39f);
}

}
