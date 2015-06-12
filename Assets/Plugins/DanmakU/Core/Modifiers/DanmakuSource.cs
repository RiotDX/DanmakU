// Copyright (c) 2015 James Liu
//	
// See the LISCENSE file for copying permission.

using System.Collections.Generic;
using UnityEngine;

namespace DanmakU.Modifiers {

    public class SourcePoint {

        public DFloat BaseRotation;
        public Vector2 Position;

        public SourcePoint(Vector2 location, DFloat rotation) {
            Position = location;
            BaseRotation = rotation;
        }

    }

    [System.Serializable]
    public abstract class DanmakuSource : DanmakuModifier {

        protected List<SourcePoint> SourcePoints;

        public DanmakuSource() {
            SourcePoints = new List<SourcePoint>();
        }

        protected abstract void UpdateSourcePoints(Vector2 position,
                                                   float rotation);

        public override sealed void OnFire(Vector2 position,
                                           DFloat rotation) {
            UpdateSourcePoints(position, rotation);
            for (int i = 0; i < SourcePoints.Count; i++) {
                FireSingle(SourcePoints[i].Position,
                           SourcePoints[i].BaseRotation);
            }
        }

        private void DrawGizmos() {
            //			UpdatePoints(transform.position, transform.rotation.eulerAngles.z);
            for (int i = 0; i < SourcePoints.Count; i++) {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(SourcePoints[i].Position, 1f);
                Gizmos.color = Color.red;
                Vector3 endRay = SourcePoints[i].Position +
                                 5*
                                 Util.OnUnitCircle(
                                                   SourcePoints[i].BaseRotation + 90f)
                                     .normalized;
                Gizmos.DrawLine(SourcePoints[i].Position, endRay);
            }
        }

    }

}