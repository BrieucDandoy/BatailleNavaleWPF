using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Instruction
    {
        public String NomInstruction  { get; private set; }
        public void SetNomInstruction(string value){
            this.NomInstruction = value;
            LabelInstruction.text = value;
        }
    }
}
