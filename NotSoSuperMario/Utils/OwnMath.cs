using Microsoft.Xna.Framework;
using System;

namespace NotSoSuperMario.Utilities
{
    public static class OwnMath
    {
        public static float GetDistanceBetweenPoints(Point p1, Point p2)
        {
            float diffX = p2.X - p1.X;
            float diffY = p2.Y - p1.Y;
            float distance = new Vector2(diffX, diffY).Length();
            return distance;

        }
    }
}