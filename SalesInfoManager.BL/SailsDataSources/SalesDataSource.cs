using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using SalesInfoManager.BL.Abstractions;
using SalesInfoManager.Persistence.Models;

namespace SalesInfoManager.BL.SailsDataSources
{
    public class SalesDataSource : IDataSource<SalesDataSourceDTO>
    {
        private readonly string _sourceFileName;
        private bool isDisposed = false;

        protected string TargetPath { get; set; }
        private readonly Guid _id = Guid.NewGuid();
        public Guid Id => _id;
        private StreamReader reader;
        public SalesDataSource(string sourceFileName, string targetPath)
        {
            _sourceFileName = sourceFileName;
            TargetPath = targetPath;
        }
        public void Backup()
        {
            ValidateState();
            var filename = String.Concat(TargetPath, Path.GetFileName(_sourceFileName));
            File.Move(_sourceFileName, filename);
            Dispose();
        }
        protected void ValidateState()
        {
            if (isDisposed)
            {
                throw new InvalidOperationException("Data Source is unvailable");
            }
        }
        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                        reader = null;
                    }
                }
                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerator<SalesDataSourceDTO> GetSalesPreDay()
        {
            ValidateState();
            string fileName = Path.GetFileName(_sourceFileName);
            string[] managerLastNameData = fileName.Split("_");
            string managerLastName = managerLastNameData[0];
            string dataTimeOrder = managerLastNameData[1].Replace(".csv", "").Insert(2, "/").Insert(5, "/");

            using (reader = new StreamReader(_sourceFileName))
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    ValidateState();
                    var items = currentLine.Split(',');
                    SalesDataSourceDTO current = new SalesDataSourceDTO()
                    {
                        DateTimeFile = DateTime.Parse(dataTimeOrder, CultureInfo.CurrentCulture),
                        DataTimeOrder = DateTime.Parse(items[0], CultureInfo.CurrentCulture),
                        ClientName = items[1],
                        ItemName = items[2],
                        ManagerLastName = managerLastName,
                        Price = decimal.Parse(items[3], CultureInfo.CurrentCulture)
                    };
                    yield return current;
                    currentLine = reader.ReadLine();
                }
            }
        }
        ~SalesDataSource()
        {
            Dispose(false);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<SalesDataSourceDTO> GetEnumerator()
        {
            return GetSalesPreDay();
        }
    }
}
