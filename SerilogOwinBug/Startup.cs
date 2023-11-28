using Microsoft.Owin;
using Owin;
using Serilog;

[assembly: OwinStartup(typeof(SerilogOwinBug.Startup))]

namespace SerilogOwinBug
{
    public class Startup
    {
        // Running the app produces the following log:
        // 2023-11-28 14:25:35Z [RequestId: 123] Starting middleware. URL: "/"
        // 2023-11-28 14:25:35Z [RequestId: ] Hello from Home Controller
        // 2023-11-28 14:25:37Z [RequestId: 123] Ending middleware. URL: "/"
        //
        // Expecting
        // 2023-11-28 14:25:35Z [RequestId: 123] Starting middleware. URL: "/"
        // 2023-11-28 14:25:35Z [RequestId: 123] Hello from Home Controller
        // 2023-11-28 14:25:37Z [RequestId: 123] Ending middleware. URL: "/"
        public Startup()
        {

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Trace(
                    outputTemplate: "{Timestamp:u} [RequestId: {RequestId}] {Message}"
                 )
                .CreateLogger();
        }
        public void Configuration(IAppBuilder app)
        {
            app.Use<SerilogMiddleware>();
        }
    }
}
