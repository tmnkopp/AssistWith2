using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using AssistWith.Common;
using AssistWith.Models;
using AssistWith.Models.Enums;
namespace AssistWith.Services
{
    public interface IDocProvider
    {
        IEnumerable<Template> GetTemplateDocs();
    }

    public class DocProvider : IDocProvider
    {
        public DocProvider()
        {
        }
        public IEnumerable<Template> GetTemplateDocs()
        {
            var _config = ConfigurationHelper.GetConfiguration(Environment.CurrentDirectory);
            var _path = _config.GetSection("AppSettings").GetSection("TemplateRoot").Value;
            DirectoryInfo DI = new DirectoryInfo($"{_path}");
            foreach (FileInfo file in DI.GetFiles("*.*"))
            {
                using (TextReader tr = File.OpenText(file.FullName))
                {
                    yield return new Template(tr.ReadToEnd(), file.Extension.ToLower(), file.Name);
                }

            }
        }
        private Dictionary<string, string> GetBaseSections(string DocType)
        {
            Dictionary<string, string> _sections = new Dictionary<string, string>();
            var _config = ConfigurationHelper.GetConfiguration(Environment.CurrentDirectory);
            var _path = _config.GetSection("AppSettings").GetSection("TemplateRoot").Value;
            DirectoryInfo DI = new DirectoryInfo($"{_path}\\{DocType}");

            foreach (FileInfo file in DI.GetFiles("*.*"))
            {
                using (TextReader tr = File.OpenText(file.FullName))
                {
                    _sections.Add(file.Name, tr.ReadToEnd());
                }
            }
            return _sections;
        }
        private Dictionary<string, string> GetClientDocSections(string ClientCode, string DocType)
        {
            Dictionary<string, string> _sections = GetBaseSections(DocType);
            var _config = ConfigurationHelper.GetConfiguration(Environment.CurrentDirectory);
            var _path = _config.GetSection("AppSettings").GetSection("TemplateRoot").Value;
            DirectoryInfo DI = new DirectoryInfo($"{_path}\\{ClientCode}\\{DocType}");

            foreach (FileInfo file in DI.GetFiles("*.*"))
            {
                if (_sections.ContainsKey(file.Name))
                {
                    _sections.Remove(file.Name);
                    using (TextReader tr = File.OpenText(file.FullName))
                    {
                        _sections.Add(file.Name, tr.ReadToEnd());
                    }
                }
            }
            return _sections;
        }
    }
}