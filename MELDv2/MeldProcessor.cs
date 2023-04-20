using MELDv2.FileWorkers;
using MELDv2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MELDv2
{
    public class MeldProcessor
    {
        public MeldProcessor(MeltConfiguration config) 
        {
            FolderPath = config.FolderPath;
            S5SeqPath = config.S5SeqPath;
            MessageFilePath = config.MessageFilePath;
            TagFilePath = config.TagFilePath;
            EndpointDB = config.EndpointDB;
            EndpointOffset = config.EndpointOffset;
            ConnectionName = config.ConnectionName;
            StartIndex = config.StartIndex;
            Class = config.Class;
            Types = config.Types;
        }
        private string FolderPath { get; set; }
        private string S5SeqPath { get; set; }
        private string MessageFilePath { get; set; }
        private string TagFilePath { get; set; }
        private string EndpointDB { get; set; }
        private int EndpointOffset { get; set; }
        private string ConnectionName { get; set; }
        private int StartIndex { get; set; }
        private int Class { get; set; }
        private int[] Types { get; set; }

        public int Run()
        {
            int count;
            try
            {
                new S5MessageReader(S5SeqPath);
                new TagWriter(TagFilePath, ConnectionName, EndpointDB, EndpointOffset);
                new MessageWriter(MessageFilePath, StartIndex, Class, Types, ConnectionName);

                count = S5MessagesRepository.S5Messages.Count();
            }
            catch (Exception)
            {
                count = -1;
            }
            return count;
        }
    }
    public class MeltConfiguration
    {
        public string FolderPath { get; set; }
        public string S5SeqPath { get; set; }
        public string MessageFilePath { get; set; }
        public string TagFilePath { get; set; }
        public string EndpointDB { get; set; }
        public int EndpointOffset { get; set; }
        public string ConnectionName { get; set; }
        public int StartIndex { get; set; }
        public int Class { get; set; } = 2;
        public int[] Types { get; set; } = { 17, 18, 19 };
    }
}
