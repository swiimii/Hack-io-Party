using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SceneScripts.Level1
{
    public class BalloonLevel : LevelState
    {
        public GameObject balloonObject;

        public override bool IsAtTargetState()
        {

            return balloonObject.GetComponent<Balloon>().transform.position.y > 14;
        }
    }
}
