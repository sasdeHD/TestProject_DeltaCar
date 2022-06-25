using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    public class TruckCar : Auto
    {
        public TruckCar(float weight = 0.4f)
        {
            Weight = weight;
        }
        internal override float AvaregeSpeed { get; private protected set; } = 10f;
        internal override float Volume { get; private protected set; } = 10f;
        internal override float VolumeCurrent { get; private protected set; } = 10f;
        internal override float Weight { get; private protected set; }
        internal override float AvaregeConsumptionFuel { get; private protected set; } = 1f;
        internal override float CurrentAvaregeSpeed { get; private protected set; } = 10f;
        public override float DistanceMuchDrive(float? currentFuel)
        {
            return base.DistanceMuchDrive(currentFuel);
        }
        public override float DistanceTimeDrive(float Distance, float fuel)
        {
            return base.DistanceTimeDrive(Distance, fuel);
        }
        protected override void GetDownSpeed(uint ratio)
        {
            base.GetDownSpeed(ratio);
        }
        protected override void GetUpSpeed(uint ratio)
        {
            base.GetUpSpeed(ratio);
        }
        public override string Stats()
        {
            return base.Stats();
        }

        public uint Payload { get; set; } = 100;
        public uint CurrentLoad { get; set; } = 0;
        private uint MaxLoad { get; set; } = uint.MaxValue;



        public bool CanLoad(uint cargo) => MaxLoad > (cargo + CurrentLoad);
        public void UnLoad(uint cargo)
        {
            int ratio = (int)(((CurrentLoad % Payload) - cargo) / Payload);
            if (ratio < 0)
            {
                ratio *= -1;
                GetUpSpeed((uint)ratio);
            }
            CurrentLoad -= cargo;
        }
        public void Load(uint cargo)
        {
            if (CanLoad(cargo))
            {
                uint ratio = ((CurrentLoad % Payload) + cargo) / Payload;
                CurrentLoad += cargo;
                if (ratio > 0)
                    GetDownSpeed(ratio);
            }
            else
                throw new Exception("Невозможно загрузить, вес больше грузоподъемнности");
        }

 
    }
}
