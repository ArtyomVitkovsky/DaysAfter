using Modules.HitMasterGame.Scripts.Player;
using UnityEngine;
using UnityEngine.Events;

namespace Modules.Game.Scripts.Enemy
{
    public class EnemyPatrolPathway : MonoBehaviour
    {
        [SerializeField] private WayPoint[] wayPoints;

        public WayPoint[] WayPoints => wayPoints;
    }
}