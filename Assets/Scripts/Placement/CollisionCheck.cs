using UnityEngine;
using System.Collections;

namespace Rom
{
    public class CollisionCheck : MonoBehaviour
    {

        /// <summary>
        /// Collision Check For Overlap Building
        /// </summary>
        /// <param name="col"></param>
        void OnCollisionEnter(Collision col)
        {
            Debug.Log("Here");
            Debug.Log(col.gameObject.name.ToString());
            if (col.gameObject.name == "Plane")
            {
                MainController.instance.isOverlap = false;
            }
            else
            {
                MainController.instance.isOverlap = true;
            }
                

        }

        /// <summary>
        /// Collision BuildingExit
        /// </summary>
        /// <param name="collisionInfo"></param>
        void OnCollisionExit(Collision collisionInfo)
        {
            MainController.instance.isOverlap = false;
        }
    }
}
