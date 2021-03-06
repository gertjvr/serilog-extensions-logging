﻿using System;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;


namespace Serilog
{
    /// <summary>
    /// Extends <see cref="ILoggingBuilder"/> with Serilog configuration methods.
    /// </summary>
    public static class SerilogLoggingBuilderExtensions
    {
        /// <summary>
        /// Add Serilog to the logging pipeline.
        /// </summary>
        /// <param name="builder">The <see cref="T:Microsoft.Extensions.Logging.ILoggingBuilder" /> to add logging provider to.</param>
        /// <param name="logger">The Serilog logger; if not supplied, the static <see cref="Serilog.Log"/> will be used.</param>
        /// <param name="dispose">When true, dispose <paramref name="logger"/> when the framework disposes the provider. If the
        /// logger is not specified but <paramref name="dispose"/> is true, the <see cref="Log.CloseAndFlush()"/> method will be
        /// called on the static <see cref="Log"/> class instead.</param>
        /// <returns>The logger factory.</returns>
        public static void AddSerilog(this ILoggingBuilder builder, ILogger logger = null, bool dispose = false)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.AddProvider(new SerilogLoggerProvider(logger, dispose));
        }
    }
}
