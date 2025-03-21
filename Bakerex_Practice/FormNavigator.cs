using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakerex_Practice
{
    internal class FormNavigator
    {
            public static void OpenTechniciansForm(int adminId)
            {
                Technicians techniciansForm = new Technicians(adminId);
                techniciansForm.Show();
            }

            public static void OpenMainDashboard(int adminId)
            {
                MainDashboard dashboard = new MainDashboard(adminId);
                dashboard.Show();
            }

    }
}
