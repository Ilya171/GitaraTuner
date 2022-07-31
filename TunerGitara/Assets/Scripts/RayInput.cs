using UnityEngine;
public class RayInput : MonoBehaviour
{

  
     Ray ray1;


    public virtual void RayStart()
    {
        

          //  ToStartposition(_secondFinger);
            ray1 = new Ray(transform.position,transform.forward);
            Debug.DrawLine(ray1.origin, ray1.direction * 10, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(ray1.origin, ray1.direction);
            if (hit)
            {
                Debug.Log("hit");
                
                transform.position = new Vector3(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y, -7);
               
                StringSound audio = hit.collider.gameObject.GetComponent<StringSound>();
                //aydio    ++++
                audio.Play();
            }
        
        
      
        

    }

}
