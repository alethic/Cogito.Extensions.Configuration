using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.Extensions.Configuration;

namespace Cogito.Extensions.Configuration
{

    /// <summary>
    /// Various extension methds for the Microsoft Configuration System.
    /// </summary>
    public static class ConfigurationBuilderExtensions
    {

        /// <summary>
        /// Appends any App.config.local.json files located in the parent paths of the application path.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IConfigurationBuilder AddParentJsonFiles(this IConfigurationBuilder builder, string fileName)
        {
            return AddParentJsonFiles(builder, fileName, null);
        }

        /// <summary>
        /// Appends any App.config.local.json files located in the parent paths of the application path.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="fileName"></param>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public static IConfigurationBuilder AddParentJsonFiles(this IConfigurationBuilder builder, string fileName, string basePath = null)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));

            // append any settings files in the parent paths.
            foreach (var i in GetParentConfigFiles(new DirectoryInfo(basePath ?? GetBaseDirectory()), fileName))
                builder.AddJsonFile(i.FullName, true);

            return builder;
        }

        /// <summary>
        /// Gets the base application directory.
        /// </summary>
        /// <returns></returns>
        static string GetBaseDirectory()
        {
#if NET451
            return AppDomain.CurrentDomain.BaseDirectory;
#else
            return AppContext.BaseDirectory;
#endif
        }

        /// <summary>
        /// Returns any configuration files to be applied given the specified starting directory.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static IEnumerable<FileInfo> GetParentConfigFiles(DirectoryInfo directory, string fileName)
        {
            if (directory == null)
                throw new ArgumentNullException(nameof(directory));
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));

            return GetParentDirectories(directory)
                .Select(i => new FileInfo(Path.Combine(i.FullName, fileName)))
                .Where(i => i.Exists)
                .Reverse();
        }

        /// <summary>
        /// Gets all the parent directories of the specified directory.
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        static IEnumerable<DirectoryInfo> GetParentDirectories(DirectoryInfo directory)
        {
            if (directory == null)
                throw new ArgumentNullException(nameof(directory));

            while ((directory = directory.Parent) != null)
                yield return directory;
        }

    }

}
