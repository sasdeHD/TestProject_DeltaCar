using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    internal class SportCar : Auto
    {
        public SportCar(float weight = 1f)
        {
            Weight = weight;
        }
        internal override float AvaregeSpeed { get; private protected set; } = 15f;
        internal override float Volume { get; private protected set; } = 15f;
        internal override float VolumeCurrent { get; private protected set; } = 15f;
        internal override float Weight { get; private protected set; }
        internal override float AvaregeConsumptionFuel { get; private protected set; } = 1f;
        internal override float CurrentAvaregeSpeed { get; private protected set; } = 15f;

        public override float DistanceMuchDrive(float? currentFuel)
        {
            return base.DistanceMuchDrive(currentFuel);
        }

        public override float DistanceTimeDrive(float Distance, float fuel)
        {
            return base.DistanceTimeDrive(Distance, fuel);
        }

        public override string Stats()
        {
            return base.Stats();
        }

        protected override void GetDownSpeed(uint ratio)
        {
            throw new Exception("Не описана логика, как он должен работать");
            //base.GetDownSpeed(ratio);
        }

        protected override void GetUpSpeed(uint ratio)
        {
            throw new Exception("Не описана логика, как он должен работать");
            //base.GetUpSpeed(ratio);
        }
    }
}
