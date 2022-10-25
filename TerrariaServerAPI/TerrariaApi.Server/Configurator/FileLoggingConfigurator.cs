using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace TerrariaApi.Configurator;

/// <summary>
/// Configures the log provider, adding text file logging.
/// </summary>
public class FileLoggingConfigurator : LoggingConfigurator
{
	/// <inheritdoc/>
	public override void Configure(HostBuilderContext hostContext, ILoggingBuilder logBuilder, string[] args)
	{
		logBuilder.AddNLog(hostContext.Configuration);
	}
}
