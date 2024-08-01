using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(menuName = "States/OtherState")]
public class State : ScriptableObject
{
    public bool IsFinished { get; protected set; }
    public bool IsLoop = false;
    public bool Active = true;
    [HideInInspector] public Character Character;

    public virtual void Init() { }
    public virtual void Init(GameObject thisObject, GameObject followObject) { }

    public virtual void Run() { }

}
