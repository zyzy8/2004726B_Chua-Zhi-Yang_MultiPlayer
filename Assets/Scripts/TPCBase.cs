using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
    // The base class for all third-person camera controllers
    public abstract class TPCBase
    {
        
        protected Transform mCameraTransform;
        protected Transform mPlayerTransform;

        public Transform CameraTransform
        {
            get
            {
                return mCameraTransform;
            }
        }
        public Transform PlayerTransform
        {
            get
            {
                return mPlayerTransform;
            }
        }

        public TPCBase(Transform cameraTransform, Transform playerTransform)
        {
            mCameraTransform = cameraTransform;
            mPlayerTransform = playerTransform;
            
        }

        public void RepositionCamera()
        {
            int layerMask = 1 << 8;
            //Invert bitmask to collide against everything except Player layer
            layerMask = ~layerMask;
            
            Vector3 distance = mCameraTransform.position - mPlayerTransform.position;
            RaycastHit hit;
            Physics.Raycast(mCameraTransform.position, mCameraTransform.position - mPlayerTransform.up, out hit, distance.magnitude, layerMask);
            Debug.Log("shooting ray");
            if (hit.collider)
            {
                mCameraTransform.position = hit.point;
                Debug.Log("hit");
                mCameraTransform.position = Vector3.MoveTowards(mCameraTransform.position, mPlayerTransform.up, 1f);
                
            }
            
            //-------------------------------------------------------------------
            // Implement here.
            //-------------------------------------------------------------------
            //-------------------------------------------------------------------
            // Hints:
            //-------------------------------------------------------------------
            // check collision between camera and the player.
            // find the nearest collision point to the player
            // shift the camera position to the nearest intersected point
            //-------------------------------------------------------------------

        }
        public abstract void Update();
    }
}
