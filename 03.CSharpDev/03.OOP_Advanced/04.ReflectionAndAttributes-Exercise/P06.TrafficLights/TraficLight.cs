namespace P06.TrafficLights
{
    public class TraficLight
    {
        public TraficLight(LightStates lightState)
        {
            this.LightState = lightState;
        }

        public LightStates LightState { get; private set; }

        public void Next()
        {
            this.LightState = (LightStates)(((int)this.LightState + 1) % 3);
        }

        public override string ToString()
        {
            return $"{this.LightState}";
        }
    }

    public enum LightStates
    {
        Red = 0,
        Green = 1,
        Yellow = 2,
    }
}
