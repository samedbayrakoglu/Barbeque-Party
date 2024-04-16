using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinButton : ButtonBase
{
    private EventManager eventManager;



    protected override void Start()
    {
        base.Start();

        eventManager = FindObjectOfType<EventManager>();
    }

    private void ReadyForSpin()
    {
        button.interactable = true;
    }

    protected override void OnPressed()
    {
        if(eventManager)
            eventManager.SpinOrder();
            
        button.interactable = false;
    }

    private void OnDestroy() 
    {
       
    }
}
