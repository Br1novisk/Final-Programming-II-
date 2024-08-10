using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This component is added to each limb to allow for the OnCollisionEnter function
/// to be called on the Teddy itself. This is useful for the in-class assignment
///
/// Note: SendMessage is NOT a good way to call functions, but it is used here to simplify
/// the logic for students. An better way would be to use GetComponentInParent().Function()
/// </summary>
public class LimbCollision : MonoBehaviour
{
    CharacterJoint joint;

    void Awake()
    {
        //In case the Rigidbody component was removed from the Teddy object, we assign it back like this.
        joint = GetComponent<CharacterJoint>();
        if (joint)
        {
            if (joint.connectedBody == null)
            {
                //Search for the first Rigidbody parent that is not a CharacterJoint
                Rigidbody rb = GetComponentInParent<Rigidbody>();
                while (rb.GetComponent<CharacterJoint>() != null)
                {
                    Rigidbody parentRb = rb.transform.parent?.GetComponentInParent<Rigidbody>();
                    if (parentRb == null)
                        return;
                }

                joint.connectedBody = rb;
            }
                
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        //Avoid collision with other limbs, and send message upwards to the parent
        if (collision.gameObject.GetComponent<LimbCollision>() == null && transform.parent != null)
        {
            transform.parent.SendMessageUpwards("OnCollisionEnter", collision, SendMessageOptions.DontRequireReceiver);
        }
    }
}
