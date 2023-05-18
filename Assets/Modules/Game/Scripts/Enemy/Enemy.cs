using System;
using Modules.HitMasterGame.Scripts.Player;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Modules.Game.Scripts.Enemy
{
    public class Enemy : Unit
    {
        [SerializeField] protected UnitBattleStats unitBattleStats;
        [SerializeField] protected NavMeshAgent navMeshAgent;
        [SerializeField] protected Rigidbody rigidbody;
        
        private int wayPointIndex = 0;
        private WayPoint currentWayPoint;

        private Player.Player player;
        private EnemyPatrolPathway patrolPathway;
        [Inject]
        private void Construct(EnemyPatrolPathway patrolPathway, Player.Player player)
        {
            this.player = player;
            
            SetupWayPoint(patrolPathway);
        }

        private void SetupWayPoint(EnemyPatrolPathway patrolPathway)
        {
            this.patrolPathway = patrolPathway;
        }


        private void Start()
        {
            navMeshAgent.speed = unitMovementStats.Speed;

            rigidbody.isKinematic = true;
            
            GetNextPoint();
        }

        private void Update()
        {
            if (navMeshAgent.enabled)
            {
                if (IsPlayerNearby())
                {
                    navMeshAgent.destination = player.transform.position;
                }
                if (IsPointReached())
                {
                    GetNextPoint();
                }
            }
        }

        private bool IsPlayerNearby()
        {
            return Vector3.Distance(transform.position, player.transform.position) <= unitBattleStats.ActiveRadius;
        }

        private void GetNextPoint()
        {
            wayPointIndex++;
            if (wayPointIndex >= patrolPathway.WayPoints.Length)
            {
                wayPointIndex = 0;
            }

            currentWayPoint = patrolPathway.WayPoints[wayPointIndex];
            navMeshAgent.destination = currentWayPoint.Point.position;
        }

        private bool IsPointReached()
        {
            return Vector3.Distance(transform.position, currentWayPoint.Point.position) <= currentWayPoint.Radius;
        }
    }
}
