using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp1
{
    internal class Instruction
    {
        public Instruction(string nominstruction,Label labelInstruction) { this.NomInstruction = nominstruction; this.labelInstruction = labelInstruction; }
        public Label labelInstruction { get; private set; }
        public String NomInstruction  { get; private set; }
        public void SetNomInstruction(string value){
            this.NomInstruction = value;
            this.labelInstruction.Content = value;
        }
    }
}
