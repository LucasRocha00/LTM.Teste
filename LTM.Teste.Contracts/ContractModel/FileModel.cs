using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Teste.Contracts.ContractModel
{
    public class FileModel
    {
        public string Data { get; set; }
        public byte[] Data64 { get; set; }
        public int Extension { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
    }
}
