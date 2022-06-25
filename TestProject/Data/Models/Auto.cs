using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    public abstract class Auto
    {
        internal abstract float AvaregeSpeed { get; private protected set; }
        internal abstract float CurrentAvaregeSpeed { get; private protected set; }
        internal abstract float AvaregeConsumptionFuel { get; private protected set; }
        internal abstract float Volume { get; private protected set; }
        internal abstract float VolumeCurrent { get; private protected set; }
        internal abstract float Weight { get; private protected set; }
        public virtual float DistanceMuchDrive(float? currentFuel) => CurrentAvaregeSpeed * currentFuel ?? Volume;
        public virtual float DistanceTimeDrive(float distance, float fuel)
        {

            var time = distance / CurrentAvaregeSpeed;
            float fuelConsumption = AvaregeConsumptionFuel * time - VolumeCurrent;
            if (fuelConsumption < 0)
                throw new Exception("Ошибка, данную дистанцию автомобиль не сможет проехать");
            // не описанно в задаче логика при который нам не хватает топлива
            return time;
        }
        public virtual string Stats()
        {
            return "Осталось:" + (CurrentAvaregeSpeed / VolumeCurrent) + " Км запаса хода, при данной загрузке";
        }
        protected virtual void GetDownSpeed(uint ratio)
        {
            CurrentAvaregeSpeed -= AvaregeSpeed * (Weight * ratio);
        }
        protected virtual void GetUpSpeed(uint ratio)
        {
            CurrentAvaregeSpeed += AvaregeSpeed * (Weight * ratio);
        }
    }
}
