using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    internal class PassengerCar : Auto
    {
        public PassengerCar(uint cointPassenger, float weight = 0.6f)
        {
            CapacityPassenger = cointPassenger;
            Weight = weight;
        }

        internal override float AvaregeSpeed { get; private protected set; } = 10f;
        internal override float Volume { get; private protected set; } = 5f;
        internal override float VolumeCurrent { get; private protected set; } = 5f;
        internal override float AvaregeConsumptionFuel { get; private protected set; } = 1f;
        internal override float Weight { get; private protected set; }
        internal override float CurrentAvaregeSpeed { get; private protected set; } = 10f;
        protected override void GetDownSpeed(uint ratio)
        {
            base.GetDownSpeed(ratio);
        }
        protected override void GetUpSpeed(uint ratio)
        {
            base.GetUpSpeed(ratio);
        }
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



        public uint CapacityPassenger { get; private set; }
        public uint CurrentPassenger
        {
            get
            {
                return CapacityPassenger;
            }
            set
            {
                if (CurrentPassenger > CapacityPassenger)
                {
                    throw new Exception("Невозможно использовать количество пассажиров больше максимальной вмистимости ");
                }
            }
        }

        public void PassengerAdd(uint cointPassenger)
        {
            if (CurrentPassenger + cointPassenger <= CapacityPassenger)
                GetUpSpeed(cointPassenger);
            else
                throw new Exception("Вместимость пассажиров превышена");
        }
        public void PassengerRemove(uint cointPassenger)
        {
            if (CurrentPassenger - cointPassenger > 0)
                GetDownSpeed(cointPassenger);
            else
                throw new Exception("Неверено задано количество выходящих пассажиров");
        }


    }
}
