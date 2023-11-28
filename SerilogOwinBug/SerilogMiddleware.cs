using Microsoft.Owin;
using Serilog.Context;
using Serilog;
using System.Threading.Tasks;

namespace SerilogOwinBug
{
    public class SerilogMiddleware : OwinMiddleware
    {
        public SerilogMiddleware(OwinMiddleware next) : base(next)
        {

        }

        public override async Task Invoke(IOwinContext context)
        {
            using (LogContext.PushProperty("RequestId", "123"))
            {
                Log.Information("Starting middleware. URL: {URL}", context.Request.Path);
                await Next.Invoke(context);
                Log.Information("Ending middleware. URL: {URL}", context.Request.Path);
            }
        }
    }
}