using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Transform Player;
    private Enemy_Skeleton enemy;
    private int moveDir;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        Player = PlayerManager.instance.player.transform;
    }

    public override void Update()
    {
        base.Update();

        if(enemy.IsPlayerDetected())
        {
            stateTime = enemy.battleTime;
            if(enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if(CanAttack())
                {
                stateMachine.ChangeState(enemy.attackState);

                }
            }    
        }
        else 
        {
            if (stateTime < 0 || Vector2.Distance(Player.transform.position,enemy.transform.position)>15)
            {
            stateTime = 0;

            }
        }
        if(Player.position.x>enemy.transform.position.x)
        {
            moveDir = 1;
        }
        else if(Player.position.x<enemy.transform.position.x)
        {
            moveDir = -1;
        }

        enemy.SetVelocity(enemy.moveSpeed * moveDir,rb.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    private bool CanAttack()
    {
        if(Time.time >=enemy.lastTimeAttacked + enemy.attackCoolDown)
        {
            enemy.lastTimeAttacked = Time.time; 
            return true;
        }
        return false;
    }
}
