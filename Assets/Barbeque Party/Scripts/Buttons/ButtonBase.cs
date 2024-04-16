using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{
    protected Button button;


    protected virtual void Start() 
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnPressed);
    }

    protected abstract void OnPressed();
}
