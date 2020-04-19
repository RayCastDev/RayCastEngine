using OpenTK.Graphics.OpenGL4;

namespace SharpEngine.Buffers
{
    internal class VertexBufferObject<T> where T : struct
    {
        public int Handle;
        public readonly T[] VertexData;
        private readonly int vectorLength;
        private readonly BufferUsageHint bufferUsageHint;
        private readonly BufferTarget bufferTarget;

        public VertexBufferObject(T[] vertexData, int vectorLength,BufferTarget bufferTarget ,BufferUsageHint bufferUsageHint)
        {
            Handle = GL.GenBuffer();
            this.VertexData = vertexData;
            this.vectorLength = vectorLength;
            this.bufferUsageHint = bufferUsageHint;
            this.bufferTarget = bufferTarget;

            BindBuffer();
            BufferData();
        }

        private void BindBuffer()
        {
            GL.BindBuffer(bufferTarget, Handle);
        }

        private void BufferData()
        {
            GL.BufferData(bufferTarget, VertexData.Length * vectorLength * sizeof(float), VertexData, bufferUsageHint);
        }

        public void ClearHandle()
        {
            GL.DeleteBuffer(Handle);
        }
    }
}
