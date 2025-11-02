using FFMpegCore.Arguments;
using FFMpegCore.Arguments.GenericOptions;
using FFMpegCore.Arguments.MainOptions;
using FFMpegCore.Arguments.VideoOptions;
using FFMpegCore.Enums;

namespace FFMpegCore;

public sealed class FFMpegGlobalArguments : FFMpegArgumentsBase
{
    internal FFMpegGlobalArguments() { }

    public FFMpegGlobalArguments WithVerbosityLevel(VerbosityLevel verbosityLevel = VerbosityLevel.Error)
    {
        return WithArgument(new VerbosityLevelArgument(verbosityLevel));
    }

    /// <summary>
    /// <see href="https://trac.ffmpeg.org/wiki/Hardware/VAAPI#SurfaceFormats" />
    /// undocumented in <see href="https://www.ffmpeg.org/ffmpeg.html#Advanced-Video-options" />
    /// </summary>
    /// <param name="device"></param>
    /// <returns></returns>
    public FFMpegGlobalArguments WithHardwareAccelerationOutputFormat(HardwareAccelerationDevice device)
    {
        return WithArgument(new HardwareAccelerationOutputFormatArgument(device));
    }

    /// <summary>
    /// <see href="https://ffmpeg.org/ffmpeg.html#Generic-options" />
    /// Suppress printing banner.
    /// All FFmpeg tools will normally show a copyright notice, build options and library versions.
    /// This option can be used to suppress printing this information.
    /// </summary>
    /// <returns></returns>
    public FFMpegGlobalArguments WithHideBanner()
    {
        return WithArgument(new HideBanner());
    }

    /// <summary>
    /// <see href="https://ffmpeg.org/ffmpeg.html#Main-options" />
    /// Explicitly disable logging of encoding progress/statistics.
    /// </summary>
    /// <returns></returns>
    public FFMpegGlobalArguments WithNoStats()
    {
        return WithArgument(new Stats(false));
    }

    public FFMpegGlobalArguments WithArgument(IArgument argument)
    {
        Arguments.Add(argument);
        return this;
    }
}
