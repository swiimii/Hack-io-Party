using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SceneScripts.Level5
{
    public enum StepPosition
    {
        Left,
        Right,
        Center
    }

    public enum StepDirection
    {
        Left,
        Right
    }

    public class Step
    {
        public StepDirection entryDirection { get; set; }
        public StepPosition targetPosition { get; set; }
    }
}
