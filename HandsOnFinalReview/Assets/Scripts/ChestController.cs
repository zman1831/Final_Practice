using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour {

    public enum ChestState {Closed, Open}; //two states of all chests
    public Transform playerTransform;
    public int bootyPoints; //each chest has a number of points that the player picks up
    private float openDistance = 3f;

    private Animator anim;
    private ChestState activeState = ChestState.Closed; //default state of all chests

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        ChangeState(activeState);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void ChangeState(ChestState currentState)
    {
        StopAllCoroutines();
        //Set new state
       activeState = currentState;
       switch (activeState)
       {
            case ChestState.Open:
                StartCoroutine("isOpen");
                break;
            case ChestState.Closed:
                StartCoroutine("isClosed");
                break;
       }
        //Activates new state
    }
    IEnumerator isOpen()
    {
        anim.SetBool("IsOpen", true);
        anim.SetBool("IsClosed", false);
        while (true)
        {
            if (Vector3.Distance(playerTransform.position, transform.position) > openDistance)
            {
                ChangeState(ChestState.Closed);
                yield break;
            }
            activeState = ChestState.Open;
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator isClosed()
    {
        anim.SetBool("IsOpen",false);
        anim.SetBool("IsClosed", true);

        while (true)
        {
            if (Vector3.Distance(playerTransform.position, transform.position) < openDistance)
            {
                ChangeState(ChestState.Open);
                yield break;
            }
            activeState = ChestState.Closed;
            yield return new WaitForSeconds(1f);
        }
    }

}
