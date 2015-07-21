using Microsoft.Xna.Framework;

namespace MonoGame.Extended.Graphics
{
    public abstract class ViewportAdapter
    {
        protected ViewportAdapter()
        {
        }

        public abstract int VirtualWidth { get; }
        public abstract int VirtualHeight { get; }
        public abstract int ActualWidth { get; }
        public abstract int ActualHeight { get; }
        public abstract void OnClientSizeChanged();
        public abstract Matrix GetScaleMatrix();

        public Point PointToScreen(Point point)
        {
            return PointToScreen(point.X, point.Y);
        }

        public virtual Point PointToScreen(int x, int y)
        {
            var scaleMatrix = GetScaleMatrix();
            var invertedMatrix = Matrix.Invert(scaleMatrix);
            return Vector2.Transform(new Vector2(x, y), invertedMatrix).ToPoint();
        }
    }
}