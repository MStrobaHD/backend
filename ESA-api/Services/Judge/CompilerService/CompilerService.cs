using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.Custom;

namespace ESA_api.Services.Judge.CompilerService
{
    public class CompilerService : ICompilerService
    {
        public Task AddMarkersAsync()
        {
            throw new NotImplementedException();
        }

        public Task AnalyzeSourceCode()
        {
            throw new NotImplementedException();
        }

        public async Task<Input> CompileAsync(Input input)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            // run cmd in hidden mode
            startInfo.FileName = "cmd.exe";
            // run csc.exe <filename.cs> -> compile file to exe
            startInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
            process.StartInfo = startInfo;
            process.Start();

            return input;
        }

        public Task<int> RunExeAsync()
        {
            throw new NotImplementedException();
        }

        public Task RunExeWithCheckingAsync()
        {
            throw new NotImplementedException();
        }
    }
}
