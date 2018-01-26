using System.Runtime.InteropServices;
using ISX.Utilities;

namespace ISX.LowLevel
{
    /// <summary>
    /// Notifies about the removal of an input device.
    /// </summary>
    /// <remarks>
    /// Device that got removed is the one identified by <see cref="InputEvent.deviceId"/>
    /// of <see cref="baseEvent"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = InputEvent.kBaseEventSize)]
    public struct DeviceRemoveEvent : IInputEventTypeInfo
    {
        public const int Type = 0x4452454D;

        /// <summary>
        /// Common event data.
        /// </summary>
        [FieldOffset(0)]
        public InputEvent baseEvent;

        public FourCC GetTypeStatic()
        {
            return Type;
        }

        public static DeviceRemoveEvent Create(int deviceId, double time)
        {
            var inputEvent =
                new DeviceRemoveEvent {baseEvent = new InputEvent(Type, InputEvent.kBaseEventSize, deviceId, time)};
            return inputEvent;
        }
    }
}
