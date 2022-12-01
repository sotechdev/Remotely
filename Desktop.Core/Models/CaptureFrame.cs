using System;

namespace Remotely.Desktop.Core.Models;

public class CaptureFrame
{
    public byte[] EncodedImageBytes { get; init; }
    public Guid Id { get; } = Guid.NewGuid();
    public int Top { get; init; }
    public int Left { get; init; }
    public int Height { get; init; }
    public int Width { get; init; }
    public long Sequence { get; init; }
}
