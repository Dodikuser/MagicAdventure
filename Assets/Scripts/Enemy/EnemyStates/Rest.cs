using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/RestState")]
public class Rest : State
{
    public override void Run()
    {
        
    }
    public override void Init()
    {
        IsLoop = false;
    }
}
