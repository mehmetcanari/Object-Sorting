﻿using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kozar.Science
{
    [CreateAssetMenu(fileName = "Point Data", menuName = "Point Manager", order = 0)]
    public sealed class GameScoreHandler : ScriptableObject, IPointHandler
    {
        #region PRIVATE FIELDS

        [SerializeField] private int point;

        #endregion

        #region PUBLIC PROPERTIES

        public int GetPoint => point;

        #endregion

        #region PUBLIC METHODS
        
        public void AddPoint(int point)
        {
            this.point += point;
        }

        public void RemovePoint(int point)
        {
            this.point -= point;
            
            if(this.point < 0)
                this.point = 0;
        }

        public void ResetPoint()
        {
            point = 0;
        }

        #endregion
    }

    public interface IPointHandler
    {
        void AddPoint(int point);
        
        void RemovePoint(int point);
        
        void ResetPoint();
    }
}