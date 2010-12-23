using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarSystem.Objects;
using System.Drawing;

namespace StarSystem.Movement
{
    public interface MovementStrategy
    {

        // Вычислить положение объекта через заданный интервал времени
        PointF NextPosition(CelestialObject obj, double dt);

        // Пересчитать параметры модели для объекта
        void Recalculate(CelestialObject obj);

    }
}
