using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelAbstract : MonoBehaviour
{
  public static short lev;

  public virtual void JsonLoad()
  {

lev = 1;
  }

}
