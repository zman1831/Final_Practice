using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //might be a good spot for some delegates

    //Internal reference to single active instance of object - for singleton behaviour
    private static GameManager instance = null;
    //--------------------------------------------------------------
    //public properties
    //C# property to retrieve currently active instance of object, if any
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameObject("GameManager").AddComponent<GameManager>(); //create game manager object if required
            return instance;
        }
    }

    int _booty; //the booty/score value for the game
    public int booty
    {
        get
        {
            return this._booty;
        }
        set
        {
            if (value > 0)
                this._booty = value;
        }
    }

    void Awake()
    {
        //Check if there is an existing instance of this object
        if ((instance) && (instance.GetInstanceID() != GetInstanceID()))
            DestroyImmediate(gameObject); //Delete duplicate
        else
        {
            instance = this; //Make this object the only instance
            DontDestroyOnLoad(gameObject); //Set as do not destroy
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
