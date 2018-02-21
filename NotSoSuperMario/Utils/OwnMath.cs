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

        public static float CalculateAngleBetweenPoints(Point p1, Point p2)
        {
            float deltaX = p2.X - p1.X;
            float deltaY = p2.Y - p1.Y;
            float res = (float)(Math.Atan2(deltaY, deltaX));
            return res;
        }
    }
}