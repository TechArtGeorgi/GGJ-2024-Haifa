using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ScriptableObjects
{
    [System.Serializable]
    public struct prank
    {
        public int index;
        public GameEvent gameEvent;
    }

    [CreateAssetMenu(fileName = "NewGameEvent", menuName = "NewGameEvent")]
    public class GameEvent : ScriptableObject
    {
        [SerializeField] private prank log;
        [SerializeField] public Vector3 position;

        private List<GameEventListener<prank>> listeners = new List<GameEventListener<prank>>();

        public void Invoke()
        {
            log.gameEvent = this;
            foreach (GameEventListener<prank> a in listeners)
            {
                a.OnEventRaise(log);
            }
        }

        public void AddListener(GameEventListener<prank> ls)
        {
            listeners.Add(ls);
        }

        public void RemoveListener(GameEventListener<prank> ls)
        {
            listeners.Remove(ls);
        }
    }
}
