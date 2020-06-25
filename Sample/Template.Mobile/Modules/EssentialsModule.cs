using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

namespace Template.Mobile.Modules
{
    public class EssentialsModule : ShinyModule
    {
        public override void Register(IServiceCollection services)
        {
            //Register in DI only "project-used services" from Xamarin.Essentials :

            //services.AddSingleton<IAccelerometer, AccelerometerImplementation>();
            //services.AddSingleton<IAppInfo, AppInfoImplementation>();
            //services.AddSingleton<IBarometer, BarometerImplementation>();
            //services.AddSingleton<IBattery, BatteryImplementation>();
            //services.AddSingleton<IClipboard, ClipboardImplementation>();
            //services.AddSingleton<ICompass, CompassImplementation>();
            //services.AddSingleton<IConnectivity, ConnectivityImplementation>();
            //services.AddSingleton<IDeviceDisplay, DeviceDisplayImplementation>();
            //services.AddSingleton<IDeviceInfo, DeviceInfoImplementation>();
            //services.AddSingleton<IEmail, EmailImplementation>();
            //services.AddSingleton<IFileSystem, FileSystemImplementation>();
            //services.AddSingleton<IFlashlight, FlashlightImplementation>();
            //services.AddSingleton<IGeocoding, GeocodingImplementation>();
            //services.AddSingleton<IGeolocation, GeolocationImplementation>();
            //services.AddSingleton<IGyroscope, GyroscopeImplementation>();
            //services.AddSingleton<ILauncher, LauncherImplementation>();
            //services.AddSingleton<IMagnetometer, MagnetometerImplementation>();
            //services.AddSingleton<IMap, MapImplementation>();
            //services.AddSingleton<IOrientationSensor, OrientationSensorImplementation>();
            //services.AddSingleton<IPermissions, PermissionsImplementation>();
            //services.AddSingleton<IPhoneDialer, PhoneDialerImplementation>();
            //services.AddSingleton<IPreferences, PreferencesImplementation>();
            //services.AddSingleton<ISecureStorage, SecureStorageImplementation>();
            //services.AddSingleton<IShare, ShareImplementation>();
            //services.AddSingleton<ISms, SmsImplementation>();
            //services.AddSingleton<ITextToSpeech, TextToSpeechImplementation>();
            //services.AddSingleton<IVersionTracking, VersionTrackingImplementation>();
            //services.AddSingleton<IVibration, VibrationImplementation>();
            //services.AddSingleton<IWebAuthenticator, WebAuthenticatorImplementation>();
                           
        }
    }
}
