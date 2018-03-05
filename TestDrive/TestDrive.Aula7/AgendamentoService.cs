using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.ViewModels;

namespace TestDrive
{
    public class AgendamentoService
    {
        public static bool SaveAgendamento(AgendamentoMessage message)
        {
            if (string.IsNullOrEmpty(message.Nome))
                return true;
            else
                return false;
        }
    }
}
