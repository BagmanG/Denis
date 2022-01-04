using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{
        NavMeshAgent agent;
        Animator animator;
        void Start() {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }
        
        void Update() {
            
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                    agent.destination = hit.point;
                }
            }

            if(ChekingForAnimation()==true){
                animator.SetBool("Walk",false);
                Debug.Log(true);
            }else{
                animator.SetBool("Walk",true);
                Debug.Log(false);
            }
        }

        bool ChekingForAnimation(){
            /*if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        return true;
                    }
                }
            }*/
            if(agent.remainingDistance < 0.5f){
                return true;
            }
            return false;
        }
}
