using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 * Transforms of the walls so we maze algorithm knows where they are so they can be deleted.
 * 
 */

public class VisualCell : MonoBehaviour {

    public Transform East;
    public Transform West;
    public Transform North;
    public Transform South;

}
