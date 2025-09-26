using System;
using UnityEngine;

namespace UnistrokeGestureRecognition {
    public abstract class PathDrawerBase : MonoBehaviour {
        public abstract void Hide();
        public abstract void Show();
        public abstract void AddPoint(Vector2 position);
        public abstract void SetPath(ReadOnlySpan<Vector2> path);
        public abstract void Clear();
    }
}
