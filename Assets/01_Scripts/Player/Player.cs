using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gunggme
{
    public class Player : MonoBehaviour
    {
        public float SpeedOfTheBall; //speed of the ball in z axis(to move forward)
        public float Damping = 0.2f; //Smoothness of the ball when moving in x axis

        private void Update()
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Casting ray from screen to world
                RaycastHit hit; //A raycastHit variable to detect the ray
                if (Physics.Raycast(ray,
                        out hit)) //Physics.Raycast returns bool, if it hits something like tile, it will return true
                {
                    Vector3 point = hit.point; //Assigning the hit position of tile to point
                    point.z = gameObject.transform.position.z; //Ensuring that z axis doesn't change with hit
                    point.y = gameObject.transform.position.y; //ensuring y axis remains constant
                    gameObject.transform.position =
                        Vector3.MoveTowards(gameObject.transform.position, point,
                            Damping); //Moving the ball to above assigned Point position
                }
            }
            //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1f), SpeedOfTheBall);
            //Moving the ball forward towards z axis, Speed of the ball is needed here that how fast it will go
        }
    }
}
