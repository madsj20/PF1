using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

namespace QuickStart
{
    public class PlayerController : NetworkBehaviour
    {
        public NavMeshAgent player;
        private Camera camera;

        private void Awake()
        {
            camera = FindObjectOfType<Camera>();
        }

        private void Start()
        {
            gameObject.tag = "Player";
        }

        void Update()
        {
            if (isLocalPlayer)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit destination;

                    if (Physics.Raycast(ray, out destination))
                    {
                        player.SetDestination(destination.point);
                    }
                }
                if (Input.GetKeyDown("space"))
                {
                    //Shoot();
                }
            }
        }
    }
}