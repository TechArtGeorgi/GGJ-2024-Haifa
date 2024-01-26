using UnityEngine;

namespace lerpers
{
    public struct float_lerp
    {
        private float start;
        private float end;
        private AnimationCurve curve;
        private Timer timer;

        public float_lerp(float start = 0.0f, float end = 0.0f, AnimationCurve Curve = null)
        {
            this.start = start;
            this.end = end;

            if (Curve == null)  curve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
            else                curve = Curve;

            timer = new Timer(1.0f);
        }

        public void setStart(float start)
        {
            this.start = start;
        }
        public void setEnd(float end)
        {
            this.end = end;
        }
        public void StartLerp()
        {
            timer.SetTimerTime(1.0f);
            timer.ActivateTimer();
        }
        public float UpdateTimer(float amout)
        {
            timer.SubtractTimerByValue(amout);
            return Mathf.LerpUnclamped(start, end, curve.Evaluate(timer.GetCurrentTime()));
        }
    }

    public struct Vector3_lerp
    {
        private Vector3 start;
        private Vector3 end;
        private AnimationCurve curve;
        private Timer timer;

        public Vector3_lerp(Vector3 start, Vector3 end, AnimationCurve Curve = null)
        {
            this.start = start;
            this.end = end;

            if (Curve == null)  curve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
            else                curve = Curve;

            timer = new Timer(1.0f);
        }
        public void setStart(Vector3 start)
        {
            this.start = start;
        }
        public void setEnd(Vector3 end)
        {
            this.end = end;
        }
        public void StartLerp()
        {
            timer.SetTimerTime(1.0f);
            timer.ActivateTimer();
        }
        public Vector3 UpdateTimer(float amout)
        {
                timer.SubtractTimerByValue(amout);
                return Vector3.LerpUnclamped(start, end, curve.Evaluate(timer.GetCurrentTime()));
        }
    }
}
