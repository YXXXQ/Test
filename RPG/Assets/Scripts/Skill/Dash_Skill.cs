using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Skill :Skill
{
    protected override void UseSkill()
    {
        base.UseSkill();
        Debug.Log("创建一个分身");
    }
}
