using Microsoft.UI.Windowing;
using Microsoft.UI;
using System.Runtime.Versioning;
using Windows.Graphics;

namespace Curl_maui.WinUI;
public class StaticFunctionsWindows
{
    /// <summary>
    /// Max current window in Windows
    /// </summary>
    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("linux")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("maccatalyst")]
    [SupportedOSPlatform("windows10.0.17763.0")]
    public static void WinMaxWindow(Microsoft.UI.Xaml.Window window)
    {
        IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
        WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
        AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);
        if (winuiAppWindow.Presenter is OverlappedPresenter p)
        { p.Maximize(); }
        else
        {
            const int width = 1200;
            const int height = 800;
            var displayArea = DisplayArea.GetFromWindowId(win32WindowsId, DisplayAreaFallback.Primary);
            var workArea = displayArea.WorkArea;
            winuiAppWindow.MoveAndResize(new RectInt32(
                workArea.X + (workArea.Width / 2 - width / 2),
                workArea.Y + (workArea.Height / 2 - height / 2),
                width, height));
        }
    }
}
