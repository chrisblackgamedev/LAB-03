using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshController : MonoBehaviour
{

    public GameObject Target;
    private NavMeshAgent agent;

    bool isWalking=true;
    private Animator animator;

    float m_MySliderValue;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
            agent.destination = Target.transform.position;
        else
        {
            agent.destination = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Dragon")
        {
            isWalking = false;
            animator.SetTrigger("attacking");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Dragon")
        {
            isWalking = true;
            animator.SetTrigger("walking");
        }
    }

    /*void OnGUI()
    {
        //Create a Label in Game view for the Slider
        GUI.Label(new Rect(0, 25, 40, 60), "Speed");
        //Create a horizontal Slider to control the speed of the Animator. Drag the slider to 1 for normal speed.

        m_MySliderValue = GUI.HorizontalSlider(new Rect(45, 25, 200, 60), m_MySliderValue, 0.0F, 1.0F);
        //Make the speed of the Animator match the Slider value
        animator.speed = m_MySliderValue;
    }*/
}
