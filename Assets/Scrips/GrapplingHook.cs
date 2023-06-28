using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public CharacterController controller;
    public Transform grapplingHook;
    public Transform handPositon;
    public Transform playerBody;
    public LayerMask grappleLayer;
    public float maxGrappleDistance;
    public float hookSpeed;
    public Vector3 offset;

    private bool isShooting, isGrappling;
    private Vector3 hookPoint;

    private void Start()
    {
        isShooting = false;
        isGrappling = false;
    }

    private void Update()
    {

        if (grapplingHook.parent == handPositon)
        {
            grapplingHook.localPosition = new Vector3(0, 0, 0);
            grapplingHook.localRotation = Quaternion.Euler(new Vector3(0, 0, 0)); //these lines are so once you use the grappling hook and it gets parented back to you, it sticks in the right spot rather then where ever it was reletive to where you were looking; for instance if you grapple to a point, looking away from that point, the grappling hook wont parent to you behind you. It will parent to the needed position, in your hand.
        }

        if(Input.GetMouseButtonDown(1))
        {
            ShootHook();
        }

        if (isGrappling)
        {
            grapplingHook.position = Vector3.Lerp(grapplingHook.position, hookPoint, hookSpeed * Time.deltaTime);
            if(Vector3.Distance(grapplingHook.position, hookPoint) < 0.5f)
            {
                controller.enabled = false; //This disables your character controller while grappling
                playerBody.position = Vector3.Lerp(playerBody.position, hookPoint - offset, hookSpeed * Time.deltaTime);
                if (Vector3.Distance(playerBody.position, hookPoint -offset) < 0.5f) //Grappling hook launching speed check for if you can disable your character.
                {
                    controller.enabled = true;
                    isGrappling = false;
                    grapplingHook.SetParent(handPositon); //Theses lines here make it so that once you reach your destination the grappling hook will disconnect, and so that your conntroller will be re enabled, respectively.
                }
            }

            
        }
    }

    private void ShootHook()
    {
        if (isShooting || isGrappling) return; //so during any point between firing the grappling hook and the grappling hook disconecting, which is "when firing" we can't fire further more.

        isShooting = true;
        RaycastHit hit; //just the raycast, if we arent projecting a ray when we are firing, we will
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, maxGrappleDistance, grappleLayer))
        {
            hookPoint = hit.point;
            isGrappling = true;
            grapplingHook.parent = null;
            grapplingHook.LookAt(hookPoint);
        }

        isShooting = false;
    }
}
