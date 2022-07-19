using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZoiStudio.InputManager;

// This is just a sample. You should implement your own input handler class
public class InputHandler : MonoBehaviour, IInputListener
{
    public List<InputAction> gameActions;

    public virtual void OnEnable()
    {
        InputEventManager.Subscribe(this, gameActions.Select(x => x.Action).ToArray());
    }

    public virtual void OnInput(InputActionArgs input)
    {
        var inputAction = gameActions.Where(x => x.Action == input.Action).First();
        if (inputAction.OnAction != null)
        {
            inputAction.OnAction.Invoke();
        }
    }

    public virtual void OnDisable()
    {
        InputEventManager.UnSubscribe(this, gameActions.Select(x => x.Action).ToArray());
    }
}
