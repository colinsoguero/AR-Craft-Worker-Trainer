using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTrackingLogging : MonoBehaviour
{
    public void ObjectLookedAt()
    {
        ButtonLogging.instance.ObjectLookedAt(gameObject);
    }

    public void ObjectLookAway()
    {
        ButtonLogging.instance.ObjectLookAway(gameObject);
    }
}
